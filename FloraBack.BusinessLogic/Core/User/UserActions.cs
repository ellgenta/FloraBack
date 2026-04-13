using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;

namespace FloraBack.BusinessLogic.Core.User
{
    public class UserActions
    {
        public List<UserData> ExecuteGetAllUsersAction()
        {
            var _users = new List<UserData>();

            var _user1 = new UserData
            {
                Id = 1,
                UserName = "Test 1",
                Password = "password1",
                Email = "test1@example.com",
                DOB = DateTime.Now,
                Gender = GenderTypes.Other
            };

            var _user2 = new UserData
            {
                Id = 2,
                UserName = "Test 2",
                Password = "password2",
                Email = "test2@example.com",
                DOB = DateTime.Now,
                Gender = GenderTypes.Other
            };

            _users.Add(_user1);
            _users.Add(_user2);

            return _users;
        }
    }
}
