using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProductReviewActions
    {
        public ProductReviewDto CreateProductReviewAction(ProductReviewDto review);
        public List<ProductReviewDto> GetProductReviewsByProductIdAction(int productId);
        public bool DeleteProductReviewAction(int id);
    }
}