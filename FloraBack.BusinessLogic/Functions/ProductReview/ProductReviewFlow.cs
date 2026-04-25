using FloraBack.BusinessLogic.Core.ProductReview;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Functions.ProductReview
{
    public class ProductReviewFlow : ProductReviewActions, IProductReviewActions
    {
        public ProductReviewDto CreateProductReviewAction(ProductReviewData review)
        {
            var _newReview = ExecuteCreateProductReviewAction(review);

            var _reviewDto = new ProductReviewDto()
            {
                Id = _newReview.Id,
                UserId = _newReview.UserId,
                ProductId = _newReview.ProductId,
                Content = _newReview.Content,
                Mark = _newReview.Mark,
            };

            return _reviewDto;
        }
    }
}