using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICategoryActions
    {
        CategoryInfoDto CreateCategory(CategoryCreateDto category);

        List<CategoryInfoDto> GetAllCategories();

        CategoryInfoDto GetCategoryById(int id);

        CategoryInfoDto UpdateCategory(int id, CategoryCreateDto category);

        bool DeleteCategory(int id);
    }
}