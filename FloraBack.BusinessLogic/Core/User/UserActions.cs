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
        static List<UserDto> _DtoRepo = new List<UserDto>();
        public List<UserDto> ExecuteGetAllUsersAction()
        {
            return _DtoRepo;
        }

        public UserDto? ExecuteGetUserByIdAction(int id)
        {
            foreach (var _user in _DtoRepo)
            {
                if(_user.Id == id)
                {
                    return _user;
                }
            }

            return null;
        }

        public UserDto? ExecuteCreateUserAction(UserData user)
        {
            foreach (var _user in _DtoRepo)
            {
                if (user.Id == _user.Id || user.Email.Equals(_user.Email))
                {
                    return null;
                }
            }

            var user3Dto = new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
            };

            _DtoRepo.Add(user3Dto);

            return user3Dto;
        }

        public bool ExecuteDeleteUserAction(int id)
        {
            foreach (var _user in _DtoRepo)
            {
                if (_user.Id == id)
                {
                    _DtoRepo.Remove(_user);
                    return true;
                }
            }

            return false;
        }

        public UserDto? ExecuteUpdateUserAction(int id, UserData user)
        {
            foreach (var _user in _DtoRepo)
            {
                if (_user.Id == id)
                {
                    _user.UserName = user.UserName;
                    _user.Email = user.Email;
                    return _user;
                }
            }

            return null;
        }
    }
}
