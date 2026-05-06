using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Entities.ProductReview
{
    public class ProductReviewData : SharedFields
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }


        [Required]
        [StringLength(300)]
        public string Content { get; set; }
        public ReviewMark Mark { get; set; }
    }
}