using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        public List<ProductData> ExecuteGetAllProductsAction()
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.Description)
                    .ToList();
            }
        }

        public ProductData? ExecuteGetProductByIdAction(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.Description)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public List<ProductData> ExecuteGetProductsByCategoryAction(ProductCategory category)
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.Description)
                    .Where(p => p.Category.Name == category.ToString())
                    .ToList();
            }
        }

        public List<ProductData> ExecuteGetProductsBySubCategoryAction(string subCategory)
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.Description)
                    .Where(p => p.SubCategory.Name.ToLower() == subCategory.ToLower())
                    .ToList();
            }
        }

        public ProductData? ExecuteCreateProductAction(ProductCreateDto product)
        {
            using (var db = new AppDbContext())
            {
                var newProduct = new ProductData()
                {
                    Name = product.Name,
                    Description = new ProductDescriptionData() { Description = product.Description.Description },
                    Category = db.Categories.FirstOrDefault(c => c.Id == product.CategoryId),
                    SubCategoryId = product.SubCategoryId,
                    Images = product.Images.Select(img => new ProductImgData()
                    {
                        Url = img.Url,
                    }).ToList(),
                    Price = product.Price,
                    Status = ProductStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                db.Products.Add(newProduct);
                db.SaveChanges();

                return newProduct;
            } 
        }

        public ProductData? ExecuteUpdateProductAction(int id, ProductCreateDto product)
        {
            using (var db = new AppDbContext())
            {
                var existingProduct = db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.Description)
                    .FirstOrDefault(p => p.Id == id);

                if (existingProduct == null)
                {
                    return null;
                }

                existingProduct.Name = product.Name;
                existingProduct.Description.Description = product.Description.Description;
                //existingProduct.Category = product.Category;
                //existingProduct.SubCategory = product.SubCategory;
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
            using (var db = new AppDbContext())
            {
                var product = db.Products
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return false;
                }

                product.Status = ProductStatus.Inactive;
                db.SaveChanges();

                return true;
            }
        }
    }
}