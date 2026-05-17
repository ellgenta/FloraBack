using FloraBack.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.ProductReview
{
    public class ProductReviewInfoDto
    {
        public int Id { get; set; }

        public string AuthorName { get; set; } 

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public ReviewMark Mark { get; set; }
    }
}