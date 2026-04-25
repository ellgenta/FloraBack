using FloraBack.Domains.Entities.ProductReview;

namespace FloraBack.BusinessLogic.Core.ProductReview
{
    public class ProductReviewActions
    {
        static List<ProductReviewData> _ProductReviewRepo = new List<ProductReviewData>();

        static int nextId = 1;

        public ProductReviewData ExecuteCreateProductReviewAction(ProductReviewData review)
        {
            var _newReview = new ProductReviewData()
            {
                Id = nextId++,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Content,
                Mark = review.Mark,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            _ProductReviewRepo.Add(_newReview);

            return _newReview;
        }

    }
}