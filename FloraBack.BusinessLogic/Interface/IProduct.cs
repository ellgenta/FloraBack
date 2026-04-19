using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProduct
    {
        List<ProductDto> GetAllProductsAction();
        ProductDto? GetProductByIdAction(int id);
        List<ProductDto> GetProductsByCategoryAction(ProductCategory category);
        ProductDto CreateProductAction(ProductDto product);
        ProductDto? UpdateProductAction(int id, ProductDto product);
        bool DeleteProductAction(int id);
    }
}
