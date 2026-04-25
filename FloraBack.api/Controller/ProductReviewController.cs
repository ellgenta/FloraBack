using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.ProductReview;
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
        public IActionResult CreateProductReview([FromBody] ProductReviewData review)
        {
            var _newReview = _productReviewActions.CreateProductReviewAction(review);

            return Created($"api/review/product/{_newReview.Id}", _newReview);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductReviewsByProductId(int productId)
        {
            var _reviews = _productReviewActions.GetProductReviewsByProductIdAction(productId);

            return Ok(_reviews);
        }

        [HttpDelete("{id}")]
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