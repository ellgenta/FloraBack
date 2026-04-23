using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.SiteReview
{
    public class SiteReviewData : SharedFields
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public ReviewMark Mark { get; set; }
    }
}
