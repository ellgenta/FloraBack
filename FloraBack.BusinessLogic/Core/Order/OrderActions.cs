using FloraBack.DataAccess.Context;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.Order
{
    public class OrderActions
    {
        public List<OrderData> ExecuteGetUserOrdersByIdAction(int userId)
        {
            using (var db = new OrderContext())
            {
                var _UserOrders = db.Orders.Include(o => o.Items).Where(x => x.UserId == userId).ToList();

                return _UserOrders; 
            }

        }

        public OrderData? ExecuteGetOrderByIdAction(int id)
        {
            using (var db = new OrderContext())
            {
                var _order = db.Orders.Include(o => o.Items).FirstOrDefault(x => x.Id == id);

                return _order;
            }
        }

        public OrderData? ExecuteUpdateOrderStatusAction(int id, OrderStatus newStatus)
        {
            using (var db = new OrderContext())
            {
                var _order = db.Orders.FirstOrDefault(x => x.Id == id);

                if (_order != null)
                {
                    _order.Status = newStatus;
                    _order.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                    return _order;
                }

                return null;
            }
        }

        public OrderData ExecuteCreateOrderAction(OrderCreateDto order)
        {
            //should handle user's Id and IsActive 

            decimal _totalPrice = 0;

            foreach (var _item in order.Items)
            {
                _totalPrice += (_item.Price * _item.Quantity);
            }

            var _newOrder = new OrderData()
            {
                UserId = order.UserId,
                Items = order.Items, 
                TotalPrice = _totalPrice,
                DeliveryAddress = order.DeliveryAddress,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            using (var db = new OrderContext())
            {
                db.Orders.Add(_newOrder);
                db.SaveChanges();
            }

            return _newOrder;
        }
    }
}
