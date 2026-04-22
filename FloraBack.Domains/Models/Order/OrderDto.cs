using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public AddressData DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
