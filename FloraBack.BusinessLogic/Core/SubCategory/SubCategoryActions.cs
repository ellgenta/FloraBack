using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.SubCategory
{
    public class SubCategoryActions
    {
        public SubCategoryData ExecuteCreateSubCategoryAction(SubCategoryCreateDto subCategory)
        {
            using (var db = new AppDbContext())
            {
                var _categoryExists = db.Categories.Any(c => c.Id == subCategory.CategoryId);

                if (!_categoryExists)
                {
                    return null;
                }

                var _newSubCategory = new SubCategoryData()
                {
                    Name = subCategory.Name,
                    CategoryId = subCategory.CategoryId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                db.SubCategories.Add(_newSubCategory);
                db.SaveChanges();

                return _newSubCategory;
            }
        }

        public List<SubCategoryData> ExecuteGetAllSubCategoriesAction()
        {
            using (var db = new AppDbContext())
            {
                return db.SubCategories
                    .Include(sc => sc.Category)
                    .ToList();
            }
        }

        public List<SubCategoryData> ExecuteGetSubCategoriesByCategoryIdAction(int categoryId)
        {
            using (var db = new AppDbContext())
            {
                return db.SubCategories
                    .Include(sc => sc.Category)
                    .Where(sc => sc.CategoryId == categoryId)
                    .ToList();
            }
        }

        public SubCategoryData ExecuteGetSubCategoryByIdAction(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.SubCategories
                    .Include(sc => sc.Category)
                    .FirstOrDefault(sc => sc.Id == id);
            }
        }

        public SubCategoryData ExecuteUpdateSubCategoryAction(int id, SubCategoryCreateDto subCategory)
        {
            using (var db = new AppDbContext())
            {
                var _subCategory = db.SubCategories
                    .FirstOrDefault(sc => sc.Id == id);

                if (_subCategory == null)
                {
                    return null;
                }

                var _categoryExists = db.Categories.Any(c => c.Id == subCategory.CategoryId);

                if (!_categoryExists)
                {
                    return null;
                }

                _subCategory.Name = subCategory.Name;
                _subCategory.CategoryId = subCategory.CategoryId;
                _subCategory.UpdatedAt = DateTime.Now;

                db.SubCategories.Update(_subCategory);
                db.SaveChanges();

                return ExecuteGetSubCategoryByIdAction(id);
            }
        }

        public bool ExecuteDeleteSubCategoryAction(int id)
        {
            using (var db = new AppDbContext())
            {
                var _subCategory = db.SubCategories
                    .Include(sc => sc.Products)
                    .FirstOrDefault(sc => sc.Id == id);

                if (_subCategory == null)
                {
                    return false;
                }

                if (_subCategory.Products.Any())
                {
                    return false;
                }

                db.SubCategories.Remove(_subCategory);
                db.SaveChanges();

                return true;
            }
        }
    }
}