using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICart
    {
        CartDto? GetCartAction();
        CartDto? AddItemToCartAction(CartItem item);
        CartDto? UpdateCartItemAction(int itemId, CartItem item);

    }
}