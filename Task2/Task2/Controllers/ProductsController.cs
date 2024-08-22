using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ProductsController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        // getAllProducts

        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        // GetProductById 
        [HttpGet("Product/ {id}")]
        public IActionResult GetByID([FromQuery] int id)
        {
            var product = _db.Products.Where(c => c.ProductId == id).FirstOrDefault();
            return Ok(product);
        }

        // Get ProductByName

        [HttpGet("Name/{name}")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var product = _db.Products.Where(c => c.ProductName == name).FirstOrDefault();
            return Ok(product);
        }

        // DeleteProduct
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            var p = _db.Products.Find(id);

            if (p == null)
            {
                return NotFound();
            }

            _db.Products.Remove(p);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
