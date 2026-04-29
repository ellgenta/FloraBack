using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.Order
{
    public class OrderData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal TotalPrice { get; set; }

        public AddressData DeliveryAddress { get; set; }

        public OrderStatus Status { get; set; }
    }
}
