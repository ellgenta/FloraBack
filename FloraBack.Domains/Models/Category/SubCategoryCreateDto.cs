using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Category
{
    public class SubCategoryCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
    }
}