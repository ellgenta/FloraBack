using FloraBack.BusinessLogic.Core.User;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Functions.User
{
    public class UserFlow : UserActions, IUserActions
    {
        public List<UserDto> GetAllUsersAction()
        {
            var _users = ExecuteGetAllUsersAction();
            return _users;
        }

        public UserDto? GetUserByIdAction(int id)
        {
            var _user = ExecuteGetUserByIdAction(id);
            return _user;
        }

        public UserDto? CreateUserAction(UserData User)
        {
            var _user = ExecuteCreateUserAction(User);
            return _user;
        }

        public bool DeleteUserAction(int id)
        {
            var wasDeleted = ExecuteDeleteUserAction(id);
            return wasDeleted;
        }

        public UserDto? UpdateUserAction(int id, UserData user)
        {
            var _user = ExecuteUpdateUserAction(id, user);
            return _user;
        }
    }
}
