using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;


namespace FloraBack.Domains.Entities.Category
{

    public class CategoryData : SharedFields

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public List<SubCategoryData> SubCategories { get; set; } = new();

        public List<ProductData> Products { get; set; } = new();
    }
}