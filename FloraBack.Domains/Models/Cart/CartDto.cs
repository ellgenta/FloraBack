using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Models.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice { get; set; }
        public CartStatus Status { get; set; }
    }
}