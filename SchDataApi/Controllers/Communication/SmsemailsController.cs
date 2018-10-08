using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Communication;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Smsemails")]
    public class SmsemailsController : Controller
    {
        private readonly SchContext _context;

        public SmsemailsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Smsemails
        [HttpGet]
        public IEnumerable<Smsemails> GetSmsemails()
        {
            return _context.Smsemails;
        }

        // GET: api/Smsemails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmsemails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smsemails = await _context.Smsemails.SingleOrDefaultAsync(m => m.AutoId == id);

            if (smsemails == null)
            {
                return NotFound();
            }

            return Ok(smsemails);
        }

        // PUT: api/Smsemails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsemails([FromRoute] int id, [FromBody] Smsemails smsemails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smsemails.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(smsemails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsemailsExists(id))
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

        // POST: api/Smsemails
        [HttpPost]
        public async Task<IActionResult> PostSmsemails([FromBody] Smsemails smsemails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Smsemails.Add(smsemails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmsemails", new { id = smsemails.AutoId }, smsemails);
        }

        // DELETE: api/Smsemails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsemails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smsemails = await _context.Smsemails.SingleOrDefaultAsync(m => m.AutoId == id);
            if (smsemails == null)
            {
                return NotFound();
            }

            _context.Smsemails.Remove(smsemails);
            await _context.SaveChangesAsync();

            return Ok(smsemails);
        }

        private bool SmsemailsExists(int id)
        {
            return _context.Smsemails.Any(e => e.AutoId == id);
        }
    }
}