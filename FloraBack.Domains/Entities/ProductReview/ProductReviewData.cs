using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Entities.ProductReview
{
    public class ProductReviewData : SharedFields
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public ReviewMark Mark { get; set; }
    }
}