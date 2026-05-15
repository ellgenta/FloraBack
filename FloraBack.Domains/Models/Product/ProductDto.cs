using FloraBack.Domains.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Models.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductDescriptionDto Description { get; set; }

        public ProductCategoryDto Category { get; set; }

        public string SubCategory { get; set; }

        public List<ProductImgDto> Images { get; set; }

        public decimal Price { get; set; }
    }
}