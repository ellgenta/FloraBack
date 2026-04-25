using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProductReviewActions
    {
        public ProductReviewDto CreateProductReviewAction(ProductReviewData review);
        public List<ProductReviewDto> GetProductReviewsByProductIdAction(int productId);

    }
}