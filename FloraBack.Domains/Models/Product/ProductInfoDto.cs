using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Models.Product
{
    public class ProductInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductDescriptionInfoDto Description { get; set; }

        public ProductCategoryDto Category { get; set; }

        public string SubCategory { get; set; }

        public List<ProductImgInfoDto> Images { get; set; }

        public decimal Price { get; set; }

        public ProductStatus Status { get; set; }
    }
}
