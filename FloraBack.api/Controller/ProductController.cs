using FloraBack.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _product;

        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAllProductsAction();
            return Ok(products);
        }
    }
}
