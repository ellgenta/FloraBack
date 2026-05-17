using FloraBack.Domains.Models.Category;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ISubCategoryActions
    {
        SubCategoryInfoDto CreateSubCategoryAction(SubCategoryCreateDto subCategory);

        List<SubCategoryInfoDto> GetAllSubCategoriesAction();

        List<SubCategoryInfoDto> GetSubCategoriesByCategoryIdAction(int categoryId);

        SubCategoryInfoDto GetSubCategoryByIdAction(int id);

        SubCategoryInfoDto UpdateSubCategoryAction(int id, SubCategoryCreateDto subCategory);

        bool DeleteSubCategoryAction(int id);
    }
}