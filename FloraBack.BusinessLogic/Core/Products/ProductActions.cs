using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        public List<ProductData> ExecuteGetAllProductsAction()
        {
            using (var db = new ProductContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .ToList();
            }
        }

        public ProductData? ExecuteGetProductByIdAction(int id)
        {
            using (var db = new ProductContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public List<ProductData> ExecuteGetProductsByCategoryAction(ProductCategory category)
        {
            using (var db = new ProductContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Where(p => p.Category.Name == category)
                    .ToList();
            }
        }

        public List<ProductData> ExecuteGetProductsBySubCategoryAction(string subCategory)
        {
            using (var db = new ProductContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Where(p => p.SubCategory.ToLower() == subCategory.ToLower())
                    .ToList();
            }
        }

        public ProductData? ExecuteCreateProductAction(ProductData product)
        {
            var newProduct = new ProductData()
            {
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                SubCategory = product.SubCategory,
                Images = product.Images ?? new List<ProductImgData>(),
                Price = product.Price,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            using (var db = new ProductContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }

            return newProduct;
        }

        public ProductData? ExecuteUpdateProductAction(int id, ProductData product)
        {
            using (var db = new ProductContext())
            {
                var existingProduct = db.Products
                    .Include(p => p.Images)
                    .FirstOrDefault(p => p.Id == id);

                if (existingProduct == null)
                {
                    return null;
                }

                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Category = product.Category;
                existingProduct.SubCategory = product.SubCategory;
                existingProduct.Price = product.Price;
                existingProduct.UpdatedAt = DateTime.Now;

                existingProduct.Images.Clear();

                if (product.Images != null)
                {
                    foreach (var image in product.Images)
                    {
                        existingProduct.Images.Add(new ProductImgData()
                        {
                            Url = image.Url,
                            ProductId = existingProduct.Id
                        });
                    }
                }

                db.SaveChanges();

                return existingProduct;
            }
        }

        public bool ExecuteDeleteProductAction(int id)
        {
            using (var db = new ProductContext())
            {
                var product = db.Products
                    .Include(p => p.Images)
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return false;
                }

                db.Products.Remove(product);
                db.SaveChanges();

                return true;
            }
        }
    }
}