using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;
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

        [HttpGet("getById")]
         public IActionResult GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product id");
            }

            var product = _product.GetProductByIdAction(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpGet("getByCategory/{category}")]
        public IActionResult GetProductsByCategory(ProductCategory category)
        {
            var products = _product.GetProductsByCategoryAction(category);
            return Ok(products);
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Product name is required");
            }

            var createdProduct = _product.CreateProductAction(product);

            return Created($"/api/product/getById/{createdProduct.Id}", createdProduct);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Product name is required");
            }
            var updatedProduct = _product.UpdateProductAction(id, product);

            if (updatedProduct == null)
            {
                return NotFound("Product not found");
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _product.DeleteProductAction(id);

            if (!deleted)
            {
                return NotFound("Product not found");
            }

            return NoContent();
        }
    }
}
