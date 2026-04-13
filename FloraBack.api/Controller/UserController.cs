using Microsoft.AspNetCore.Mvc;
using FloraBack.Domains.Entities.User;
using FloraBack.BusinessLogic.Interface;

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
            UserData? _user = _userActions.GetUserByIdAction(id);

            if (_user != null)
            {
                return Ok(_user);
            }

            return NotFound(_user);
        }
    }
}
