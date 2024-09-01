using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.DTO;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        // getAllCategories

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult Get()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }

        // GetCategoryById 
        [HttpGet]
        [Route("Category/{id:min(5)}")]
        public IActionResult GetByID(int id) 
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var categories = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            return Ok(categories);
        }

        // Get CategoryByName

        [HttpGet]
        [Route("Category/Name/{name}")]
        public IActionResult GetByName(string name) 
        {
            if (name == null) { 
                return BadRequest();
            }
            var cat = _db.Categories.Where(c => c.CategoryName == name).FirstOrDefault();
            return Ok(cat);
        }


        // DeleteCategory
        [HttpDelete]
        [Route("Category/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var products = _db.Products.Where(model => model.CategoryId == id).ToList();
            _db.Products.RemoveRange(products);
            _db.SaveChanges();


            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Add New Category
        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory([FromForm] CategoryDTO categrydto)
        {
            if (categrydto.CategoryImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, categrydto.CategoryImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    categrydto.CategoryImage.CopyToAsync(stream);
                }

            }
            var cat = new Category()
            {
                CategoryName = categrydto.CategoryName,
                CategoryImage = categrydto.CategoryImage.FileName
            };

            _db.Categories.Add(cat);
            _db.SaveChanges();
            return Ok();
        }

        // Update Category
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromForm] CategoryDTO categrydto)
        {
            var categoryID = _db.Categories.Find(id);

            if (categrydto.CategoryImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, categrydto.CategoryImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    categrydto.CategoryImage.CopyToAsync(stream);
                }

            }

            if (categoryID == null)
            {
                return NotFound();
            }
            categoryID.CategoryName = categrydto.CategoryName;
            categoryID.CategoryImage = categrydto.CategoryImage.FileName;

            _db.Categories.Update(categoryID);
            _db.SaveChanges();
            return Ok();
        }
    }
}