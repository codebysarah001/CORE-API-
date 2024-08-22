using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public UsersController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        // getAllUsers

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult Get()
        {
            var users = _db.Users.ToList();
            return Ok(users);
        }

        // GetUsersById 
        [HttpGet]
        [Route("Users/{id:int}")]
        public IActionResult GetByID(int id)
        {
            var users = _db.Users.Where(c => c.UserId == id).FirstOrDefault();
            return Ok(users);
        }

        // Get UsersByName

        [HttpGet]
        [Route("Users/Name/{name}")]
        public IActionResult GetByName(string name)
        {
            var user = _db.Users.Where(c => c.Username == name).FirstOrDefault();
            return Ok(user);
        }

        // DeleteUser
        [HttpDelete]
        [Route("Users/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
