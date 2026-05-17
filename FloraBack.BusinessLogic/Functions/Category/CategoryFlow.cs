using FloraBack.BusinessLogic.Core.Category;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Functions.Category
{
    public class CategoryFlow : CategoryActions, ICategoryActions
    {
        public CategoryInfoDto CreateCategoryAction(CategoryCreateDto category)
        {
            var _category = ExecuteCreateCategoryAction(category);

            return MapCategoryToInfoDto(_category);
        }

        public List<CategoryInfoDto> GetAllCategoriesAction()
        {
            var _categories = ExecuteGetAllCategoriesAction();

            return _categories
                .Select(category => MapCategoryToInfoDto(category))
                .ToList();
        }

        public CategoryInfoDto GetCategoryByIdAction(int id)
        {
            var _category = ExecuteGetCategoryByIdAction(id);

            if (_category == null)
            {
                return null;
            }

            return MapCategoryToInfoDto(_category);
        }

        public CategoryInfoDto UpdateCategoryAction(int id, CategoryCreateDto category)
        {
            var _category = ExecuteUpdateCategoryAction(id, category);

            if (_category == null)
            {
                return null;
            }

            return MapCategoryToInfoDto(_category);
        }

        public bool DeleteCategoryAction(int id)
        {
            return ExecuteDeleteCategoryAction(id);
        }

        private CategoryInfoDto MapCategoryToInfoDto(CategoryData category)
        {
            return new CategoryInfoDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}