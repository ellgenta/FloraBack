using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Enums;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.BusinessLogic.Core.Cart
{
    public class CartActions
    {
        public CartData? ExecuteGetCartAction()
        {
            using (var db = new AppDbContext())
            {
                var cart = db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

                return cart;
            }
        }

        public CartData? ExecuteAddItemToCartAction(CartItemData item)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

                if (cart == null)
                {
                    cart = new CartData()
                    {
                        UserId = 1,
                        Items = new List<CartItemData>(),
                        TotalPrice = 0,
                        Status = CartStatus.Active,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };

                    db.Carts.Add(cart);
                    db.SaveChanges();
                }

                var existingItem = cart.Items.FirstOrDefault(x => x.ProductId == item.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
                }
                else
                {
                    var newCartItem = new CartItemData()
                    {
                        CartId = cart.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.Quantity * item.UnitPrice
                    };

                    cart.Items.Add(newCartItem);
                }

                cart.TotalPrice = cart.Items.Sum(x => x.TotalPrice);
                cart.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return cart;
            }
        }

        public CartData? ExecuteUpdateCartItemAction(int itemId, CartItemData item)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

                if (cart == null)
                {
                    return null;
                }

                var cartItem = cart.Items.FirstOrDefault(x => x.Id == itemId);

                if (cartItem == null)
                {
                    return null;
                }

                cartItem.Quantity = item.Quantity;
                cartItem.UnitPrice = item.UnitPrice;
                cartItem.TotalPrice = cartItem.Quantity * cartItem.UnitPrice;

                cart.TotalPrice = cart.Items.Sum(x => x.TotalPrice);
                cart.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return cart;
            }
        }

        public bool ExecuteDeleteCartItemAction(int itemId)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

                if (cart == null)
                {
                    return false;
                }

                var cartItem = cart.Items.FirstOrDefault(x => x.Id == itemId);

                if (cartItem == null)
                {
                    return false;
                }

                cart.Items.Remove(cartItem);
                cart.TotalPrice = cart.Items.Sum(x => x.TotalPrice);
                cart.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }

        public bool ExecuteClearCartAction()
        {
            using (var db = new AppDbContext())
            {
                var cart = db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefault(x => x.UserId == 1 && x.Status == CartStatus.Active);

                if (cart == null)
                {
                    return false;
                }

                cart.Items.Clear();
                cart.TotalPrice = 0;
                cart.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }
    }
}