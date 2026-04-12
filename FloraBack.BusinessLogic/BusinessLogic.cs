using FloraBack.BusinessLogic.Functions.Auth;
using FloraBack.BusinessLogic.Functions.Products;
using FloraBack.BusinessLogic.Functions.User;
using FloraBack.BusinessLogic.Interface;

namespace FloraBack.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }
        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public IProduct GetProductActions()
        {
            return new ProductFlow();
        }

        public IUserActions GetUserActions()
        {
            return new UserFlow();
        }
    }
}

