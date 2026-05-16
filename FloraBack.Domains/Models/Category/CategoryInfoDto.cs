using FloraBack.Domains.Models.Product;
using System.Collections.Generic;

namespace FloraBack.Domains.Models.Category
{
    public class CategoryInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<SubCategoryInfoDto> SubCategories { get; set; } = new();
    }
}