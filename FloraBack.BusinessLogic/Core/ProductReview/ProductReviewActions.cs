using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;
using FloraBack.DataAccess.Context;
using Microsoft.EntityFrameworkCore;


namespace FloraBack.BusinessLogic.Core.ProductReview
{
    public class ProductReviewActions
    {
        public ProductReviewData ExecuteCreateProductReviewAction(ProductReviewCreateDto review)
        {
            using (var db = new AppDbContext())
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
            
                db.ProductReviews.Add(_newReview);
                db.SaveChanges();

                return db.ProductReviews.Include(r => r.User).FirstOrDefault(r => r.Id == _newReview.Id)!;
            }
        }

        public List<ProductReviewData> ExecuteGetAllProductReviewsAction()
        {
            using (var db = new AppDbContext())
            {
                return db.ProductReviews.Include(p => p.User).ToList();
            }
        }

        public List<ProductReviewData> ExecuteGetProductReviewsByProductIdAction(int productId)
        {
            var _productReviews = new List<ProductReviewData>();

            using (var db = new AppDbContext())
            {
                _productReviews = db.ProductReviews
                    .Where(r => r.ProductId == productId).Include(p => p.User).ToList();
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