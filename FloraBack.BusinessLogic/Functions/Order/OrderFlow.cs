using FloraBack.BusinessLogic.Core.Order;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Functions.Order
{
    public class OrderFlow : OrderActions, IOrderActions
    {
        public List<OrderDto> GetUserOrdersByIdAction(int userId)
        {
            var _orders = ExecuteGetUserOrdersByIdAction(userId);

            List<OrderDto> _DtoList = new List<OrderDto>();

            foreach (var _order in _orders)
            {
                var _orderDto = new OrderDto()
                {
                    Id = _order.Id,
                    UserId = _order.UserId,
                    Items = _order.Items,
                    TotalPrice = _order.TotalPrice,
                    DeliveryAddress = _order.DeliveryAddress,
                    Status = _order.Status,
                };

                _DtoList.Add(_orderDto);
            }

            return _DtoList;
        }

        public OrderDto? GetOrderByIdAction(int id)
        {
            var _order = ExecuteGetOrderByIdAction(id);

            if (_order == null)
            {
                return null;
            }

            var _orderDto = new OrderDto()
            {
                Id = _order.Id,
                UserId = _order.UserId,
                Items = _order.Items,
                TotalPrice = _order.TotalPrice,
                DeliveryAddress = _order.DeliveryAddress,
                Status = _order.Status,
            };

            return _orderDto;
        }

        public OrderDto? UpdateOrderStatusAction(int id, OrderStatus newStatus)
        {
            var _order = ExecuteUpdateOrderStatusAction(id, newStatus);

            if (_order == null)
            {
                return null;
            }

            var _orderDto = new OrderDto()
            {
                Id = _order.Id,
                UserId = _order.UserId,
                Items = _order.Items,
                TotalPrice = _order.TotalPrice,
                DeliveryAddress = _order.DeliveryAddress,
                Status = _order.Status,
            };

            return _orderDto;
        }
    }
}
