using FloraBack.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.ProductReview
{
    public class ProductReviewDto
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