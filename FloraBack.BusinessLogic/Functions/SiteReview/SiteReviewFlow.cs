using FloraBack.BusinessLogic.Core.SiteReview;
using FloraBack.Domains.Models.SiteReview;
using FloraBack.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.SiteReview;

namespace FloraBack.BusinessLogic.Functions.SiteReview
{
    public class SiteReviewFlow : SiteReviewActions, ISiteReviewActions
    {
        public SiteReviewDto CreateSiteReviewAction(SiteReviewData review)
        {
            var _newReview = ExecuteCreateSiteReviewAction(review);

            var _reviewDto = new SiteReviewDto()
            {
                Id = _newReview.Id,
                UserId = _newReview.UserId,
                Content = _newReview.Content,
                Mark = _newReview.Mark,
            };

            return _reviewDto;
        }
    }
}
