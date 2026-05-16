using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.BusinessLogic.Core.Auth;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Base;
using FloraBack.Domains.Models.Auth;
using FloraBack.Domains.Models.User;

namespace FloraBack.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponseAction UserRegisterAction(UserRegisterData data)
        {
            var user = ExecuteUserRegisterAction(data);

            if (user == null)
            {
                return new ResponseAction
                {
                    IsSuccess = false,
                    Message = "User with this Username or Email already exists"
                };
            }

            return new ResponseAction
            {
                IsSuccess = true,
                Message = "Successly registered",
                Id = user.Id
            };
        }

        public ResponseAction UserLoginAction(UserLoginData auth)
        {
            var user = ExecuteUserLoginAction(auth);

            if (user == null)
            {
                return new ResponseAction
                {
                    IsSuccess = false,
                    Message = "Invalid username or password"
                };
            }

            var token = GenerateUserToken(user);

            return new ResponseAction
            {
                IsSuccess = true,
                Message = token,
                Id = user.Id
            };
        }
    }
}
