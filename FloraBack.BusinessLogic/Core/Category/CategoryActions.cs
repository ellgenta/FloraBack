using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.Category
{
    public class CategoryActions
    {
        public CategoryData ExecuteCreateCategoryAction(CategoryCreateDto category)
        {
            var _newCategory = new CategoryData()
            {
                Name = category.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            using (var db = new AppDbContext())
            {
                db.Categories.Add(_newCategory);
                db.SaveChanges();
            }

            return _newCategory;
        }

        public List<CategoryData> ExecuteGetAllCategoriesAction()
        {
            var _categories = new List<CategoryData>();

            using (var db = new AppDbContext())
            {
                _categories = db.Categories.Include(c => c.SubCategories).ToList();
            }

            return _categories;
        }

        public CategoryData ExecuteGetCategoryByIdAction(int id)
        {
            CategoryData _category = null;

            using (var db = new AppDbContext())
            {
                _category = db.Categories.Include(c => c.SubCategories).FirstOrDefault(c => c.Id == id);
            }

            return _category;
        }

        public CategoryData ExecuteUpdateCategoryAction(int id, CategoryCreateDto category)
        {
            CategoryData _category = null;

            using (var db = new AppDbContext())
            {
                _category = db.Categories.FirstOrDefault(c => c.Id == id);

                if (_category == null)
                {
                    return null;
                }

                _category.Name = category.Name;
                _category.UpdatedAt = DateTime.Now;

                db.Categories.Update(_category);
                db.SaveChanges();
            }

            return ExecuteGetCategoryByIdAction(id);
        }

        public bool ExecuteDeleteCategoryAction(int id)
        {
            using (var db = new AppDbContext())
            {
                var _category = db.Categories.Include(c => c.SubCategories).Include(c => c.Products).FirstOrDefault(c => c.Id == id);

                if (_category == null)
                {
                    return false;
                }

                if (_category.SubCategories.Any() || _category.Products.Any())
                {
                    return false;
                }

                db.Categories.Remove(_category);
                db.SaveChanges();

                return true;
            }
        }
    }
}