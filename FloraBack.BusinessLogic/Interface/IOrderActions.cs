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
        public List<OrderDto> GetUserOrdersByIdAction(int userId);

        public OrderDto? GetOrderByIdAction(int id);
    }
}
