using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Exams;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/StdSubs")]
    public class StdSubsController : Controller
    {
        private readonly SchContext _context;

        public StdSubsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/StdSubs
        [HttpGet]
        public IEnumerable<StdSub> GetStdSub()
        {
            return _context.StdSub;
        }

        // GET: api/StdSubs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStdSub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdSub = await _context.StdSub.SingleOrDefaultAsync(m => m.AutoId == id);

            if (stdSub == null)
            {
                return NotFound();
            }

            return Ok(stdSub);
        }

        // PUT: api/StdSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStdSub([FromRoute] int id, [FromBody] StdSub stdSub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stdSub.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(stdSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdSubExists(id))
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

        // POST: api/StdSubs
        [HttpPost]
        public async Task<IActionResult> PostStdSub([FromBody] StdSub stdSub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StdSub.Add(stdSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStdSub", new { id = stdSub.AutoId }, stdSub);
        }

        // DELETE: api/StdSubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStdSub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdSub = await _context.StdSub.SingleOrDefaultAsync(m => m.AutoId == id);
            if (stdSub == null)
            {
                return NotFound();
            }

            _context.StdSub.Remove(stdSub);
            await _context.SaveChangesAsync();

            return Ok(stdSub);
        }

        private bool StdSubExists(int id)
        {
            return _context.StdSub.Any(e => e.AutoId == id);
        }
    }
}