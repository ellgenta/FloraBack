using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.BusinessLogic.Core.User;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.User;

namespace FloraBack.BusinessLogic.Functions.User
{
    public class UserFlow : UserActions, IUserActions
    {
        public List<UserData> GetAllUsersAction()
        {
            var _users = ExecuteGetAllUsersAction();
            return _users;
        }

        public UserData? GetUserByIdAction(int id)
        {
            UserData _user = ExecuteGetUserByIdAction(id);
            return _user;
        }
    }
}
