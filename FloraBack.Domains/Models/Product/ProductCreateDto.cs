using FloraBack.Domains.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Product
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ProductDescriptionCreateDto Description { get; set; }

        public ProductCategoryDto Category { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SubCategory { get; set; }

        public List<ProductImgInfoDto> Images { get; set; } = new();

        public decimal Price { get; set; }
    }
}