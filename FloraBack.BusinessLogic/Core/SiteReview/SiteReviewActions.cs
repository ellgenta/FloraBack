using System;
using FloraBack.Domains.Entities.SiteReview;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.SiteReview
{
    public class SiteReviewActions 
    {
        public SiteReviewData ExecuteCreateSiteReviewAction(SiteReviewData review)
        {
            var _newReview = new SiteReviewData()
            {
                UserId = review.UserId,
                Content = review.Content,
                Mark = review.Mark,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            using (var db = new SiteReviewContext())
            {
                db.SiteReviews.Add(_newReview);
                db.SaveChanges();
            }

            return _newReview;
        }

        public List<SiteReviewData> ExecuteGetAllSiteReviewsAction()
        {
            var _SiteReviewRepo = new List<SiteReviewData>();
            
            using (var db = new SiteReviewContext())
            {
                _SiteReviewRepo =  db.SiteReviews.Include(s => s.User).ToList();
            }

            return _SiteReviewRepo;
        }

        
        public bool ExecuteDeleteSiteReviewAction(int id)
        {
            SiteReviewData _review;

            using (var db = new SiteReviewContext())
            {
                _review = db.SiteReviews.FirstOrDefault(x => x.Id == id);

                if (_review != null)
                {
                    db.SiteReviews.Remove(_review);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }
        
    }
}
