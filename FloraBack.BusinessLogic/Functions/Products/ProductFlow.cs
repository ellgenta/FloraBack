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

        public ProductDto CreateProductAction(ProductDto product)
        {
            var createdProduct = ExecuteCreateProductAction(product);
            return createdProduct;
        }

        public ProductDto? UpdateProductAction(int id, ProductDto product)
        {
            var updatedProduct = ExecuteUpdateProductAction(id, product);
            return updatedProduct;
        }

        public bool DeleteProductAction(int id)
        {
            var result = ExecuteDeleteProductAction(id);
            return result;
        }
    }
}