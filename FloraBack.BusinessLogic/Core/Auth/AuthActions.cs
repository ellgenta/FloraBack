using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Models.User;

namespace FloraBack.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        
        public bool ValidateLogin(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) && string.IsNullOrEmpty(data.Password))
                return false;
            return true;
        }
        
    }
}
