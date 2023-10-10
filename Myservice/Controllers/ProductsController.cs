using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Myservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyStockContext context;
        public ProductsController(MyStockContext context)
        {
            this.context = context;
        }
        [HttpGet] // Get all product
        public ActionResult<IEnumerable<Product>> GetProducts() => context.Products.ToList();
        // GET: api/<ProductsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return NoContent();
        }
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put( int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NoContent();
            }
            context.Products.Update(product);
            context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NoContent();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return NoContent();
        }
    }
}
