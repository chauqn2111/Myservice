using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository _repository = new ProductRepository();
        // GET: api/<ProductsControllers>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()=> _repository.GetProducts();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy sản phẩm
            }

            return product;
        }

        // POST api/<ProductsControllers>
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            try { 
            _repository.SaveProduct(p);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee record");
            }
        }

        // PUT api/<ProductsControllers>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var temp = _repository.GetProductById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _repository.UpdateProduct(p);
            return NoContent();
        }

        // DELETE api/<ProductsControllers>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var temp = _repository.GetProductById(id);
            if(temp == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(temp);
            return NoContent();
        }
    }
}
