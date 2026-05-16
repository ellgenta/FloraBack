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

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public List<ProductImgCreateDto> Images { get; set; } = new();

        public decimal Price { get; set; }
    }
}