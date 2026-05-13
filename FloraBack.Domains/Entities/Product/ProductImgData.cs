using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductImgData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Url { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }
    }
}