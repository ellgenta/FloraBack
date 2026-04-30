using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.Order
{
    public class OrderData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public UserData? User { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        public AddressData DeliveryAddress { get; set; }

        public OrderStatus Status { get; set; }
    }
}
