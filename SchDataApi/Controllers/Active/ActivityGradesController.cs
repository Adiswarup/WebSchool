using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Active;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ActivityGrades")]
    public class ActivityGradesController : Controller
    {
        private readonly SchContext _context;

        public ActivityGradesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ActivityGrades
        [HttpGet]
        public IEnumerable<ActivityGrades> GetActivityGrades()
        {
            return _context.ActivityGrades;
        }

        // GET: api/ActivityGrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityGrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityGrades = await _context.ActivityGrades.SingleOrDefaultAsync(m => m.AutoId == id);

            if (activityGrades == null)
            {
                return NotFound();
            }

            return Ok(activityGrades);
        }

        // PUT: api/ActivityGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityGrades([FromRoute] int id, [FromBody] ActivityGrades activityGrades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityGrades.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(activityGrades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityGradesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityGrades
        [HttpPost]
        public async Task<IActionResult> PostActivityGrades([FromBody] ActivityGrades activityGrades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ActivityGrades.Add(activityGrades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityGrades", new { id = activityGrades.AutoId }, activityGrades);
        }

        // DELETE: api/ActivityGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityGrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityGrades = await _context.ActivityGrades.SingleOrDefaultAsync(m => m.AutoId == id);
            if (activityGrades == null)
            {
                return NotFound();
            }

            _context.ActivityGrades.Remove(activityGrades);
            await _context.SaveChangesAsync();

            return Ok(activityGrades);
        }

        private bool ActivityGradesExists(int id)
        {
            return _context.ActivityGrades.Any(e => e.AutoId == id);
        }
    }
}