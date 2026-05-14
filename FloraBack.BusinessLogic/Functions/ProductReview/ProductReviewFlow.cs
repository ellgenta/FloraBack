using FloraBack.BusinessLogic.Core.ProductReview;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Functions.ProductReview
{
    public class ProductReviewFlow : ProductReviewActions, IProductReviewActions
    {
        public ProductReviewDto CreateProductReviewAction(ProductReviewDto review)
        {
            var reviewData = new ProductReviewData()
            {
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Content,
                Mark = review.Mark
            };

            var newReview = ExecuteCreateProductReviewAction(reviewData);

            return MapToDto(newReview);
        }

        public List<ProductReviewDto> GetAllProductReviewsAction()
        {
            var reviews = ExecuteGetAllProductReviewsAction();

            var dtoList = new List<ProductReviewDto>();

            foreach (var review in reviews)
            {
                dtoList.Add(MapToDto(review));
            }

            return dtoList;
        }

        public List<ProductReviewDto> GetProductReviewsByProductIdAction(int productId)
        {
            var reviews = ExecuteGetProductReviewsByProductIdAction(productId);

            var dtoList = new List<ProductReviewDto>();

            foreach (var review in reviews)
            {
                dtoList.Add(MapToDto(review));
            }

            return dtoList;
        }

        public bool DeleteProductReviewAction(int id)
        {
            return ExecuteDeleteProductReviewAction(id);
        }

        private ProductReviewDto MapToDto(ProductReviewData review)
        {
            return new ProductReviewDto()
            {
                Id = review.Id,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Content,
                Mark = review.Mark,
            };
        }
    }
}