using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.DataAccess.Context;
using FloraBack.BusinessLogic.Structure;

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

            var passwordHash = PasswordHasher.Hash(data.Password);

            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => (u.UserName == data.Login || u.Email == data.Login) && u.Password == passwordHash);
            }
        }

        public string? GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.UserName, user.Role.ToString());
        }
    }
}
