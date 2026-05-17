using FloraBack.BusinessLogic.Core.Cart;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Functions.Cart
{
    public class CartFlow : CartActions, ICartActions
    {
        public CartDto? GetCartAction(int userId)
        {
            var _cart = ExecuteGetCartAction(userId);

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public CartDto? AddItemToCartAction(int userId, CartItemDto item)
        {
            var cartItem = MapToData(item);

            var _cart = ExecuteAddItemToCartAction(userId, cartItem);

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public CartDto? UpdateCartItemAction(int userId, int itemId, CartItemDto item)
        {
            var cartItem = MapToData(item);

            var _cart = ExecuteUpdateCartItemAction(userId, itemId, cartItem);

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public bool DeleteCartItemAction(int userId,int itemId)
        {
            return ExecuteDeleteCartItemAction(userId, itemId);
        }

        public bool ClearCartAction(int userId)
        {
            return ExecuteClearCartAction(userId);
        }

        private CartDto MapToDto(CartData cart)
        {
            return new CartDto()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items,
                TotalPrice = cart.TotalPrice,
                Status = cart.Status,
            };
        }

        private CartItemData MapToData(CartItemDto item)
        {
            return new CartItemData()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };
        }
    }
}