using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        protected List<ProductData> ExecuteGetAllProductsAction()
        {
            var products = new List<ProductData>();

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

            products.Add(productFromDb);
            return products;
        }

        protected ProductData? ExecuteGetProductByIdAction(int id)
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

            return productFromDb;
        }

        protected List<ProductData> ExecuteGetProductsByCategoryAction(ProductCategory category)
        {
            var products = new List<ProductData>();

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
            }
        },
                Price = 100.20m,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (productFromDb.Category.Name == category)
            {
                products.Add(productFromDb);
            }

            return products;
        }

        protected ProductData? ExecuteCreateProductAction(ProductData product)
        {
            if (product == null)
            {
                return null;
            }

            var newProduct = new ProductData()
            {
                Id = product.Id > 0 ? product.Id : 2,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Price = product.Price,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return newProduct;
        }

        protected ProductData? ExecuteUpdateProductAction(int id, ProductData product)
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

            productFromDb.Name = product.Name;
            productFromDb.Description = product.Description;
            productFromDb.Category = product.Category;
            productFromDb.Images = product.Images;
            productFromDb.Price = product.Price;
            productFromDb.UpdatedAt = DateTime.Now;

            return productFromDb;
        }

        protected bool ExecuteDeleteProductAction(int id)
        {
            var productFromDb = new ProductData()
            {
                Id = 1
            };

            if (productFromDb.Id != id)
            {
                return false;
            }

            return true;
        }
    }
}