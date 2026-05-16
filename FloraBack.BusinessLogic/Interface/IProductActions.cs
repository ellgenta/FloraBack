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
        List<ProductInfoDto> GetAllProductsAction();
        ProductInfoDto? GetProductByIdAction(int id);
        List<ProductInfoDto> GetProductsByCategoryAction(ProductCategory category);
        List<ProductInfoDto> GetProductsBySubCategoryAction(string subCategory);
        ProductInfoDto CreateProductAction(ProductCreateDto product);
        ProductInfoDto? UpdateProductAction(int id, ProductCreateDto product);
        bool DeleteProductAction(int id);
    }
}
