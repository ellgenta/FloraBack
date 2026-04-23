using FloraBack.BusinessLogic;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.SiteReview;
using FloraBack.Domains.Models.SiteReview;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/review/site")]
    [ApiController]
    public class SiteReviewController : ControllerBase
    {
        private ISiteReviewActions _siteReviewActions;

        public SiteReviewController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _siteReviewActions = bl.GetSiteReviewActions();
        }

        [HttpPost]
        public IActionResult CreateSiteReview([FromBody] SiteReviewData review)
        {
            var _newReview = _siteReviewActions.CreateSiteReviewAction(review);

            return Created($"api/review/site{_newReview.Id}", _newReview);
        }
    }
}
