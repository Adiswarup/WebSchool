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
    [Route("api/PosTrns")]
    public class PosTrnsController : Controller
    {
        private readonly SchContext _context;

        public PosTrnsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/PosTrns
        [HttpGet]
        public IEnumerable<PosTrn> GetPosTrn()
        {
            return _context.PosTrn;
        }

        // GET: api/PosTrns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosTrn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posTrn = await _context.PosTrn.SingleOrDefaultAsync(m => m.AutoId == id);

            if (posTrn == null)
            {
                return NotFound();
            }

            return Ok(posTrn);
        }

        // PUT: api/PosTrns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosTrn([FromRoute] int id, [FromBody] PosTrn posTrn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posTrn.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(posTrn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosTrnExists(id))
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

        // POST: api/PosTrns
        [HttpPost]
        public async Task<IActionResult> PostPosTrn([FromBody] PosTrn posTrn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PosTrn.Add(posTrn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosTrn", new { id = posTrn.AutoId }, posTrn);
        }

        // DELETE: api/PosTrns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosTrn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posTrn = await _context.PosTrn.SingleOrDefaultAsync(m => m.AutoId == id);
            if (posTrn == null)
            {
                return NotFound();
            }

            _context.PosTrn.Remove(posTrn);
            await _context.SaveChangesAsync();

            return Ok(posTrn);
        }

        private bool PosTrnExists(int id)
        {
            return _context.PosTrn.Any(e => e.AutoId == id);
        }
    }
}