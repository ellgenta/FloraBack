using FloraBack.Domains.Models.ProductReview;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IProductReviewActions
    {
        public ProductReviewInfoDto CreateProductReviewAction(ProductReviewCreateDto review);
        public List<ProductReviewInfoDto> GetAllProductReviewsAction();
        public List<ProductReviewInfoDto> GetProductReviewsByProductIdAction(int productId);
        public bool DeleteProductReviewAction(int id);
    }
}