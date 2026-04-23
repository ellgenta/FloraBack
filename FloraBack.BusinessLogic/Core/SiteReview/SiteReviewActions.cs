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
        static List<SiteReviewData> _SiteReviewRepo = new List<SiteReviewData>();

        static int nextId = 1;

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

            _SiteReviewRepo.Add(_newReview);

            return _newReview;
        }

        public List<SiteReviewData> ExecuteGetAllSiteReviewsAction()
        {
            return _SiteReviewRepo;
        }

        public bool ExecuteDeleteSiteReviewAction(int id)
        {
            var _review = _SiteReviewRepo.FirstOrDefault(x => x.Id == id);

            if (_review != null)
            {
                _SiteReviewRepo.Remove(_review);
                return true;
            }

            return false;
        }
    }
}
