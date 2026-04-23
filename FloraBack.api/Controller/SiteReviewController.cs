using FloraBack.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/review/site")]
    [ApiController]

    public class SiteReviewController : ControllerBase
    {
        private ISiteReviewActions _siteReviewActions;
    }
}
