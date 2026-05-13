using FloraBack.Domains.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraBack.Domains.Entities.Product
{
    public class CategoryData
    {
        public int Id { get; set; }

        public ProductCategory Name { get; set; }

        [NotMapped]
        public List<string> SubCategories { get; set; }

        public List<ProductData> Products { get; set; }
    }
}