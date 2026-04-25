using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;

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


        public List<ProductReviewData> ExecuteGetProductReviewsByProductIdAction(int productId)
        {
            List<ProductReviewData> _productReviews = new List<ProductReviewData>();

            foreach (var _review in _ProductReviewRepo)
            {
                if (_review.ProductId == productId)
                {
                    _productReviews.Add(_review);
                }
            }

            return _productReviews;
        }

        public bool ExecuteDeleteProductReviewAction(int id)
        {
            var _reviewToDelete = _ProductReviewRepo.FirstOrDefault(r => r.Id == id);

            if (_reviewToDelete != null)
            {
                _ProductReviewRepo.Remove(_reviewToDelete);
                return true;
            }

            return false;
        }
    }
}