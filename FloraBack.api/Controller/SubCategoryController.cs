using FloraBack.BusinessLogic.Core.Category;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private ISubCategoryActions _subCategoryActions;

        public SubCategoryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _subCategoryActions = bl.GetSubCategoryActions();
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateSubCategory([FromBody] SubCategoryCreateDto subCategory)
        {
            var _createdSubCategory = _subCategoryActions.CreateSubCategoryAction(subCategory);

            if (_createdSubCategory == null)
            {
                return BadRequest("Category not found");
            }

            return CreatedAtAction(nameof(GetSubCategoryById), new { id = _createdSubCategory.Id }, _createdSubCategory);
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllSubCategories()
        {
            var _subCategories = _subCategoryActions.GetAllSubCategoriesAction();

            return Ok(_subCategories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetSubCategoryById(int id)
        {
            var _subCategory = _subCategoryActions.GetSubCategoryByIdAction(id);

            if (_subCategory == null)
            {
                return NotFound("SubCategory not found");
            }

            return Ok(_subCategory);
        }

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        public IActionResult GetSubCategoriesByCategoryId(int categoryId)
        {
            var _subCategories = _subCategoryActions.GetSubCategoriesByCategoryIdAction(categoryId);

            return Ok(_subCategories);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateSubCategory(int id, [FromBody] SubCategoryCreateDto subCategory)
        {
            var _updatedSubCategory = _subCategoryActions.UpdateSubCategoryAction(id, subCategory);

            if (_updatedSubCategory == null)
            {
                return BadRequest("SubCategory was not updated. It may not exist or category was not found.");
            }

            return Ok(_updatedSubCategory);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubCategory(int id)
        {
            var _isDeleted = _subCategoryActions.DeleteSubCategoryAction(id);

            if (!_isDeleted)
            {
                return BadRequest("SubCategory was not deleted. It may not exist or may contain products.");
            }

            return Ok("SubCategory deleted successfully");
        }
    }
}