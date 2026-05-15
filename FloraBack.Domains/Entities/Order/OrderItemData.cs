using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Product;

namespace FloraBack.Domains.Entities.Order
{
    public class OrderItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderData Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
