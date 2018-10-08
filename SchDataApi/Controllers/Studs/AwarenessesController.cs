using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Studs;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Awarenesses")]
    public class AwarenessesController : Controller
    {
        private readonly SchContext _context;

        public AwarenessesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Awarenesses
        [HttpGet]
        public IEnumerable<Awareness> GetAwareness()
        {
            return _context.Awareness;
        }

        // GET: api/Awarenesses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAwareness([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var awareness = await _context.Awareness.SingleOrDefaultAsync(m => m.AutoId == id);

            if (awareness == null)
            {
                return NotFound();
            }

            return Ok(awareness);
        }

        // PUT: api/Awarenesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAwareness([FromRoute] int id, [FromBody] Awareness awareness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != awareness.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(awareness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwarenessExists(id))
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

        // POST: api/Awarenesses
        [HttpPost]
        public async Task<IActionResult> PostAwareness([FromBody] Awareness awareness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Awareness.Add(awareness);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAwareness", new { id = awareness.AutoId }, awareness);
        }

        // DELETE: api/Awarenesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAwareness([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var awareness = await _context.Awareness.SingleOrDefaultAsync(m => m.AutoId == id);
            if (awareness == null)
            {
                return NotFound();
            }

            _context.Awareness.Remove(awareness);
            await _context.SaveChangesAsync();

            return Ok(awareness);
        }

        private bool AwarenessExists(int id)
        {
            return _context.Awareness.Any(e => e.AutoId == id);
        }
    }
}