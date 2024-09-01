using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext _db;

        public TestController(MyDbContext mydbcontext)
        {
            _db = mydbcontext;

        }

        [HttpPost]
        public IActionResult Result([FromForm] string calculate)
        {
            var result = calculate.Split(" ");
            var num1 = Convert.ToInt32(result[0]);
            var num2 = Convert.ToInt32(result[2]);
            var op = result[1];

            int calcResult;
            if (op == "+")
            {
                calcResult = num1 + num2;
            }
            else if (op == "-")
            {
                calcResult = num1 - num2;
            }
            else
            {
                return BadRequest();
            }

            return Content(calcResult.ToString());
        }

    }
}
