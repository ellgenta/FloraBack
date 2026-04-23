using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Enums;

namespace FloraBack.BusinessLogic.Core.Cart
{
    public class CartActions
    {
        static List<CartData> _CartRepo = new List<CartData>()
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

        static int nextId = 2;
        static int nextCartItemId = 3;

        public CartData? ExecuteGetCartAction()
        {
            var _cart = _CartRepo.FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);
            return _cart;
        }

        public CartData? ExecuteAddItemToCartAction(CartItem item)
        {
            var _cart = _CartRepo.FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

            if (_cart == null)
            {
                _cart = new CartData()
                {
                    Id = nextId++,
                    UserId = 1,
                    Items = new List<CartItem>(),
                    TotalPrice = 0,
                    Status = CartStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _CartRepo.Add(_cart);
            }

            var _existingItem = _cart.Items.FirstOrDefault(x => x.ProductId == item.ProductId);

            if (_existingItem != null)
            {
                _existingItem.Quantity += item.Quantity;
                _existingItem.TotalPrice = _existingItem.Quantity * _existingItem.UnitPrice;
            }
            else
            {
                var _newCartItem = new CartItem()
                {
                    Id = nextCartItemId++,
                    CartId = _cart.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice
                };

                _cart.Items.Add(_newCartItem);
            }

            _cart.TotalPrice = _cart.Items.Sum(x => x.TotalPrice);
            _cart.UpdatedAt = DateTime.Now;

            return _cart;
        }

        public CartData? ExecuteUpdateCartItemAction(int itemId, CartItem item)
        {
            var _cart = _CartRepo.FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

            if (_cart == null)
            {
                return null;
            }

            var _cartItem = _cart.Items.FirstOrDefault(x => x.Id == itemId);

            if (_cartItem == null)
            {
                return null;
            }

            _cartItem.Quantity = item.Quantity;
            _cartItem.UnitPrice = item.UnitPrice;
            _cartItem.TotalPrice = _cartItem.Quantity * _cartItem.UnitPrice;

            _cart.TotalPrice = _cart.Items.Sum(x => x.TotalPrice);
            _cart.UpdatedAt = DateTime.Now;

            return _cart;
        }

        public bool ExecuteDeleteCartItemAction(int itemId)
        {
            var _cart = _CartRepo.FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

            if (_cart == null)
            {
                return false;
            }

            var _cartItem = _cart.Items.FirstOrDefault(x => x.Id == itemId);

            if (_cartItem == null)
            {
                return false;
            }

            _cart.Items.Remove(_cartItem);
            _cart.TotalPrice = _cart.Items.Sum(x => x.TotalPrice);
            _cart.UpdatedAt = DateTime.Now;

            return true;
        }
    }
}