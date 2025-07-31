using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Context;
using Survivor.Models;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoriesController(SurvivorDbContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public ActionResult<Category> Create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            var currentCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (currentCategory is null)
                return NotFound();

            currentCategory.Id = category.Id;
            currentCategory.Name = category.Name;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpGet("{id}")]
        public ActionResult<List<Category>> GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null)
                return NotFound();

            return Ok(category);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category is null)
                return NotFound();

            category.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();

        }


    }
}
