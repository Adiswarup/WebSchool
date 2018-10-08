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
    [Route("api/ConSmsses")]
    public class ConSmssesController : Controller
    {
        private readonly SchContext _context;

        public ConSmssesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ConSmsses
        [HttpGet]
        public IEnumerable<ConSmss> GetConSmss()
        {
            return _context.ConSmss;
        }

        // GET: api/ConSmsses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConSmss([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conSmss = await _context.ConSmss.SingleOrDefaultAsync(m => m.AutoId == id);

            if (conSmss == null)
            {
                return NotFound();
            }

            return Ok(conSmss);
        }

        // PUT: api/ConSmsses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConSmss([FromRoute] int id, [FromBody] ConSmss conSmss)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conSmss.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(conSmss).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConSmssExists(id))
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

        // POST: api/ConSmsses
        [HttpPost]
        public async Task<IActionResult> PostConSmss([FromBody] ConSmss conSmss)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConSmss.Add(conSmss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConSmss", new { id = conSmss.AutoId }, conSmss);
        }

        // DELETE: api/ConSmsses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConSmss([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conSmss = await _context.ConSmss.SingleOrDefaultAsync(m => m.AutoId == id);
            if (conSmss == null)
            {
                return NotFound();
            }

            _context.ConSmss.Remove(conSmss);
            await _context.SaveChangesAsync();

            return Ok(conSmss);
        }

        private bool ConSmssExists(int id)
        {
            return _context.ConSmss.Any(e => e.AutoId == id);
        }
    }
}