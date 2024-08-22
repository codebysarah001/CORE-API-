﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("Category/{id:int}")]
        public IActionResult GetByID(int id) 
        {
            var categories = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            return Ok(categories);
        }

        // Get CategoryByName

        [HttpGet]
        [Route("Category/Name/{name}")]
        public IActionResult GetByName(string name) 
        {
            var cat = _db.Categories.Where(c => c.CategoryName == name).FirstOrDefault();
            return Ok(cat);
        }

        // DeleteCategory
        [HttpDelete]
        [Route("Category/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.Products.Any())
            {
                return BadRequest("Cannot delete category because it has associated products.");
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();

            return NoContent();
        }

    }
}