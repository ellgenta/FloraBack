using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICartActions
    {
        CartDto? GetCartAction();
        CartDto? AddItemToCartAction(CartItemDto item);
        CartDto? UpdateCartItemAction(int itemId, CartItemDto item);
        bool DeleteCartItemAction(int itemId);
        bool ClearCartAction();

    }
}