using FloraBack.BusinessLogic.Core.ProductReview;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Functions.ProductReview
{
    public class ProductReviewFlow : ProductReviewActions, IProductReviewActions
    {
        public ProductReviewInfoDto CreateProductReviewAction(ProductReviewCreateDto review)
        {
            var newReview = ExecuteCreateProductReviewAction(review);

            return MapToDto(newReview);
        }

        public List<ProductReviewInfoDto> GetAllProductReviewsAction()
        {
            var reviews = ExecuteGetAllProductReviewsAction();

            var dtoList = new List<ProductReviewInfoDto>();

            foreach (var review in reviews)
            {
                dtoList.Add(MapToDto(review));
            }

            return dtoList;
        }

        public List<ProductReviewInfoDto> GetProductReviewsByProductIdAction(int productId)
        {
            var reviews = ExecuteGetProductReviewsByProductIdAction(productId);

            var dtoList = new List<ProductReviewInfoDto>();

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

        private ProductReviewInfoDto MapToDto(ProductReviewData review)
        {
            return new ProductReviewInfoDto()
            {
                Id = review.Id,
                AuthorName = review.User.UserName,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Content,
                Mark = review.Mark,
            };
        }
    }
}