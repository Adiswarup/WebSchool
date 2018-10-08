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
    [Route("api/LateConFees")]
    public class LateConFeesController : Controller
    {
        private readonly SchContext _context;

        public LateConFeesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/LateConFees
        [HttpGet]
        public IEnumerable<LateConFee> GetLateConFee()
        {
            return _context.LateConFee;
        }

        // GET: api/LateConFees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLateConFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lateConFee = await _context.LateConFee.SingleOrDefaultAsync(m => m.AutoId == id);

            if (lateConFee == null)
            {
                return NotFound();
            }

            return Ok(lateConFee);
        }

        // PUT: api/LateConFees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLateConFee([FromRoute] int id, [FromBody] LateConFee lateConFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lateConFee.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(lateConFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LateConFeeExists(id))
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

        // POST: api/LateConFees
        [HttpPost]
        public async Task<IActionResult> PostLateConFee([FromBody] LateConFee lateConFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LateConFee.Add(lateConFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLateConFee", new { id = lateConFee.AutoId }, lateConFee);
        }

        // DELETE: api/LateConFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLateConFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lateConFee = await _context.LateConFee.SingleOrDefaultAsync(m => m.AutoId == id);
            if (lateConFee == null)
            {
                return NotFound();
            }

            _context.LateConFee.Remove(lateConFee);
            await _context.SaveChangesAsync();

            return Ok(lateConFee);
        }

        private bool LateConFeeExists(int id)
        {
            return _context.LateConFee.Any(e => e.AutoId == id);
        }
    }
}