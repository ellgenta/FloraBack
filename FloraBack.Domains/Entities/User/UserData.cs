using FloraBack.Domains.Enums;
using FloraBack.Domains.Entities.Refs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Address;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FloraBack.Domains.Entities.Order;
using System.Text.Json.Serialization;
using FloraBack.Domains.Entities.SiteReview;

namespace FloraBack.Domains.Entities.User
{
    public class UserData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        [EmailAddress]
        public string Email { get; set; }

        public AddressData DefaultAddress { get; set; }

        public PaymentMethods DefaultPaymentMethod { get; set; }

        public DateTime DOB { get; set; }

        public GenderTypes Gender { get; set; }

        [JsonIgnore]
        public List<OrderData>? Orders { get; set; }

        [JsonIgnore]
        public SiteReviewData? SiteReview { get; set; }

        public bool IsActive { get; set; } //unhandled yet for the GET operation
    }
}
