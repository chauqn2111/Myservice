using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Repositories;
using NuGet.Protocol.Core.Types;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _reponsitory = new CategoryRepository();
        [HttpGet]

        public ActionResult<IEnumerable<Category>> GetCategorys() => _reponsitory.GetCategorys();
        
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _reponsitory.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
            return category;
        }
        [HttpPost]
        public IActionResult PostCategory(Category c)
        {
            try
            {
                _reponsitory.SaveCategory(c);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee record");
            }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdatetCategory(int id, Category c)
        {
            var temp = _reponsitory.GetCategoryById(id);
            if(temp == null)
            {
                return NotFound();
            }
            _reponsitory.UpdateCategory(c);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var temp = _reponsitory.GetCategoryById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _reponsitory.DeleteCategory(temp);
            return NoContent();
        }
    }
}
