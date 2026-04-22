using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        static List<ProductData> _DataRepo = new List<ProductData>();
        static int _nextId = 1;
        public List<ProductData> ExecuteGetAllProductsAction()
        {
            return _DataRepo;
        }

        public ProductData? ExecuteGetProductByIdAction(int id)
        {
            foreach (var _product in _DataRepo)
            {
                if (_product.Id == id)
                {
                    return _product;
                }
            }

            return null;
        }

        public List<ProductData> ExecuteGetProductsByCategoryAction(ProductCategory category)
        {
            var _products = new List<ProductData>();

            foreach (var _product in _DataRepo)
            {
                if (_product.Category != null && _product.Category.Name == category)
                {
                    _products.Add(_product);
                }
            }

            return _products;
        }

        public List<ProductData> ExecuteGetProductsBySubCategoryAction(string subCategory)
        {
            var _products = new List<ProductData>();

            foreach (var _product in _DataRepo) {
                if (_product.Category != null &&
                    _product.Category.SubCategories != null)
                {
                    foreach (var _subCategory in _product.Category.SubCategories)
                    {
                        if (_subCategory.Equals(subCategory, StringComparison.OrdinalIgnoreCase))
                        {
                            _products.Add(_product);
                            break;
                        }
                    }
                }
            }
            return _products;
        }


        public ProductData? ExecuteCreateProductAction(ProductData product)
        {
            var _newProduct = new ProductData()
            {
                Id = _nextId++,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Price = product.Price,
                Status = ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _DataRepo.Add(_newProduct);
            return _newProduct;
        }

        public ProductData? ExecuteUpdateProductAction(int id, ProductData product)
        {
            foreach (var _product in _DataRepo)
            {
                if (_product.Id == id)
                {
                    _product.Name = product.Name;
                    _product.Description = product.Description;
                    _product.Category = product.Category;
                    _product.Images = product.Images;
                    _product.Price = product.Price;
                    _product.Status = product.Status;
                    _product.UpdatedAt = DateTime.Now;

                    return _product;
                }
            }
            return null;
        }

        public bool ExecuteDeleteProductAction(int id)
        {
            foreach (var _product in _DataRepo)
            {
                if (_product.Id == id)
                {
                    _DataRepo.Remove(_product);
                    return true;
                }
            }
            return false;
        }
    }
}
