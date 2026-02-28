using FloraBack.BusinessLogic.Functions.Auth;
using FloraBack.BusinessLogic.Interface;

namespace eUShop.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }
        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

    }
}

