using FloraBack.BusinessLogic.Core.Products;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProduct
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var productsData = ExecuteGetAllProductsAction();
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Images = product.Images,
                    Price = product.Price
                };

                productsDto.Add(productDto);
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

            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Price = product.Price
            };

            return productDto;
        }

        public List<ProductDto> GetProductsByCategoryAction(ProductCategory category)
        {
            var productsData = ExecuteGetProductsByCategoryAction(category);
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Images = product.Images,
                    Price = product.Price
                };

                productsDto.Add(productDto);
            }

            return productsDto;
        }
        public List<ProductDto> GetProductsBySubCategoryAction(string subCategory)
        {
            var productsData = ExecuteGetProductsBySubCategoryAction(subCategory);
            var productsDto = new List<ProductDto>();

            foreach (var product in productsData)
            {
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Images = product.Images,
                    Price = product.Price
                };

                productsDto.Add(productDto);
            }

            return productsDto;
        }

        public ProductDto CreateProductAction(ProductData product)
        {
            var createdProduct = ExecuteCreateProductAction(product);

            if (createdProduct == null)
            {
                return null;
            }

            var productDto = new ProductDto()
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Category = createdProduct.Category,
                Images = createdProduct.Images,
                Price = createdProduct.Price
            };

            return productDto;
        }

        public ProductDto? UpdateProductAction(int id, ProductData product)
        {
            var updatedProduct = ExecuteUpdateProductAction(id, product);

            if (updatedProduct == null)
            {
                return null;
            }

            var productDto = new ProductDto()
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Description = updatedProduct.Description,
                Category = updatedProduct.Category,
                Images = updatedProduct.Images,
                Price = updatedProduct.Price
            };

            return productDto;
        }

        public bool DeleteProductAction(int id)
        {
            var result = ExecuteDeleteProductAction(id);
            return result;
        }
    }
}