using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Order
{
    public class OrderInfoDto
    {
        public int Id { get; set; }

        public UserData User { get; set; }

        public int UserId { get; set; }

        public List<OrderItemInfoDto> Items { get; set; }

        public decimal TotalPrice { get; set; }

        public AddressData DeliveryAddress { get; set; }

        public OrderStatus Status { get; set; }
    }
}
