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
    [Route("api/Holidays")]
    public class HolidaysController : Controller
    {
        private readonly SchContext _context;

        public HolidaysController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Holidays
        [HttpGet]
        public IEnumerable<Holidays> GetHolidays()
        {
            return _context.Holidays;
        }

        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHolidays([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidays = await _context.Holidays.SingleOrDefaultAsync(m => m.AutoId == id);

            if (holidays == null)
            {
                return NotFound();
            }

            return Ok(holidays);
        }

        // PUT: api/Holidays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidays([FromRoute] int id, [FromBody] Holidays holidays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != holidays.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(holidays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidaysExists(id))
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

        // POST: api/Holidays
        [HttpPost]
        public async Task<IActionResult> PostHolidays([FromBody] Holidays holidays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Holidays.Add(holidays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolidays", new { id = holidays.AutoId }, holidays);
        }

        // DELETE: api/Holidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidays([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidays = await _context.Holidays.SingleOrDefaultAsync(m => m.AutoId == id);
            if (holidays == null)
            {
                return NotFound();
            }

            _context.Holidays.Remove(holidays);
            await _context.SaveChangesAsync();

            return Ok(holidays);
        }

        private bool HolidaysExists(int id)
        {
            return _context.Holidays.Any(e => e.AutoId == id);
        }
    }
}