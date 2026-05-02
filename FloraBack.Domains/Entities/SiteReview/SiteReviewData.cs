using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.SiteReview
{
    public class SiteReviewData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserData User { get; set; }

        public string Content { get; set; }

        public ReviewMark Mark { get; set; }
    }
}
