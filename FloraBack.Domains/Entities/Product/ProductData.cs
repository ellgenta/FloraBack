using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductData : SharedFields
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
        public ProductStatus Status { get; set; }
    }
}
