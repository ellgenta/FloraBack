using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductDescriptionData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DescriptionAdvanced DescriptionAdvanced { get; set; }
    }
}
