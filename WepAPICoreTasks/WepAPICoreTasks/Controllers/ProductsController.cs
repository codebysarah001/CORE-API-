using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICoreTasks.Models;

namespace WepAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly MyDbContext _db;

        public ProductsController(MyDbContext myDbContext)
        {
            _db = myDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var Products = _db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            return Ok(Products);
        }
    }
}
