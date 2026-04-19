using FloraBack.BusinessLogic.Core.Products;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProduct
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var products = ExecuteGetAllProductsAction();
            return products;
        }

        public ProductDto? GetProductByIdAction(int id)
        {
            var product = ExecuteGetProductByIdAction(id);
            return product;
        }
    }
}