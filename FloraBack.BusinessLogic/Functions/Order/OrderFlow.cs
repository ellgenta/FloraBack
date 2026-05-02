using FloraBack.BusinessLogic.Core.Order;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.User;
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
        public List<OrderInfoDto> GetUserOrdersByIdAction(int userId)
        {
            var _orders = ExecuteGetUserOrdersByIdAction(userId);

            List<OrderInfoDto> _DtoList = new List<OrderInfoDto>();

            foreach (var _order in _orders)
            {
                var _orderDto = new OrderInfoDto()
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

        public OrderInfoDto? GetOrderByIdAction(int id)
        {
            var _order = ExecuteGetOrderByIdAction(id);

            if (_order == null)
            {
                return null;
            }

            var _orderDto = new OrderInfoDto()
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

        public OrderInfoDto? UpdateOrderStatusAction(int id, OrderStatus newStatus)
        {
            var _order = ExecuteUpdateOrderStatusAction(id, newStatus);

            if (_order == null)
            {
                return null;
            }

            var _orderDto = new OrderInfoDto()
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

        public OrderInfoDto CreateOrderAction(OrderCreateDto order)
        {
            var _newOrder = ExecuteCreateOrderAction(order);

            var _orderDto = new OrderInfoDto()
            {
                Id = _newOrder.Id,
                UserId = _newOrder.UserId,
                Items = _newOrder.Items,
                TotalPrice = _newOrder.TotalPrice,
                DeliveryAddress = _newOrder.DeliveryAddress,
                Status = _newOrder.Status,
            };

            return _orderDto;
        }
    }
}
