using BusinessLogicFactory = FloraBack.BusinessLogic.BusinessLogic;
using FloraBack.Domains.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly BusinessLogicFactory _businessLogic;

        public SubCategoryController()
        {
            _businessLogic = new BusinessLogicFactory();
        }

        [HttpPost("create")]
        public IActionResult CreateSubCategory([FromBody] SubCategoryCreateDto subCategory)
        {
            var _createdSubCategory = _businessLogic
                .GetSubCategoryActions()
                .CreateSubCategory(subCategory);

            if (_createdSubCategory == null)
            {
                return BadRequest("Category not found");
            }

            return CreatedAtAction(nameof(GetSubCategoryById), new { id = _createdSubCategory.Id }, _createdSubCategory);
        }

        [HttpGet("all")]
        public IActionResult GetAllSubCategories()
        {
            var _subCategories = _businessLogic
                .GetSubCategoryActions()
                .GetAllSubCategories();

            return Ok(_subCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubCategoryById(int id)
        {
            var _subCategory = _businessLogic
                .GetSubCategoryActions()
                .GetSubCategoryById(id);

            if (_subCategory == null)
            {
                return NotFound("SubCategory not found");
            }

            return Ok(_subCategory);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetSubCategoriesByCategoryId(int categoryId)
        {
            var _subCategories = _businessLogic
                .GetSubCategoryActions()
                .GetSubCategoriesByCategoryId(categoryId);

            return Ok(_subCategories);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSubCategory(int id, [FromBody] SubCategoryCreateDto subCategory)
        {
            var _updatedSubCategory = _businessLogic
                .GetSubCategoryActions()
                .UpdateSubCategory(id, subCategory);

            if (_updatedSubCategory == null)
            {
                return BadRequest("SubCategory was not updated. It may not exist or category was not found.");
            }

            return Ok(_updatedSubCategory);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            var _isDeleted = _businessLogic
                .GetSubCategoryActions()
                .DeleteSubCategory(id);

            if (!_isDeleted)
            {
                return BadRequest("SubCategory was not deleted. It may not exist or may contain products.");
            }

            return Ok("SubCategory deleted successfully");
        }
    }
}