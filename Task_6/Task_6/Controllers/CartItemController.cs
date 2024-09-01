using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_6.DTO;
using Task_6.Models;

namespace Task_6.Controllers
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

        [HttpPut("UpdateQuantity/{id}")]
        public IActionResult updateQuantity(int id, QuantityDTO item)
        {
            var itemid = _db.CartItems.FirstOrDefault(x=>x.CartItemId==id);

            itemid.Quantity = item.Quantity;

            _db.CartItems.Update(itemid);
            _db.SaveChanges();
            return Ok(itemid);
        }

        [HttpDelete("DeleteFromCart/{id}")]
        public IActionResult deleteItemInCart(int id)
        {
            var itemid = _db.CartItems.FirstOrDefault(x => x.CartItemId == id);


            _db.CartItems.Remove(itemid);
            _db.SaveChanges();
            return Ok();
        }
    }
}
