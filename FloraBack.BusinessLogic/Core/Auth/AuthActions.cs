using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.DataAccess.Context;

namespace FloraBack.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        public UserData? ExecuteValidateLogin(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) && string.IsNullOrEmpty(data.Password))
            {
                return null;
            }

            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => (u.UserName == data.Login || u.Email == data.Login) && u.Password == data.Password);
            }
        }

        public string? GenerateUserToken(UserData data)
        {
            return "TOKEN";
        }
    }
}
