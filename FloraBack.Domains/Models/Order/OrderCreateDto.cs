using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Order
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        public AddressData DeliveryAddress { get; set; }
    }
}
