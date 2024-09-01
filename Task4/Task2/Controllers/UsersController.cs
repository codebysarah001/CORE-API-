using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.DTO;
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
            if (id < 0)
            {
                return BadRequest();
            }
            var users = _db.Users.Where(c => c.UserId == id).FirstOrDefault();
            return Ok(users);
        }

        // Get UsersByName

        [HttpGet]
        [Route("Users/Name/{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            var user = _db.Users.Where(c => c.Username == name).FirstOrDefault();
            return Ok(user);
        }

        // DeleteUser
        [HttpDelete]
        [Route("Users/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var user = _db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();

            return NoContent();
        }

        // Add New User
        [HttpPost("AddCategory")]
        public IActionResult AddNewUser([FromForm] UserDTO userdto)
        {
            var user = new User()
            {
                Username = userdto.Username,
                Password = userdto.Password,
                Email = userdto.Email
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok();
        }

        // Update User
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromForm] UserDTO userdto)
        {
            var userID = _db.Users.Find(id);

            if (userID == null)
            {
                return NotFound();
            }
            userID.Username = userdto.Username;
            userID.Password = userdto.Password;
            userID.Email = userdto.Email;


            _db.Users.Update(userID);
            _db.SaveChanges();
            return Ok();
        }
    }
}
