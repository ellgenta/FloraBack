using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductImgData
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}
