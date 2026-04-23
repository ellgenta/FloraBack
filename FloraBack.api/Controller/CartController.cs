using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Entities.Cart;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.Api.Controller
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICart _cart;

        public CartController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _cart = bl.GetCartActions();
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            var cart = _cart.GetCartAction();

            if (cart == null)
            {
                return NotFound("Cart not found");
            }

            return Ok(cart);
        }

        [HttpPost("items")]
        public IActionResult AddItemToCart([FromBody] CartItem item)
        {
            if (item == null)
            {
                return BadRequest("Invalid cart item data");
            }

            if (item.ProductId <= 0)
            {
                return BadRequest("Invalid product id");
            }

            if (item.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            if (item.UnitPrice <= 0)
            {
                return BadRequest("Unit price must be greater than 0");
            }

            var updatedCart = _cart.AddItemToCartAction(item);

            if (updatedCart == null)
            {
                return BadRequest("Item was not added to cart");
            }

            return Created("/api/cart", updatedCart);
        }

        [HttpPut("items/{itemId}")]
        public IActionResult UpdateCartItem(int itemId, [FromBody] CartItem item)
        {
            if (item == null)
            {
                return BadRequest("Invalid cart item data");
            }

            if (item.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            if (item.UnitPrice <= 0)
            {
                return BadRequest("Unit price must be greater than 0");
            }

            var updatedCart = _cart.UpdateCartItemAction(itemId, item);

            if (updatedCart == null)
            {
                return NotFound(new { Message = $"Cart item with ID {itemId} not found" });
            }

            return Ok(updatedCart);
        }

        [HttpDelete("items/{itemId}")]
        public IActionResult DeleteCartItem(int itemId)
        {
            var wasDeleted = _cart.DeleteCartItemAction(itemId);

            if (!wasDeleted)
            {
                return NotFound(new { Message = $"Cart item with ID {itemId} not found" });
            }

            return NoContent();
        }
    }
}