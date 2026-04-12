using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.User;

namespace FloraBack.BusinessLogic.Core.User
{
    public class UserActions
    {
        public List<UserData> ExecuteGetAllUsersAction()
        {
            var _users = new List<UserData>();
            return _users;
        }
    }
}
