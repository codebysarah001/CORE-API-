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
            var Products = _db.Products.ToList();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id) 
        {
            var Products = _db.Products.Find(id);
            return Ok(Products);
        }
    }
}
