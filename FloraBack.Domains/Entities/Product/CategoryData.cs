using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.Product
{
    public class CategoryData
    {
        public int Id { get; set; }
        public ProductCategory Name { get; set; }
        public List<string> SubCategories { get; set; }
    }
}
