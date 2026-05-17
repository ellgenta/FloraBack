using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICategoryActions
    {
        CategoryInfoDto CreateCategoryAction(CategoryCreateDto category);

        List<CategoryInfoDto> GetAllCategoriesAction();

        CategoryInfoDto GetCategoryByIdAction(int id);

        CategoryInfoDto UpdateCategoryAction(int id, CategoryCreateDto category);

        bool DeleteCategoryAction(int id);
    }
}