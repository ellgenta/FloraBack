using FloraBack.BusinessLogic.Core.Products;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProductActions
    {
        public List<ProductInfoDto> GetAllProductsAction()
        {
            var productsData = ExecuteGetAllProductsAction();
            var productsDto = new List<ProductInfoDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public ProductInfoDto? GetProductByIdAction(int id)
        {
            var product = ExecuteGetProductByIdAction(id);

            if (product == null)
            {
                return null;
            }

            return MapToDto(product);
        }

        public List<ProductInfoDto> GetProductsByCategoryAction(ProductCategory category)
        {
            var productsData = ExecuteGetProductsByCategoryAction(category);
            var productsDto = new List<ProductInfoDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public List<ProductInfoDto> GetProductsBySubCategoryAction(string subCategory)
        {
            var productsData = ExecuteGetProductsBySubCategoryAction(subCategory);
            var productsDto = new List<ProductInfoDto>();

            foreach (var product in productsData)
            {
                productsDto.Add(MapToDto(product));
            }

            return productsDto;
        }

        public ProductInfoDto CreateProductAction(ProductCreateDto product)
        {
            var createdProduct = ExecuteCreateProductAction(product);

            if (createdProduct == null)
            {
                return null;
            }

            return MapToDto(createdProduct);
        }

        public ProductInfoDto? UpdateProductAction(int id, ProductCreateDto product)
        {
            var updatedProduct = ExecuteUpdateProductAction(id, product);

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

        private ProductInfoDto MapToDto(ProductData product)
        {
            return new ProductInfoDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description != null ? new ProductDescriptionInfoDto()
                {
                    Id = product.Description.Id,
                    Description = product.Description.Description,
                    ProductId = product.Description.ProductId
                } : null,
                Category = product.Category != null ? new ProductCategoryDto()
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                } : null,
                SubCategory = product.SubCategory,
                Images = product.Images?.Select(img => new ProductImgInfoDto()
                {
                    Id = img.Id,
                    Url = img.Url,
                    ProductId = img.ProductId
                }).ToList() ?? new List<ProductImgInfoDto>(),
                Price = product.Price,
                Status = product.Status,
            };
        }
    }
}