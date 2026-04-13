using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductActions
    {
        protected List<ProductDto> ExecuteGetAllProductsAction()
        {
            var products = new List<ProductDto>();

            //DB connect - SELECT
            var productFromDb = new ProductData()
            {
                Id = 1,
                Name = "Product 1",
                Description = new ProductDescriptionData()
                {
                    Id = 1,
                    Description = "Description 1",
                    DescriptionAdvanced = new DescriptionAdvanced()
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
                        Url = "https://example.com/product1.jpg"
                    },
                    new ProductImgData()
                    {
                        Id = 2,
                        Url = "https://example.com/product1-2.jpg"
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
    }
}
