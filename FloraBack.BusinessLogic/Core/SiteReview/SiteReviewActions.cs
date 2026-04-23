using System;
using FloraBack.Domains.Entities.SiteReview;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.SiteReview
{
    public class SiteReviewActions 
    {
        List<SiteReviewData> _SiteReviewRepo = new List<SiteReviewData>();

        int nextId = 1;

        public SiteReviewData ExecuteCreateSiteReviewAction(SiteReviewData review)
        {
            var _newReview = new SiteReviewData()
            {
                Id = nextId++,
                UserId = review.UserId,
                Content = review.Content,
                Mark = review.Mark,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return _newReview;
        }
    }
}
