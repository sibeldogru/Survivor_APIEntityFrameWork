using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Context;
using Survivor.Models; 

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public ActionResult<Competitor> Create([FromBody] Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            _context.SaveChanges();

            return Ok(competitor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Competitor competitor)
        {
            var current = _context.Competitors.FirstOrDefault(x => x.Id == id);
            if (current is null)
                return NotFound();

            current.FirstName = competitor.FirstName;
            current.LastName = competitor.LastName;
            current.Age = competitor.Age; 
            current.Category = competitor.Category;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpGet("{id}")]
        public ActionResult<List<Competitor>> GetById(int id)
        {
            var competitor = _context.Competitors
                                    .Include(x => x.Category)
                                    .FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (competitor is null)
                return NotFound();


            return Ok(competitor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var current = _context.Competitors.FirstOrDefault(x => x.Id == id);
            if (current is null)
                return NotFound();

            current.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();



        }


    }
}
