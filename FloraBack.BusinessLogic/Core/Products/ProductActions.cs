using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        protected List<ProductDto> ExecuteGetAllProductsAction()
        {
            var products = new List<ProductDto>();

            var productFromDb = new ProductData()
            {
                Id = 1,
                Name = "Product 1",
                Description = new ProductDescriptionData()
                {
                    Id = 1,
                    Description = "Description 1",
                    DescriptionAdvanced = new DescriptionAdvanced()
                    {
                        Id = 1,
                        H = 20,
                        W = 10,
                        L = 5
                    }
                },
                Category = new CategoryData()
                {
                    Id = 1,
                    Name = ProductCategory.Plants
                },
                Images = new List<ProductImgData>()
                {
                    new ProductImgData()
                    {
                        Id = 1,
                        Url = "https://example.com/product1.jpg",
                        ProductId = 1
                    },
                    new ProductImgData()
                    {
                        Id = 2,
                        Url = "https://example.com/product1-2.jpg",
                        ProductId = 1
                    }
                },
                Price = 100.20m,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var product = new ProductDto()
            {
                Id = productFromDb.Id,
                Name = productFromDb.Name,
                Description = productFromDb.Description,
                Category = productFromDb.Category,
                Images = productFromDb.Images,
                Price = productFromDb.Price
            };

            products.Add(product);
            return products;
        }

        protected ProductDto? ExecuteGetProductByIdAction(int id)
        {
            var productFromDb = new ProductData()
            {
                Id = 1,
                Name = "Product 1",
                Description = new ProductDescriptionData()
                {
                    Id = 1,
                    Description = "Description 1",
                    DescriptionAdvanced = new DescriptionAdvanced()
                    {
                        Id = 1,
                        H = 20,
                        W = 10,
                        L = 5
                    }
                },
                Category = new CategoryData()
                {
                    Id = 1,
                    Name = ProductCategory.Plants
                },
                Images = new List<ProductImgData>()
                {
                    new ProductImgData()
                    {
                        Id = 1,
                        Url = "https://example.com/product1.jpg",
                        ProductId = 1
                    },
                    new ProductImgData()
                    {
                        Id = 2,
                        Url = "https://example.com/product1-2.jpg",
                        ProductId = 1
                    }
                },
                Price = 100.20m,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (productFromDb.Id != id)
            {
                return null;
            }

            var product = new ProductDto()
            {
                Id = productFromDb.Id,
                Name = productFromDb.Name,
                Description = productFromDb.Description,
                Category = productFromDb.Category,
                Images = productFromDb.Images,
                Price = productFromDb.Price
            };

            return product;
        }
    }
}