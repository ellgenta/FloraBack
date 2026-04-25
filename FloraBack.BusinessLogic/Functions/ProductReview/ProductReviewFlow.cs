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

        public List<ProductReviewDto> GetProductReviewsByProductIdAction(int productId)
        {
            var _reviews = ExecuteGetProductReviewsByProductIdAction(productId);

            var _DtoList = new List<ProductReviewDto>();

            foreach (var _review in _reviews)
            {
                var _reviewDto = new ProductReviewDto()
                {
                    Id = _review.Id,
                    UserId = _review.UserId,
                    ProductId = _review.ProductId,
                    Content = _review.Content,
                    Mark = _review.Mark,
                };

                _DtoList.Add(_reviewDto);
            }

            return _DtoList;
        }

        public bool DeleteProductReviewAction(int id)
        {
            var wasDeleted = ExecuteDeleteProductReviewAction(id);

            return wasDeleted;
        }
    }
}