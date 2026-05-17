using FloraBack.Domains.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Product
{
    public class ProductFilterDto
    {
        public List<int>? CategoryIds { get; set; }

        public List<int>? SubCategoryIds { get; set; }
    }
}
