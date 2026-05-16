using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Product
{
    public class SubCategoryCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}