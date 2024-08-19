using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICoreTasks.Models;

namespace WepAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public CategoriesController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

        }

        [HttpGet]
        public IActionResult Get() 
        {
            var categories = _myDbContext.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var categories = _myDbContext.Categories.Find(id);
            return Ok(categories);
        }

    }
}
