using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Product
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        public ProductCategory Name { get; set; }

        public string SubCategory { get; set; }
    }
}
