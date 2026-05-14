using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;
using FloraBack.DataAccess.Context;


namespace FloraBack.BusinessLogic.Core.ProductReview
{
    public class ProductReviewActions
    {
        public ProductReviewData ExecuteCreateProductReviewAction(ProductReviewData review)
        {
            var _newReview = new ProductReviewData()
            {
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Content,
                Mark = review.Mark,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            using (var db = new AppDbContext())
            {
                db.ProductReviews.Add(_newReview);
                db.SaveChanges();
            }

            return _newReview;
        }

        public List<ProductReviewData> ExecuteGetAllProductReviewsAction()
        {
            using (var db = new AppDbContext())
            {
                return db.ProductReviews.ToList();
            }
        }

        public List<ProductReviewData> ExecuteGetProductReviewsByProductIdAction(int productId)
        {
            var _productReviews = new List<ProductReviewData>();

            using (var db = new AppDbContext())
            {
                _productReviews = db.ProductReviews
                    .Where(r => r.ProductId == productId)
                    .ToList();
            }

            return _productReviews;
        }

        public bool ExecuteDeleteProductReviewAction(int id)
        {
            ProductReviewData _reviewToDelete;

            using (var db = new AppDbContext())
            {
                _reviewToDelete = db.ProductReviews.FirstOrDefault(r => r.Id == id);

                if (_reviewToDelete != null)
                {
                    db.ProductReviews.Remove(_reviewToDelete);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}