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
            var _user = _DataRepo.FirstOrDefault(x => x.Id == id);

            return _user;
        }

        public UserData? ExecuteCreateUserAction(UserData user)
        {
            var _user = _DataRepo.FirstOrDefault(x => user.Email.Equals(x.Email));
            
            if (_user != null)
            {
                return null;
            }

            var _newUser = new UserData()
            {
                Id = _nextId++,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                DefaultAddress = user.DefaultAddress,
                DefaultPaymentMethod = user.DefaultPaymentMethod,
                DOB = user.DOB,
                Gender = user.Gender,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = user.IsActive,
            };

            _DataRepo.Add(_newUser);

            return _newUser;
        }

        public bool ExecuteDeleteUserAction(int id)
        {
            var _user = _DataRepo.FirstOrDefault(x => x.Id == id);

            if (_user != null)
            {
                _DataRepo.Remove(_user);
                return true;
            }

            return false;
        }

        public UserData? ExecuteUpdateUserAction(int id, UserData user)
        {
            var _user = _DataRepo.FirstOrDefault(x => x.Id == id);

            if (_user != null) // || _user.IsActive == false
            {
                _user.UserName = user.UserName;
                _user.Email = user.Email;
                _user.DefaultAddress = user.DefaultAddress;
                _user.DefaultPaymentMethod = user.DefaultPaymentMethod;
                _user.UpdatedAt = DateTime.Now;
                return _user;
            }

            return null;
        }
    }
}
