using FloraBack.BusinessLogic.Core.Category;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Functions.Category
{
    public class CategoryFlow : ICategoryActions
    {
        private readonly CategoryActions _categoryActions;

        public CategoryFlow()
        {
            _categoryActions = new CategoryActions();
        }

        public CategoryInfoDto CreateCategory(CategoryCreateDto category)
        {
            var _category = _categoryActions.ExecuteCreateCategoryAction(category);

            return MapCategoryToInfoDto(_category);
        }

        public List<CategoryInfoDto> GetAllCategories()
        {
            var _categories = _categoryActions.ExecuteGetAllCategoriesAction();

            return _categories
                .Select(category => MapCategoryToInfoDto(category))
                .ToList();
        }

        public CategoryInfoDto GetCategoryById(int id)
        {
            var _category = _categoryActions.ExecuteGetCategoryByIdAction(id);

            if (_category == null)
            {
                return null;
            }

            return MapCategoryToInfoDto(_category);
        }

        public CategoryInfoDto UpdateCategory(int id, CategoryCreateDto category)
        {
            var _category = _categoryActions.ExecuteUpdateCategoryAction(id, category);

            if (_category == null)
            {
                return null;
            }

            return MapCategoryToInfoDto(_category);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryActions.ExecuteDeleteCategoryAction(id);
        }

        private CategoryInfoDto MapCategoryToInfoDto(CategoryData category)
        {
            return new CategoryInfoDto()
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = category.SubCategories
                    .Select(subCategory => new SubCategoryInfoDto()
                    {
                        Id = subCategory.Id,
                        Name = subCategory.Name,
                        CategoryId = subCategory.CategoryId
                    })
                    .ToList()
            };
        }
    }
}