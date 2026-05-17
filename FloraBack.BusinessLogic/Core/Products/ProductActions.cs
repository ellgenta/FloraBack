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
                    .Include(p => p.SubCategory)
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
                    .Include(p => p.SubCategory)
                    .Include(p => p.Description)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public List<ProductData> ExecuteGetProductsByCategoryAction(int categoryId)
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Description)
                    .Where(p => p.CategoryId == categoryId)
                    .ToList();
            }
        }

        public List<ProductData> ExecuteGetProductsBySubCategoryAction(int subCategoryId)
        {
            using (var db = new AppDbContext())
            {
                return db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Description)
                    .Where(p => p.SubCategoryId == subCategoryId)
                    .ToList();
            }
        }

        public ProductData? ExecuteCreateProductAction(ProductCreateDto product)
        {
            using (var db = new AppDbContext())
            {
                var categoryExists = db.Categories.Any(c => c.Id == product.CategoryId);

                if (!categoryExists)
                {
                    return null;
                }

                var subCategoryExists = db.SubCategories
                   .Any(sc => sc.Id == product.SubCategoryId && sc.CategoryId == product.CategoryId);

                if (!subCategoryExists)
                {
                    return null;
                }

                var newProduct = new ProductData()
                {
                    Name = product.Name,
                    Description = new ProductDescriptionData()
                    {
                        Description = product.Description.Description
                    },
                    CategoryId = product.CategoryId,
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

                return ExecuteGetProductByIdAction(newProduct.Id);
            }
        }
        public ProductData? ExecuteUpdateProductAction(int id, ProductCreateDto product)
        {
            using (var db = new AppDbContext())
            {
                var existingProduct = db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Description)
                    .FirstOrDefault(p => p.Id == id);

                if (existingProduct == null)
                {
                    return null;
                }

                var categoryExists = db.Categories.Any(c => c.Id == product.CategoryId);

                if (!categoryExists)
                {
                    return null;
                }

                var subCategoryExists = db.SubCategories
                    .Any(sc => sc.Id == product.SubCategoryId && sc.CategoryId == product.CategoryId);

                if (!subCategoryExists)
                {
                    return null;
                }
                existingProduct.Name = product.Name;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.SubCategoryId = product.SubCategoryId;
                existingProduct.Price = product.Price;
                existingProduct.UpdatedAt = DateTime.Now;

                if (existingProduct.Description == null)
                {
                    existingProduct.Description = new ProductDescriptionData();
                }

                existingProduct.Description.Description = product.Description.Description;

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

                return ExecuteGetProductByIdAction(existingProduct.Id);
            }
        }

        public List<ProductData> ExecuteGetProductsByFilterAction(ProductFilterDto filter)
        {
            using (var db = new AppDbContext())
            {
                var query = db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Description)
                    .AsQueryable();

                if (filter.SubCategoryIds != null && filter.SubCategoryIds.Count > 0)
                {
                    query = query.Where(p => filter.SubCategoryIds.Contains(p.SubCategoryId));
                }
                else if (filter.CategoryIds != null && filter.CategoryIds.Count > 0)
                {
                    query = query.Where(p => filter.CategoryIds.Contains(p.CategoryId));
                }

                return query.ToList();
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
                product.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }
    }
}