using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Product
{
    public class ProductDescriptionInfoDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }
    }
}
