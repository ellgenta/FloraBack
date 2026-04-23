using FloraBack.BusinessLogic.Core.Cart;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Models.Cart;

namespace FloraBack.BusinessLogic.Functions.Cart
{
    public class CartFlow : CartAction, ICart
    {
        public CartDto? GetCartAction()
        {
            var _cart = ExecuteGetCartAction();

            if (_cart == null)
            {
                return null;
            }

            var _cartDto = new CartDto()
            {
                Id = _cart.Id,
                UserId = _cart.UserId,
                Items = _cart.Items,
                TotalPrice = _cart.TotalPrice,
                Status = _cart.Status
            };

            return _cartDto;
        }

        public CartDto? AddItemToCartAction(CartItem item)
        {
            var _cart = ExecuteAddItemToCartAction(item);

            if (_cart == null)
            {
                return null;
            }

            var _cartDto = new CartDto()
            {
                Id = _cart.Id,
                UserId = _cart.UserId,
                Items = _cart.Items,
                TotalPrice = _cart.TotalPrice,
                Status = _cart.Status
            };

            return _cartDto;
        }
    }
}