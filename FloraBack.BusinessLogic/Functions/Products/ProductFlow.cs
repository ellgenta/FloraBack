using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.BusinessLogic.Core.Products;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Product;

namespace FloraBack.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProduct
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var products = ExecuteGetAllProductsAction();
            return products;
        }
    }
}
