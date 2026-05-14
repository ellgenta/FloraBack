using FloraBack.BusinessLogic.Core.Order;
using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;

namespace FloraBack.BusinessLogic.Functions.Order
{
    public class OrderFlow : OrderActions, IOrderActions
    {
        public List<OrderInfoDto> GetAllOrdersAction()
        {
            var orders = ExecuteGetAllOrdersAction();

            var dtoList = new List<OrderInfoDto>();

            foreach (var order in orders)
            {
                dtoList.Add(MapToDto(order));
            }

            return dtoList;
        }

        public List<OrderInfoDto> GetUserOrdersByIdAction(int userId)
        {
            var orders = ExecuteGetUserOrdersByIdAction(userId);

            var dtoList = new List<OrderInfoDto>();

            foreach (var order in orders)
            {
                dtoList.Add(MapToDto(order));
            }

            return dtoList;
        }

        public OrderInfoDto? GetOrderByIdAction(int id)
        {
            var order = ExecuteGetOrderByIdAction(id);

            if (order == null)
            {
                return null;
            }

            return MapToDto(order);
        }

        public OrderInfoDto? UpdateOrderStatusAction(int id, OrderStatus newStatus)
        {
            var order = ExecuteUpdateOrderStatusAction(id, newStatus);

            if (order == null)
            {
                return null;
            }

            return MapToDto(order);
        }

        public OrderInfoDto CreateOrderAction(OrderCreateDto order)
        {
            var newOrder = ExecuteCreateOrderAction(order);

            return MapToDto(newOrder);
        }

        private OrderInfoDto MapToDto(OrderData order)
        {
            var itemsDto = new List<OrderItemInfoDto>();

            foreach (var item in order.Items)
            {
                var itemDto = new OrderItemInfoDto()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };

                itemsDto.Add(itemDto);
            }

            var orderDto = new OrderInfoDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = itemsDto,
                TotalPrice = order.TotalPrice,
                DeliveryAddress = order.DeliveryAddress,
                Status = order.Status,
            };

            return orderDto;
        }
    }
}