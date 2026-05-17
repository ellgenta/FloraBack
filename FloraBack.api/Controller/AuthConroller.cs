using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Auth;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult UserLogin([FromBody] UserLoginData data)
        {
            var _authStatus = _authActions.UserLoginAction(data);
            if (!_authStatus.IsSuccess)
            {
                return Unauthorized(_authStatus.Message);
            }
            // Декодируй токен и посмотри userId
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(_authStatus.Message);
            var userId = jwt.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            return Ok(new { token = _authStatus.Message, debugUserId = userId });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult UserRegister([FromBody] UserRegisterData registerData)
        {
            var user = _authActions.UserRegisterAction(registerData);

            if (user == null)
            {
                return BadRequest(new { Message = "User registration failed" });
            }

            return Ok(user);

            //var token = _jwtTokenService.GenerateToken(user);

            //return Ok(new
            //{
            //    Token = token,
            //    User = user
            //});
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { Message = "Session is active" });
        }
    }
}
