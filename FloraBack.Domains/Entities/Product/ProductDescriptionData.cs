using System.ComponentModel.DataAnnotations;

namespace FloraBack.Domains.Entities.Product
{
    public class ProductDescriptionData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public DescriptionAdvanced DescriptionAdvanced { get; set; }
    }
}