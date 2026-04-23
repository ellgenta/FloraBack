using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Enums;

namespace FloraBack.BusinessLogic.Core.Cart
{
    public class CartAction
    {
        static List<CartData> _DataRepo = new List<CartData>()
        {
            new CartData()
            {
                Id = 1,
                UserId = 1,
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Id = 1,
                        CartId = 1,
                        ProductId = 1,
                        Quantity = 2,
                        UnitPrice = 150.00m,
                        TotalPrice = 300.00m
                    },
                    new CartItem()
                    {
                        Id = 2,
                        CartId = 1,
                        ProductId = 2,
                        Quantity = 1,
                        UnitPrice = 80.00m,
                        TotalPrice = 80.00m
                    }
                },
                TotalPrice = 380.00m,
                Status = CartStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        static int _nextCartId = 2;
        static int _nextCartItemId = 3;

        public CartData? ExecuteGetCartAction()
        {
            foreach (var _cart in _DataRepo)
            {
                if (_cart.UserId == 1 && _cart.Status == CartStatus.Active)
                {
                    return _cart;
                }
            }

            return null;
        }

        public CartData? ExecuteAddItemToCartAction(CartItem item)
        {
            CartData? _currentCart = null;

            foreach (var _cart in _DataRepo)
            {
                if (_cart.UserId == 1 && _cart.Status == CartStatus.Active)
                {
                    _currentCart = _cart;
                    break;
                }
            }

            if (_currentCart == null)
            {
                _currentCart = new CartData()
                {
                    Id = _nextCartId++,
                    UserId = 1,
                    Items = new List<CartItem>(),
                    TotalPrice = 0,
                    Status = CartStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _DataRepo.Add(_currentCart);
            }

            foreach (var _cartItem in _currentCart.Items)
            {
                if (_cartItem.ProductId == item.ProductId)
                {
                    _cartItem.Quantity += item.Quantity;
                    _cartItem.TotalPrice = _cartItem.Quantity * _cartItem.UnitPrice;
                    _currentCart.TotalPrice = _currentCart.Items.Sum(x => x.TotalPrice);
                    _currentCart.UpdatedAt = DateTime.Now;

                    return _currentCart;
                }
            }

            var _newCartItem = new CartItem()
            {
                Id = _nextCartItemId++,
                CartId = _currentCart.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.Quantity * item.UnitPrice
            };

            _currentCart.Items.Add(_newCartItem);
            _currentCart.TotalPrice = _currentCart.Items.Sum(x => x.TotalPrice);
            _currentCart.UpdatedAt = DateTime.Now;

            return _currentCart;
        }
    }
}