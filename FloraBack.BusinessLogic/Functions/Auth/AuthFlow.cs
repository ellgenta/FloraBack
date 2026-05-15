using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.BusinessLogic.Core.Auth;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.User;
using FloraBack.Domains.Models.Base;

namespace FloraBack.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponseAction LoginActionFlow(UserAuthAction auth)
        {
            var user = ExecuteValidateLogin(auth);

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
