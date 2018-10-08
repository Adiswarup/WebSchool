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
    [Route("api/StdFees")]
    public class StdFeesController : Controller
    {
        private readonly SchContext _context;

        public StdFeesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/StdFees
        [HttpGet]
        public IEnumerable<StdFee> GetStdFee()
        {
            return _context.StdFee;
        }

        // GET: api/StdFees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStdFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdFee = await _context.StdFee.SingleOrDefaultAsync(m => m.AutoId == id);

            if (stdFee == null)
            {
                return NotFound();
            }

            return Ok(stdFee);
        }

        // PUT: api/StdFees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStdFee([FromRoute] int id, [FromBody] StdFee stdFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stdFee.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(stdFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdFeeExists(id))
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

        // POST: api/StdFees
        [HttpPost]
        public async Task<IActionResult> PostStdFee([FromBody] StdFee stdFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StdFee.Add(stdFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStdFee", new { id = stdFee.AutoId }, stdFee);
        }

        // DELETE: api/StdFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStdFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdFee = await _context.StdFee.SingleOrDefaultAsync(m => m.AutoId == id);
            if (stdFee == null)
            {
                return NotFound();
            }

            _context.StdFee.Remove(stdFee);
            await _context.SaveChangesAsync();

            return Ok(stdFee);
        }

        private bool StdFeeExists(int id)
        {
            return _context.StdFee.Any(e => e.AutoId == id);
        }
    }
}