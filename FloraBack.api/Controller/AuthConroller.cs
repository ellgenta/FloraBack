using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    public class AuthConroller : ControllerBase
    {
        public IAuthActions _authActions;

        public AuthConroller()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _authActions = bl.GetAuthActions();
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { Message = "Session is active" });
        }

        [HttpPost]
        public IActionResult PostStatus([FromBody] UserAuthAction data)
        {
            var _authStatus = _authActions.LoginActionFlow(data);
            string token = "";
            return Ok(token);
        }
    }
}
