using FloraBack.Domains.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Product
{
    public class ProductImgCreateDto
    {
        [Required]
        [StringLength(300)]
        public string Url { get; set; }
    }
}
