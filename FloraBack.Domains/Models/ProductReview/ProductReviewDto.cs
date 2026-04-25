using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Models.ProductReview
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public ReviewMark Mark { get; set; }
    }
}