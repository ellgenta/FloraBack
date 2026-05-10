using FloraBack.Domains.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public ProductDescriptionData Description { get; set; }

        public CategoryData Category { get; set; }

        [Required]
        [StringLength(300)]
        public string SubCategory { get; set; }

        public List<ProductImgData> Images { get; set; }

        public decimal Price { get; set; }
    }
}