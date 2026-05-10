using FloraBack.BusinessLogic.Core.Products;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProductActions
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var productsData = ExecuteGetAllProductsAction();
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public ProductDto? GetProductByIdAction(int id)
        {
            var product = ExecuteGetProductByIdAction(id);

            if (product == null)
            {
                return null;
            }

            return MapToDto(product);
        }

        public List<ProductDto> GetProductsByCategoryAction(ProductCategory category)
        {
            var productsData = ExecuteGetProductsByCategoryAction(category);
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public List<ProductDto> GetProductsBySubCategoryAction(string subCategory)
        {
            var productsData = ExecuteGetProductsBySubCategoryAction(subCategory);
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public ProductDto CreateProductAction(ProductDto product)
        {
            var productData = MapToData(product);

            var createdProduct = ExecuteCreateProductAction(productData);

            if (createdProduct == null)
            {
                throw new InvalidOperationException("Product was not created");
            }

            return MapToDto(createdProduct);
        }

        public ProductDto? UpdateProductAction(int id, ProductDto product)
        {
            var productData = MapToData(product);

            var updatedProduct = ExecuteUpdateProductAction(id, productData);

            if (updatedProduct == null)
            {
                return null;
            }

            return MapToDto(updatedProduct);
        }

        public bool DeleteProductAction(int id)
        {
            return ExecuteDeleteProductAction(id);
        }

        private ProductDto MapToDto(ProductData product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Price = product.Price
            };
        }

        private ProductData MapToData(ProductDto product)
        {
            return new ProductData()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Price = product.Price,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
    }
}