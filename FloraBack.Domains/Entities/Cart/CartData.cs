using System.Collections.Generic;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Entities.Cart
{
    public class CartData : SharedFields
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice { get; set; }
        public CartStatus Status { get; set; }
    }
}