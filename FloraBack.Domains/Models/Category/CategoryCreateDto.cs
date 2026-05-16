using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}