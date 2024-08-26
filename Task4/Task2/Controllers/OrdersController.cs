using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public OrdersController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        // getAllOrders

        [HttpGet]
        public IActionResult Get()
        {
            var ortders = _db.Orders.ToList();
            return Ok(ortders);
        }

        // GetOrdersById 
        [HttpGet("Orders/ {id}")]
        public IActionResult GetByID([FromQuery] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var order = _db.Orders.Where(c => c.OrderId == id).FirstOrDefault();
            return Ok(order);
        }


        // DeleteOrder
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var order = _db.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpGet("OrderDate/{date}/{productName}")]
        public IActionResult GetByDate([FromQuery] DateOnly date, string productName)
        {
            var orderDate = _db.Orders.Where(c => c.OrderDate == date).ToList();
            var product= _db.Products.Where(c => c.ProductName == productName).ToList();

            var combinedData = new
            {
                Orders = orderDate,
                Products = product
            };

            return Ok(combinedData);
        }
    }
   
}
