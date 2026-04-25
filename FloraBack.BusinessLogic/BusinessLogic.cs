using FloraBack.BusinessLogic.Functions.Auth;
using FloraBack.BusinessLogic.Functions.Products;
using FloraBack.BusinessLogic.Functions.User;
using FloraBack.BusinessLogic.Functions.Order;
using FloraBack.BusinessLogic.Interface;
using FloraBack.BusinessLogic.Functions.SiteReview;
using System.ComponentModel;
using FloraBack.BusinessLogic.Functions.Cart;
using FloraBack.BusinessLogic.Functions.ProductReview;

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

        public IOrderActions GetOrderActions()
        {
            return new OrderFlow();
        }

        public ISiteReviewActions GetSiteReviewActions()
        {
            return new SiteReviewFlow();
        }

        public ICart GetCartActions()
        {
            return new CartFlow();
        }

        public IProductReviewActions GetProductReviewActions()
        {
            return new ProductReviewFlow();
        }
    }
}

