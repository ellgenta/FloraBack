using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICart
    {
        CartDto? GetCartAction();
    }
}