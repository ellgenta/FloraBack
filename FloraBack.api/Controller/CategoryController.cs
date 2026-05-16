using BusinessLogicFactory = FloraBack.BusinessLogic.BusinessLogic;
using FloraBack.Domains.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BusinessLogicFactory _businessLogic;

        public CategoryController()
        {
            _businessLogic = new BusinessLogicFactory();
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] CategoryCreateDto category)
        {
            var _createdCategory = _businessLogic
                .GetCategoryActions()
                .CreateCategory(category);

            return CreatedAtAction(nameof(GetCategoryById), new { id = _createdCategory.Id }, _createdCategory);
        }

        [HttpGet("all")]
        public IActionResult GetAllCategories()
        {
            var _categories = _businessLogic
                .GetCategoryActions()
                .GetAllCategories();

            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var _category = _businessLogic
                .GetCategoryActions()
                .GetCategoryById(id);

            if (_category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(_category);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryCreateDto category)
        {
            var _updatedCategory = _businessLogic
                .GetCategoryActions()
                .UpdateCategory(id, category);

            if (_updatedCategory == null)
            {
                return NotFound("Category not found");
            }

            return Ok(_updatedCategory);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var _isDeleted = _businessLogic
                .GetCategoryActions()
                .DeleteCategory(id);

            if (!_isDeleted)
            {
                return BadRequest("Category was not deleted. It may not exist or may contain subcategories/products.");
            }

            return Ok("Category deleted successfully");
        }
    }
}