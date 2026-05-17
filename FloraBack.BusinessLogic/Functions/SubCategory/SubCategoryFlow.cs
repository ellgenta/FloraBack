using FloraBack.BusinessLogic.Core.SubCategory;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Functions.SubCategory
{
    public class SubCategoryFlow : SubCategoryActions, ISubCategoryActions
    {
        public SubCategoryInfoDto CreateSubCategoryAction(SubCategoryCreateDto subCategory)
        {
            var _subCategory = ExecuteCreateSubCategoryAction(subCategory);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public List<SubCategoryInfoDto> GetAllSubCategoriesAction()
        {
            var _subCategories = ExecuteGetAllSubCategoriesAction();

            return _subCategories
                .Select(subCategory => MapSubCategoryToInfoDto(subCategory))
                .ToList();
        }

        public List<SubCategoryInfoDto> GetSubCategoriesByCategoryIdAction(int categoryId)
        {
            var _subCategories = ExecuteGetSubCategoriesByCategoryIdAction(categoryId);

            return _subCategories
                .Select(subCategory => MapSubCategoryToInfoDto(subCategory))
                .ToList();
        }

        public SubCategoryInfoDto GetSubCategoryByIdAction(int id)
        {
            var _subCategory = ExecuteGetSubCategoryByIdAction(id);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public SubCategoryInfoDto UpdateSubCategoryAction(int id, SubCategoryCreateDto subCategory)
        {
            var _subCategory = ExecuteUpdateSubCategoryAction(id, subCategory);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public bool DeleteSubCategoryAction(int id)
        {
            return ExecuteDeleteSubCategoryAction(id);
        }

        private SubCategoryInfoDto MapSubCategoryToInfoDto(SubCategoryData subCategory)
        {
            return new SubCategoryInfoDto()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId
            };
        }
    }
}