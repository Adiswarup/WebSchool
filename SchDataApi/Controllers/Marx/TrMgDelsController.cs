using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Marx;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TrMgDels")]
    public class TrMgDelsController : Controller
    {
        private readonly SchContext _context;

        public TrMgDelsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/TrMgDels
        [HttpGet]
        public IEnumerable<TrMgDel> GetTrMgDel()
        {
            return _context.TrMgDel;
        }

        // GET: api/TrMgDels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrMgDel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trMgDel = await _context.TrMgDel.SingleOrDefaultAsync(m => m.MkTrId == id);

            if (trMgDel == null)
            {
                return NotFound();
            }

            return Ok(trMgDel);
        }

        // PUT: api/TrMgDels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrMgDel([FromRoute] int id, [FromBody] TrMgDel trMgDel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trMgDel.MkTrId)
            {
                return BadRequest();
            }

            _context.Entry(trMgDel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrMgDelExists(id))
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

        // POST: api/TrMgDels
        [HttpPost]
        public async Task<IActionResult> PostTrMgDel([FromBody] TrMgDel trMgDel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrMgDel.Add(trMgDel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrMgDelExists(trMgDel.MkTrId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrMgDel", new { id = trMgDel.MkTrId }, trMgDel);
        }

        // DELETE: api/TrMgDels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrMgDel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trMgDel = await _context.TrMgDel.SingleOrDefaultAsync(m => m.MkTrId == id);
            if (trMgDel == null)
            {
                return NotFound();
            }

            _context.TrMgDel.Remove(trMgDel);
            await _context.SaveChangesAsync();

            return Ok(trMgDel);
        }

        private bool TrMgDelExists(int id)
        {
            return _context.TrMgDel.Any(e => e.MkTrId == id);
        }
    }
}