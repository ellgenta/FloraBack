using FloraBack.Domains.Models.Auth;
using FloraBack.Domains.Models.Base;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IAuthActions
    {

        public ResponseAction UserRegisterAction(UserRegisterData data);

        public ResponseAction UserLoginAction(UserLoginData auth);
    }
}
