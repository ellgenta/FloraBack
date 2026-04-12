using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.User;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IUserActions
    {
        List<UserData> GetAllUsersAction();
    }
}
