using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.ProductReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/review/product")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private IProductReviewActions _productReviewActions;

        public ProductReviewController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _productReviewActions = bl.GetProductReviewActions();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateProductReview([FromBody] ProductReviewCreateDto review)
        {
            var _newReview = _productReviewActions.CreateProductReviewAction(review);

            return Created($"api/review/product/{_newReview.Id}", _newReview);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAllProductReviews()
        {
            var reviews = _productReviewActions.GetAllProductReviewsAction();

            return Ok(reviews);
        }

        [HttpGet("{productId}")]
        [AllowAnonymous]
        public IActionResult GetProductReviewsByProductId(int productId)
        {
            var _reviews = _productReviewActions.GetProductReviewsByProductIdAction(productId);

            return Ok(_reviews);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProductReview(int id)
        {
            var wasDeleted = _productReviewActions.DeleteProductReviewAction(id);

            if (wasDeleted == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new { Message = $"Product Review with ID {id} not found" });
            }
        }
    }
}