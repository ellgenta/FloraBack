using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FloraBack.Domains.Entities.ProductReview
{
    public class ProductReviewData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public UserData? User { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public ProductData? Product { get; set; }

        [Required]
        [StringLength(300)]
        public string Content { get; set; }

        public ReviewMark Mark { get; set; }
    }
}