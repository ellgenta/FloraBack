using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Product
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ProductDescriptionCreateDto Description { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue)]
        public int SubCategoryId { get; set; }

        public List<ProductImgCreateDto> Images { get; set; } = new();

        public decimal Price { get; set; }
    }
}