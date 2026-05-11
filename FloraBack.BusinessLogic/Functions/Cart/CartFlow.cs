using FloraBack.BusinessLogic.Core.Cart;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Functions.Cart
{
    public class CartFlow : CartActions, ICartActions
    {
        public CartDto? GetCartAction()
        {
            var _cart = ExecuteGetCartAction();

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public CartDto? AddItemToCartAction(CartItemDto item)
        {
            var cartItem = MapToData(item);

            var _cart = ExecuteAddItemToCartAction(cartItem);

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public CartDto? UpdateCartItemAction(int itemId, CartItemDto item)
        {
            var cartItem = MapToData(item);

            var _cart = ExecuteUpdateCartItemAction(itemId, cartItem);

            if (_cart == null)
            {
                return null;
            }

            return MapToDto(_cart);
        }

        public bool DeleteCartItemAction(int itemId)
        {
            return ExecuteDeleteCartItemAction(itemId);
        }

        public bool ClearCartAction()
        {
            return ExecuteClearCartAction();
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