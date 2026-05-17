using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Product;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid category id");
            }

            var products = _product.GetProductsByCategoryAction(categoryId);
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategoryId}")]
        [AllowAnonymous]
        public IActionResult GetProductsBySubCategory(int subCategoryId)
        {
            if (subCategoryId <= 0)
            {
                return BadRequest("Invalid subcategory id");
            }

            var products = _product.GetProductsBySubCategoryAction(subCategoryId);
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductCreateDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            var createdProduct = _product.CreateProductAction(product);

            if (createdProduct == null)
            {
                return BadRequest("Category or subcategory not found");
            }

            return Created($"api/users{createdProduct.Id}", createdProduct);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductCreateDto product)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product id");
            }

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
                return BadRequest("Product not found or category/subcategory is invalid");
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product id");
            }

            var deleted = _product.DeleteProductAction(id);

            if (!deleted)
            {
                return NotFound("Product not found");
            }

            return NoContent();
        }
    }
}