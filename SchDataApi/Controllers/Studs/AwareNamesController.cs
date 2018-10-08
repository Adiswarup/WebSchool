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
    [Route("api/AwareNames")]
    public class AwareNamesController : Controller
    {
        private readonly SchContext _context;

        public AwareNamesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/AwareNames
        [HttpGet]
        public IEnumerable<AwareNames> GetAwareNames()
        {
            return _context.AwareNames;
        }

        // GET: api/AwareNames/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAwareNames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var awareNames = await _context.AwareNames.SingleOrDefaultAsync(m => m.AutoId == id);

            if (awareNames == null)
            {
                return NotFound();
            }

            return Ok(awareNames);
        }

        // PUT: api/AwareNames/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAwareNames([FromRoute] int id, [FromBody] AwareNames awareNames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != awareNames.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(awareNames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwareNamesExists(id))
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

        // POST: api/AwareNames
        [HttpPost]
        public async Task<IActionResult> PostAwareNames([FromBody] AwareNames awareNames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AwareNames.Add(awareNames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAwareNames", new { id = awareNames.AutoId }, awareNames);
        }

        // DELETE: api/AwareNames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAwareNames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var awareNames = await _context.AwareNames.SingleOrDefaultAsync(m => m.AutoId == id);
            if (awareNames == null)
            {
                return NotFound();
            }

            _context.AwareNames.Remove(awareNames);
            await _context.SaveChangesAsync();

            return Ok(awareNames);
        }

        private bool AwareNamesExists(int id)
        {
            return _context.AwareNames.Any(e => e.AutoId == id);
        }
    }
}