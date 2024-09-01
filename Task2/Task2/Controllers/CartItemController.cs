using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.DTO;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CartItemController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        [HttpGet]
        public IActionResult getCartItems()
        {
            var cartItems = _db.CartItems.Select(x =>
            new CartItemResponseDTO
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new ProductDTO
                {
                    ProductId = x.Product.ProductId,
                    ProductName = x.Product.ProductName,
                    Price = x.Product.Price,
                    Description = x.Product.Description,
                    CategoryId = x.Product.CategoryId,
                }
            }
            );
            return Ok(cartItems);
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart([FromBody] addCartItemRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
            };

            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok();
        }
    }
}