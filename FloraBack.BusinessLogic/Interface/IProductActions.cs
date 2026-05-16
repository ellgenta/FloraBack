using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProductActions
    {
        List<ProductCreateDto> GetAllProductsAction();
        ProductCreateDto? GetProductByIdAction(int id);
        List<ProductCreateDto> GetProductsByCategoryAction(ProductCategory category);
        List<ProductCreateDto> GetProductsBySubCategoryAction(string subCategory);
        ProductCreateDto CreateProductAction(ProductCreateDto product);
        ProductCreateDto? UpdateProductAction(int id, ProductCreateDto product);
        bool DeleteProductAction(int id);
    }
}
