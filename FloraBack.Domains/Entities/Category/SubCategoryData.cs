using FloraBack.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraBack.Domains.Entities.Category
{
    public class SubCategoryData : SharedFields   
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryData Category { get; set; }
    }
}