using FloraBack.Domains.Entities.Refs;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Entities.SiteReview
{
    public class SiteReview : SharedFields
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public ReviewNote Note { get; set; }
    }
}
