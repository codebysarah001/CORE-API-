using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.DTO;
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
        [HttpGet("Product/{id}")]
        public IActionResult GetByID(int id)
        {
           
            var product = _db.Products.Where(c => c.ProductId == id).FirstOrDefault();
            return Ok(product);
        }

        // GetProductByname
        [HttpGet("ProductSort")]
        public IActionResult GetByname()
        {

            var product = _db.Products.OrderByDescending(x => x.ProductName).ToList().TakeLast(5);
            return Ok(product);
        }

        // Get ProductByName

        [HttpGet("Name/{name}")]
        public IActionResult GetByName([FromQuery] string name)
        {
            if (name == null)
            {
                return BadRequest();   
            }
            var product = _db.Products.Where(c => c.ProductName == name).FirstOrDefault();
            return Ok(product);
        }

        // Get ProductByCategory
        [HttpGet("GetProductByCategory/{id}")]
        public IActionResult GetProductByCat(int id)
        {
            var products = _db.Products.Where(c => c.CategoryId == id).ToList();
            return Ok(products);
        }

        // Get ProductPrice
        [HttpGet("GetProductPrice")]
        public IActionResult GetPrice()
        {
            var products = _db.Products.OrderByDescending(p => p.Price);

            return Ok(products);

        }

        // DeleteProduct
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var p = _db.Products.Find(id);
            
            if (p == null)
            {
                return NotFound();
            }

            _db.Products.Remove(p);
            _db.SaveChanges();

            return NoContent();
        }

        // Add Product
        [HttpPost("AddProduct")]
        public IActionResult AddNewProduct([FromForm] ProductDTO productdto)
        {
            if (productdto.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, productdto.ProductImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productdto.ProductImage.CopyToAsync(stream);
                }

            }
            var product = new Product
            {
                ProductName = productdto.ProductName,
                Description = productdto.Description,
                Price = productdto.Price,
                CategoryId = productdto.CategoryId,
                ProductImage = productdto.ProductImage.FileName,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();
        }

        // Update Product
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromForm] ProductDTO productdto)
        {
            var existingProduct = _db.Products.FirstOrDefault(p => p.ProductId == id);

            if (existingProduct == null)
            {
                return NotFound();
            }
            if (productdto.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, productdto.ProductImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productdto.ProductImage.CopyToAsync(stream);
                }

            }
            existingProduct.ProductName = productdto.ProductName;
            existingProduct.Description = productdto.Description;
            existingProduct.Price = productdto.Price;
            existingProduct.CategoryId = productdto.CategoryId;
            existingProduct.ProductImage = productdto.ProductImage.FileName;

            _db.Products.Update(existingProduct);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPost("checkSum")]
        public IActionResult CheckSum(int number1, int number2)
        {
            if (number1 + number2 == 30 || number1 == 30 || number2 == 30)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPost("multiple")]
        public IActionResult MultipleOf(int number)
        {
            if(number > 0 && (number % 3 == 0 || number % 7 == 0))
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

    }
}
