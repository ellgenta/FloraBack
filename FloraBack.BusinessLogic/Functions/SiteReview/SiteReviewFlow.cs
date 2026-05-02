using FloraBack.BusinessLogic.Core.SiteReview;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.SiteReview;
using FloraBack.Domains.Models.SiteReview;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Functions.SiteReview
{
    public class SiteReviewFlow : SiteReviewActions, ISiteReviewActions
    {
        public SiteReviewInfoDto CreateSiteReviewAction(SiteReviewCreateDto review)
        {
            var _newReview = ExecuteCreateSiteReviewAction(review);

            var _reviewDto = new SiteReviewInfoDto()
            {
                Id = _newReview.Id,
                UserId = _newReview.UserId,
                Content = _newReview.Content,
                Mark = _newReview.Mark,
            };

            return _reviewDto;
        }

        public List<SiteReviewInfoDto> GetAllSiteReviewsAction()
        {
            var _reviews = ExecuteGetAllSiteReviewsAction();

            var _DtoList = new List<SiteReviewInfoDto>();

            foreach (var _review in _reviews)
            {
                var _reviewDto = new SiteReviewInfoDto()
                {
                    Id = _review.Id,
                    UserId = _review.UserId,
                    Content = _review.Content,
                    Mark = _review.Mark,
                };

                _DtoList.Add(_reviewDto);
            }

            return _DtoList;
        }

        public bool DeleteSiteReviewAction(int id)
        {
            var wasDeleted = ExecuteDeleteSiteReviewAction(id);

            return wasDeleted;
        }
    }
}
