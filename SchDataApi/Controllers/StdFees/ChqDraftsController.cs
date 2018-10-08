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
    [Route("api/ChqDrafts")]
    public class ChqDraftsController : Controller
    {
        private readonly SchContext _context;

        public ChqDraftsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ChqDrafts
        [HttpGet]
        public IEnumerable<ChqDrafts> GetChqDrafts()
        {
            return _context.ChqDrafts;
        }

        // GET: api/ChqDrafts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChqDrafts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chqDrafts = await _context.ChqDrafts.SingleOrDefaultAsync(m => m.AutoId == id);

            if (chqDrafts == null)
            {
                return NotFound();
            }

            return Ok(chqDrafts);
        }

        // PUT: api/ChqDrafts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChqDrafts([FromRoute] int id, [FromBody] ChqDrafts chqDrafts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chqDrafts.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(chqDrafts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChqDraftsExists(id))
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

        // POST: api/ChqDrafts
        [HttpPost]
        public async Task<IActionResult> PostChqDrafts([FromBody] ChqDrafts chqDrafts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChqDrafts.Add(chqDrafts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChqDrafts", new { id = chqDrafts.AutoId }, chqDrafts);
        }

        // DELETE: api/ChqDrafts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChqDrafts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chqDrafts = await _context.ChqDrafts.SingleOrDefaultAsync(m => m.AutoId == id);
            if (chqDrafts == null)
            {
                return NotFound();
            }

            _context.ChqDrafts.Remove(chqDrafts);
            await _context.SaveChangesAsync();

            return Ok(chqDrafts);
        }

        private bool ChqDraftsExists(int id)
        {
            return _context.ChqDrafts.Any(e => e.AutoId == id);
        }
    }
}