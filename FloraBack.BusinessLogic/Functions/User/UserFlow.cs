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

            List<UserDto> _DtoList = new List<UserDto>();

            foreach (var _user in _users)
            {
                var _userDto = new UserDto()
                {
                    Id = _user.Id,
                    UserName = _user.UserName,
                    Email = _user.Email,
                    Gender = _user.Gender,
                };

                _DtoList.Add(_userDto);
            }

            return _DtoList;
        }

        public UserDto? GetUserByIdAction(int id)
        {
            var _user = ExecuteGetUserByIdAction(id);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
            };

            return _userDto;
        }

        public UserDto? CreateUserAction(UserData User)
        {
            var _user = ExecuteCreateUserAction(User);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
            };

            return _userDto;
        }

        public bool DeleteUserAction(int id)
        {
            var wasDeleted = ExecuteDeleteUserAction(id);
            return wasDeleted;
        }

        public UserDto? UpdateUserAction(int id, UserData user)
        {
            var _user = ExecuteUpdateUserAction(id, user);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
            };

            return _userDto;
        }
    }
}
