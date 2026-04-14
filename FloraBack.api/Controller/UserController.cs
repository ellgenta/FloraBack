using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FloraBack.api.Controller
{
    [Route("api/users")]
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
                return Created($"api/users{_user.Id}", _user);
            }

            return Conflict(new { Message = $"User with ID {user.Id} or email {user.Email} already exists" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var wasDeleted = _userActions.DeleteUserAction(id);

            if (wasDeleted == true)
            {
                return NoContent();
            }

            return NotFound(new { Message = $"User with ID {id} not found" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserData user)
        {
            var _user = _userActions.UpdateUserAction(id, user);

            if (_user != null)
            {
                return Ok(_user);
            }

            return NotFound(new { Message = $"User with ID {id} not found" });
        }
    }
}
