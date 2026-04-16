using FloraBack.Domains.Entities.User;
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
        public bool ValidateLogin(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) && string.IsNullOrEmpty(data.Password))
            {
                return false;
            }
            return true;
        }

        public string? GenToken(UserAuthAction data)
        {
            return "TOKEN";
        }
    }
}
