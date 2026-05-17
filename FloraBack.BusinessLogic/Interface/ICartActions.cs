using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Interface
{
    public interface ICartActions
    {
        CartDto? GetCartAction(int userId);

        CartDto? AddItemToCartAction(int userId, CartItemDto item);

        CartDto? UpdateCartItemAction(int userId, int itemId, CartItemDto item);

        bool DeleteCartItemAction(int userId,int itemId);

        bool ClearCartAction(int userId);

    }
}