using FloraBack.Domains.Entities.SiteReview;
using FloraBack.Domains.Models.SiteReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ISiteReviewActions
    {
        public SiteReviewDto CreateSiteReviewAction(SiteReviewData review);
    }
}
