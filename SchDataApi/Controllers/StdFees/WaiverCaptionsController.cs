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
    [Route("api/WaiverCaptions")]
    public class WaiverCaptionsController : Controller
    {
        private readonly SchContext _context;

        public WaiverCaptionsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/WaiverCaptions
        [HttpGet]
        public IEnumerable<WaiverCaption> GetWaiverCaption()
        {
            return _context.WaiverCaption;
        }

        // GET: api/WaiverCaptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWaiverCaption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waiverCaption = await _context.WaiverCaption.SingleOrDefaultAsync(m => m.AutoId == id);

            if (waiverCaption == null)
            {
                return NotFound();
            }

            return Ok(waiverCaption);
        }

        // PUT: api/WaiverCaptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaiverCaption([FromRoute] int id, [FromBody] WaiverCaption waiverCaption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waiverCaption.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(waiverCaption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaiverCaptionExists(id))
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

        // POST: api/WaiverCaptions
        [HttpPost]
        public async Task<IActionResult> PostWaiverCaption([FromBody] WaiverCaption waiverCaption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WaiverCaption.Add(waiverCaption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaiverCaption", new { id = waiverCaption.AutoId }, waiverCaption);
        }

        // DELETE: api/WaiverCaptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaiverCaption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waiverCaption = await _context.WaiverCaption.SingleOrDefaultAsync(m => m.AutoId == id);
            if (waiverCaption == null)
            {
                return NotFound();
            }

            _context.WaiverCaption.Remove(waiverCaption);
            await _context.SaveChangesAsync();

            return Ok(waiverCaption);
        }

        private bool WaiverCaptionExists(int id)
        {
            return _context.WaiverCaption.Any(e => e.AutoId == id);
        }
    }
}