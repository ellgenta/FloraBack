using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Core.Order
{
    public class OrderActions
    {
        static List<OrderData> _OrderRepo = new List<OrderData>();

        static int nextId = 1;

        public List<OrderData> ExecuteGetUserOrdersByIdAction(int userId)
        {
            List<OrderData> _userOrders = new List<OrderData>();

            foreach (var _order in _OrderRepo)
            {
                if (_order.UserId == userId)
                {
                    _userOrders.Add(_order);
                }
            }

            return _userOrders; 
        }

        public OrderData? ExecuteGetOrderByIdAction(int id)
        {
            var _order = _OrderRepo.FirstOrDefault(x => x.Id == id);

            return _order;
        }

        public OrderData? ExecuteUpdateOrderStatusAction(int id, OrderStatus newStatus)
        {
            var _order = _OrderRepo.FirstOrDefault(x => x.Id == id);

            if (_order != null)
            {
                _order.Status = newStatus;
                _order.UpdatedAt = DateTime.Now;
                return _order;
            }

            return null;
        }
    }
}
