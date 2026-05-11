using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;

namespace FloraBack.Domains.Entities.Cart
{
    public class CartData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserData User { get; set; }

        public List<CartItemData> Items { get; set; } = new List<CartItemData>();

        public decimal TotalPrice { get; set; }

        public CartStatus Status { get; set; }
    }
}