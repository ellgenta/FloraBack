using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace FloraBack.Api.Controller
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductActions _product;

        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAllProductsAction();
            return Ok(products);
        }

        [HttpGet("getById")]
        [AllowAnonymous]
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

        [HttpGet("category/{category}")]
        [AllowAnonymous]
        public IActionResult GetProductsByCategory(ProductCategory category)
        {
            var products = _product.GetProductsByCategoryAction(category);
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategory}")]
        [AllowAnonymous]
        public IActionResult GetProductsBySubCategory(string subCategory)
        {
            var products = _product.GetProductsBySubCategoryAction(subCategory);
            return Ok(products);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductCreateDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }
            try
            {
                var createdProduct = _product.CreateProductAction(product);
                return Created($"/api/product/getById/{createdProduct.Id}", createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                    inner = ex.InnerException?.Message,
                    inner2 = ex.InnerException?.InnerException?.Message
                });
            }
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductCreateDto product)
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
        [Authorize(Roles = "Admin")]
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
