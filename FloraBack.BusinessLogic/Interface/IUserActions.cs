using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IUserActions
    {
        List<UserDto> GetAllUsersAction();

        UserDto? GetUserByIdAction(int id);

        UserDto? CreateUserAction(UserData user);

        bool DeleteUserAction(int id);
    }
}
