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
    [Route("api/Miscs")]
    public class MiscsController : Controller
    {
        private readonly SchContext _context;

        public MiscsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Miscs
        [HttpGet]
        public IEnumerable<Misc> GetMisc()
        {
            return _context.Misc;
        }

        // GET: api/Miscs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMisc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var misc = await _context.Misc.SingleOrDefaultAsync(m => m.AutoId == id);

            if (misc == null)
            {
                return NotFound();
            }

            return Ok(misc);
        }

        // PUT: api/Miscs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMisc([FromRoute] int id, [FromBody] Misc misc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != misc.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(misc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiscExists(id))
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

        // POST: api/Miscs
        [HttpPost]
        public async Task<IActionResult> PostMisc([FromBody] Misc misc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Misc.Add(misc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMisc", new { id = misc.AutoId }, misc);
        }

        // DELETE: api/Miscs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMisc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var misc = await _context.Misc.SingleOrDefaultAsync(m => m.AutoId == id);
            if (misc == null)
            {
                return NotFound();
            }

            _context.Misc.Remove(misc);
            await _context.SaveChangesAsync();

            return Ok(misc);
        }

        private bool MiscExists(int id)
        {
            return _context.Misc.Any(e => e.AutoId == id);
        }
    }
}