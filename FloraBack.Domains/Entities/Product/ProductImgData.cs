using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductImgData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Url { get; set; }

        public int ProductId { get; set; }
    }
}