using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.api.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserActions _userActions;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userActions = bl.GetUserActions();
        }

        [HttpGet("all")]
        public IActionResult GetAllUser()
        {
            var _users = _userActions.GetAllUsersAction();
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var _user = _userActions.GetUserByIdAction(id);

            if (_user != null)
            {
                return Ok(_user);
            }

            return NotFound(new { Message = $"User with ID {id} not found" });
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserData user)
        {
            var _user = _userActions.CreateUserAction(user);

            if (_user != null)
            {
                return Ok(_user);
            }

            return Conflict(new { Message = $"User with ID {user.Id} or email {user.Email} already exists!" } ); 
        }
    }
}
