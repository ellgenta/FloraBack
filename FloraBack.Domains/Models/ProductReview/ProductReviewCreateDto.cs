using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.ProductReview
{
    public class ProductReviewCreateDto
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(300)]
        public string Content { get; set; }

        public ReviewMark Mark { get; set; }
    }
}
