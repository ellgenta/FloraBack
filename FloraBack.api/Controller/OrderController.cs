using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Enums;
using FloraBack.Domains.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderActions _orderActions;

        public OrderController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _orderActions = bl.GetOrderActions();
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllOrders()
        {
            var orders = _orderActions.GetAllOrdersAction();

            return Ok(orders);
        }

        [HttpGet("{userId}/all")]
        [Authorize]
        public IActionResult GetUserOrdersById(int userId)
        {
            var _orders = _orderActions.GetUserOrdersByIdAction(userId);
            return Ok(_orders);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetOrderById(int id)
        {
            var _order = _orderActions.GetOrderByIdAction(id);

            if (_order != null)
            {
                return Ok(_order);
            }

            return NotFound(new { Message = $"Order with ID {id} not found" });
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOrderStatus(int id, OrderStatus newStatus)
        {
            var _order = _orderActions.UpdateOrderStatusAction(id, newStatus);

            if (_order != null)
            {
                return Ok(_order);
            }

            return NotFound(new { Message = $"User with ID {id} not found" });
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateOrder([FromBody] OrderCreateDto order)
        {
            var _order = _orderActions.CreateOrderAction(order);

            return Created($"api/order/{_order.Id}", _order);
        }
    }
}
