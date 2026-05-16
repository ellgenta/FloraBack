using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProductActions
    {
        List<ProductInfoDto> GetAllProductsAction();

        ProductInfoDto? GetProductByIdAction(int id);

        List<ProductInfoDto> GetProductsByCategoryAction(int categoryId);

        List<ProductInfoDto> GetProductsBySubCategoryAction(int subCategoryId);

        ProductInfoDto? CreateProductAction(ProductCreateDto product);

        ProductInfoDto? UpdateProductAction(int id, ProductCreateDto product);

        bool DeleteProductAction(int id);
    }
}