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

        public CartData? ExecuteGetCartAction()
        {
            foreach (var _cart in _DataRepo)
            {
                if (_cart.UserId == 1)
                {
                    return _cart;
                }
            }

            return null;
        }
    }
}