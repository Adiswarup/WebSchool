using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FeeDuesSmsdates")]
    public class FeeDuesSmsdatesController : Controller
    {
        private readonly SchContext _context;

        public FeeDuesSmsdatesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/FeeDuesSmsdates
        [HttpGet]
        public IEnumerable<FeeDuesSmsdates> GetFeeDuesSmsdates()
        {
            return _context.FeeDuesSmsdates;
        }

        // GET: api/FeeDuesSmsdates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeeDuesSmsdates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feeDuesSmsdates = await _context.FeeDuesSmsdates.SingleOrDefaultAsync(m => m.AutoId == id);

            if (feeDuesSmsdates == null)
            {
                return NotFound();
            }

            return Ok(feeDuesSmsdates);
        }

        // PUT: api/FeeDuesSmsdates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeeDuesSmsdates([FromRoute] int id, [FromBody] FeeDuesSmsdates feeDuesSmsdates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feeDuesSmsdates.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(feeDuesSmsdates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeeDuesSmsdatesExists(id))
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

        // POST: api/FeeDuesSmsdates
        [HttpPost]
        public async Task<IActionResult> PostFeeDuesSmsdates([FromBody] FeeDuesSmsdates feeDuesSmsdates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FeeDuesSmsdates.Add(feeDuesSmsdates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeeDuesSmsdates", new { id = feeDuesSmsdates.AutoId }, feeDuesSmsdates);
        }

        // DELETE: api/FeeDuesSmsdates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeeDuesSmsdates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feeDuesSmsdates = await _context.FeeDuesSmsdates.SingleOrDefaultAsync(m => m.AutoId == id);
            if (feeDuesSmsdates == null)
            {
                return NotFound();
            }

            _context.FeeDuesSmsdates.Remove(feeDuesSmsdates);
            await _context.SaveChangesAsync();

            return Ok(feeDuesSmsdates);
        }

        private bool FeeDuesSmsdatesExists(int id)
        {
            return _context.FeeDuesSmsdates.Any(e => e.AutoId == id);
        }
    }
}