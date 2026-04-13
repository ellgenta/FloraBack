using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.User
{
    public class UserActions
    {
        public List<UserDto> ExecuteGetAllUsersAction()
        {
            var _users = new List<UserDto>();

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

            var _user1Dto = new UserDto()
            {
                Id = _user1.Id,
                UserName = _user1.UserName,
                Email = _user1.Email,
                Gender = _user1.Gender,
            };

            var _user2Dto = new UserDto()
            {
                Id = _user2.Id,
                UserName = _user2.UserName,
                Email = _user2.Email,
                Gender = _user2.Gender,
            };

            _users.Add(_user1Dto);
            _users.Add(_user2Dto);

            return _users;
        }

        public UserDto? ExecuteGetUserByIdAction(int id)
        {
            var _users = new List<UserDto>();

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

            var _user1Dto = new UserDto()
            {
                Id = _user1.Id,
                UserName = _user1.UserName,
                Email = _user1.Email,
                Gender = _user1.Gender,
            };

            var _user2Dto = new UserDto()
            {
                Id = _user2.Id,
                UserName = _user2.UserName,
                Email = _user2.Email,
                Gender = _user2.Gender,
            };

            _users.Add(_user1Dto);
            _users.Add(_user2Dto);


            foreach (var user in _users)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
