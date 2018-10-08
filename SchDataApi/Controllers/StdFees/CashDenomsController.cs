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
    [Route("api/CashDenoms")]
    public class CashDenomsController : Controller
    {
        private readonly SchContext _context;

        public CashDenomsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/CashDenoms
        [HttpGet]
        public IEnumerable<CashDenom> GetCashDenom()
        {
            return _context.CashDenom;
        }

        // GET: api/CashDenoms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashDenom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cashDenom = await _context.CashDenom.SingleOrDefaultAsync(m => m.AutoId == id);

            if (cashDenom == null)
            {
                return NotFound();
            }

            return Ok(cashDenom);
        }

        // PUT: api/CashDenoms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashDenom([FromRoute] int id, [FromBody] CashDenom cashDenom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashDenom.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(cashDenom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashDenomExists(id))
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

        // POST: api/CashDenoms
        [HttpPost]
        public async Task<IActionResult> PostCashDenom([FromBody] CashDenom cashDenom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CashDenom.Add(cashDenom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashDenom", new { id = cashDenom.AutoId }, cashDenom);
        }

        // DELETE: api/CashDenoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashDenom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cashDenom = await _context.CashDenom.SingleOrDefaultAsync(m => m.AutoId == id);
            if (cashDenom == null)
            {
                return NotFound();
            }

            _context.CashDenom.Remove(cashDenom);
            await _context.SaveChangesAsync();

            return Ok(cashDenom);
        }

        private bool CashDenomExists(int id)
        {
            return _context.CashDenom.Any(e => e.AutoId == id);
        }
    }
}