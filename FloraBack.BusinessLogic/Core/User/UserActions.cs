using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.User
{
    public class UserActions
    {
        public List<UserData> ExecuteGetAllUsersAction()
        {
            var _UserRepo = new List<UserData>();

            using (var db = new UserContext())
            {
                _UserRepo = db.Users.ToList();
            }

            return _UserRepo;
        }

        public UserData? ExecuteGetUserByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                var _user = db.Users.Include(u => u.Orders).Include(u => u.SiteReview).FirstOrDefault(x => x.Id == id);
                //maybe Where(x => x.IsActive == true)

                return _user;
            }
        }

        public UserData? ExecuteCreateUserAction(UserData user)
        {
            using (var db = new UserContext())
            {
                var _user = db.Users.FirstOrDefault(x => x.Email == user.Email);
                
                if (_user != null)
                {
                    return null;
                }

                var _newUser = new UserData()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    DefaultAddress = user.DefaultAddress,
                    DefaultPaymentMethod = user.DefaultPaymentMethod,
                    DOB = user.DOB,
                    Gender = user.Gender,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                };

                db.Users.Add(_newUser);
                db.SaveChanges();

                return _newUser;
            }
        }

        public bool ExecuteDeleteUserAction(int id)
        {
            using (var db = new UserContext())
            {
                var _user = db.Users.FirstOrDefault(x => x.Id == id && x.IsActive == true);

                if (_user == null)
                {
                    return false;
                }

                _user.IsActive = false;
                db.SaveChanges();

                return true;
            }
        }

        public UserData? ExecuteUpdateUserAction(int id, UserData user)
        {
            using (var db = new UserContext())
            {
                var _user = db.Users.FirstOrDefault(x => x.Id == user.Id && x.IsActive == true);

                if (_user == null || db.Users.Any(u => u.Email.Equals(user.Email) && u.Id != user.Id)) 
                {
                    return null;
                }

                _user.UserName = user.UserName;
                _user.Email = user.Email;
                _user.Password = user.Password;
                _user.DefaultAddress = user.DefaultAddress;
                _user.DefaultPaymentMethod = user.DefaultPaymentMethod;
                _user.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return _user;
            }
        }
    }
}
