using FloraBack.BusinessLogic.Core.Category;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryActions _categoryActions;

        public CategoryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _categoryActions = bl.GetCategoryActions();
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory([FromBody] CategoryCreateDto category)
        {
            var _createdCategory = _categoryActions.CreateCategoryAction(category);

            return CreatedAtAction(nameof(GetCategoryById), new { id = _createdCategory.Id }, _createdCategory);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAllCategories()
        {
            var _categories = _categoryActions.GetAllCategoriesAction();

            return Ok(_categories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetCategoryById(int id)
        {
            var _category = _categoryActions.GetCategoryByIdAction(id);

            if (_category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(_category);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryCreateDto category)
        {
            var _updatedCategory = _categoryActions.UpdateCategoryAction(id, category);

            if (_updatedCategory == null)
            {
                return NotFound("Category not found");
            }

            return Ok(_updatedCategory);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            var _isDeleted = _categoryActions.DeleteCategoryAction(id);

            if (!_isDeleted)
            {
                return BadRequest("Category was not deleted. It may not exist or may contain subcategories/products.");
            }

            return Ok("Category deleted successfully");
        }
    }
}