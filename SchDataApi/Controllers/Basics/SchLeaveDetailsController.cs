using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Basics;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/SchLeaveDetails")]
    public class SchLeaveDetailsController : Controller
    {
        private readonly SchContext _context;

        public SchLeaveDetailsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/SchLeaveDetails
        [HttpGet]
        public IEnumerable<SchLeaveDetails> GetSchLeaveDetails()
        {
            return _context.SchLeaveDetails;
        }

        // GET: api/SchLeaveDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchLeaveDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schLeaveDetails = await _context.SchLeaveDetails.SingleOrDefaultAsync(m => m.AutoId == id);

            if (schLeaveDetails == null)
            {
                return NotFound();
            }

            return Ok(schLeaveDetails);
        }

        // PUT: api/SchLeaveDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchLeaveDetails([FromRoute] int id, [FromBody] SchLeaveDetails schLeaveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schLeaveDetails.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(schLeaveDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchLeaveDetailsExists(id))
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

        // POST: api/SchLeaveDetails
        [HttpPost]
        public async Task<IActionResult> PostSchLeaveDetails([FromBody] SchLeaveDetails schLeaveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SchLeaveDetails.Add(schLeaveDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchLeaveDetails", new { id = schLeaveDetails.AutoId }, schLeaveDetails);
        }

        // DELETE: api/SchLeaveDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchLeaveDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schLeaveDetails = await _context.SchLeaveDetails.SingleOrDefaultAsync(m => m.AutoId == id);
            if (schLeaveDetails == null)
            {
                return NotFound();
            }

            _context.SchLeaveDetails.Remove(schLeaveDetails);
            await _context.SaveChangesAsync();

            return Ok(schLeaveDetails);
        }

        private bool SchLeaveDetailsExists(int id)
        {
            return _context.SchLeaveDetails.Any(e => e.AutoId == id);
        }
    }
}