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
        public List<UserInfoDto> GetAllUsersAction()
        {
            var _users = ExecuteGetAllUsersAction();

            List<UserInfoDto> _DtoList = new List<UserInfoDto>();

            foreach (var _user in _users)
            {
                var _userDto = new UserInfoDto()
                {
                    Id = _user.Id,
                    UserName = _user.UserName,
                    Email = _user.Email,
                    Gender = _user.Gender,
                    DefaultAddress = _user.DefaultAddress,
                    DefaultPaymentMethod = _user.DefaultPaymentMethod,
                    Role = _user.Role,
                };

                _DtoList.Add(_userDto);
            }

            return _DtoList;
        }

        public UserInfoDto? GetUserByIdAction(int id)
        {
            var _user = ExecuteGetUserByIdAction(id);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserInfoDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
                DefaultAddress = _user.DefaultAddress,
                DefaultPaymentMethod = _user.DefaultPaymentMethod,
                Role = _user.Role,
            };

            return _userDto;
        }

        public UserInfoDto? CreateUserAction(UserCreateDto User)
        {
            var _user = ExecuteCreateUserAction(User);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserInfoDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
                DefaultAddress = _user.DefaultAddress,
                DefaultPaymentMethod = _user.DefaultPaymentMethod,
                Role = _user.Role,
            };

            return _userDto;
        }

        public bool DeleteUserAction(int id)
        {
            var wasDeleted = ExecuteDeleteUserAction(id);
            return wasDeleted;
        }

        public UserInfoDto? UpdateUserAction(int id, UserCreateDto user)
        {
            var _user = ExecuteUpdateUserAction(id, user);

            if (_user == null)
            {
                return null;
            }

            var _userDto = new UserInfoDto()
            {
                Id = _user.Id,
                UserName = _user.UserName,
                Email = _user.Email,
                Gender = _user.Gender,
                DefaultAddress = _user.DefaultAddress,
                DefaultPaymentMethod = _user.DefaultPaymentMethod,
                Role = _user.Role,
            };

            return _userDto;
        }
    }
}
