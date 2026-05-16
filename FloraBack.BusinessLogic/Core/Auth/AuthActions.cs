using FloraBack.BusinessLogic.Core.User;
using FloraBack.BusinessLogic.Structure;
using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.Auth;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        private readonly UserActions _userActions = new();

        public UserData? ExecuteUserRegisterAction(UserRegisterData registerData)
        {
            var _newUser = new UserCreateDto
            {
                UserName = registerData.UserName,
                Email = registerData.Email,
                Password = registerData.Password
            };

            var _user = _userActions.ExecuteCreateUserAction(_newUser);

            return _user;
        }

        public UserData? ExecuteUserLoginAction(UserLoginData data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
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
