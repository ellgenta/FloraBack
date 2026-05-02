using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Interface
{
    public interface IOrderActions
    {
        public List<OrderInfoDto> GetUserOrdersByIdAction(int userId);

        public OrderInfoDto? GetOrderByIdAction(int id);

        public OrderInfoDto? UpdateOrderStatusAction(int id, OrderStatus newStatus);

        public OrderInfoDto CreateOrderAction(OrderCreateDto order);
    }
}
