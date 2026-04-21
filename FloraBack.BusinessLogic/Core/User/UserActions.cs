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
        static List<UserData> _DataRepo = new List<UserData>();

        static int _nextId = 1;

        public List<UserData> ExecuteGetAllUsersAction()
        {
            return _DataRepo;
        }

        public UserData? ExecuteGetUserByIdAction(int id)
        {
            foreach (var _user in _DataRepo)
            {
                if(_user.Id == id)
                {
                    return _user;
                }
            }

            return null;
        }

        public UserData? ExecuteCreateUserAction(UserData user)
        {
            foreach (var _user in _DataRepo)
            {
                if (user.Email.Equals(_user.Email))
                {
                    return null;
                }
            }

            var _newUser = new UserData()
            {
                Id = _nextId++,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                DefaultAddress = user.DefaultAddress,
                DefaultPM = user.DefaultPM,
                DOB = user.DOB,
                Gender = user.Gender,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            _DataRepo.Add(_newUser);

            return _newUser;
        }

        public bool ExecuteDeleteUserAction(int id)
        {
            foreach (var _user in _DataRepo)
            {
                if (_user.Id == id)
                {
                    _DataRepo.Remove(_user);
                    return true;
                }
            }

            return false;
        }

        public UserData? ExecuteUpdateUserAction(int id, UserData user)
        {
            foreach (var _user in _DataRepo)
            {
                if (_user.Id == id)
                {
                    _user.UserName = user.UserName;
                    _user.Email = user.Email;
                    _user.DefaultAddress = user.DefaultAddress;
                    _user.DefaultPM = user.DefaultPM;
                    _user.UpdatedAt = DateTime.Now;
                    return _user;
                }
            }

            return null;
        }
    }
}
