using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.General;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Appoints")]
    public class AppointsController : Controller
    {
        private readonly SchContext _context;

        public AppointsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Appoints
        [HttpGet]
        public IEnumerable<Appoints> GetAppoints()
        {
            return _context.Appoints;
        }

        // GET: api/Appoints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppoints([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appoints = await _context.Appoints.SingleOrDefaultAsync(m => m.AutoId == id);

            if (appoints == null)
            {
                return NotFound();
            }

            return Ok(appoints);
        }

        // PUT: api/Appoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoints([FromRoute] int id, [FromBody] Appoints appoints)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appoints.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(appoints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointsExists(id))
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

        // POST: api/Appoints
        [HttpPost]
        public async Task<IActionResult> PostAppoints([FromBody] Appoints appoints)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Appoints.Add(appoints);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppoints", new { id = appoints.AutoId }, appoints);
        }

        // DELETE: api/Appoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoints([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appoints = await _context.Appoints.SingleOrDefaultAsync(m => m.AutoId == id);
            if (appoints == null)
            {
                return NotFound();
            }

            _context.Appoints.Remove(appoints);
            await _context.SaveChangesAsync();

            return Ok(appoints);
        }

        private bool AppointsExists(int id)
        {
            return _context.Appoints.Any(e => e.AutoId == id);
        }
    }
}