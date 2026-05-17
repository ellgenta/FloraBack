using FloraBack.BusinessLogic.Interface;
using FloraBack.Domains.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FloraBack.Api.Controller
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartActions _cart;

        public CartController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _cart = bl.GetCartActions();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCart()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var cart = _cart.GetCartAction(userId);

            if (cart == null)
            {
                return NotFound("Cart not found");
            }

            return Ok(cart);
        }

        [HttpPost("items")]
        [Authorize]
        public IActionResult AddItemToCart([FromBody] CartItemDto item)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

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

            var updatedCart = _cart.AddItemToCartAction(userId, item);

            if (updatedCart == null)
            {
                return BadRequest("Item was not added to cart");
            }

            return Created("/api/cart", updatedCart);
        }

        [HttpPut("items/{itemId}")]
        [Authorize]
        public IActionResult UpdateCartItem(int itemId, [FromBody] CartItemDto item)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

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

            var updatedCart = _cart.UpdateCartItemAction(userId, itemId, item);

            if (updatedCart == null)
            {
                return NotFound(new { Message = $"Cart item with ID {itemId} not found" });
            }

            return Ok(updatedCart);
        }

        [HttpDelete("items/{itemId}")]
        [Authorize]
        public IActionResult DeleteCartItem(int itemId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var wasDeleted = _cart.DeleteCartItemAction(userId, itemId);

            if (!wasDeleted)
            {
                return NotFound(new { Message = $"Cart item with ID {itemId} not found" });
            }

            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult ClearCart()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var wasCleared = _cart.ClearCartAction(userId);

            if (!wasCleared)
            {
                return NotFound(new { Message = "Cart not found" });
            }

            return NoContent();
        }
    }
}