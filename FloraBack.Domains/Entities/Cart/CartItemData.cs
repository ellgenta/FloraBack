using FloraBack.Domains.Entities.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraBack.Domains.Entities.Cart
{
    public class CartItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}