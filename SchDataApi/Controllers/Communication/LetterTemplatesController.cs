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
    [Route("api/LetterTemplates")]
    public class LetterTemplatesController : Controller
    {
        private readonly SchContext _context;

        public LetterTemplatesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/LetterTemplates
        [HttpGet]
        public IEnumerable<LetterTemplates> GetLetterTemplates()
        {
            return _context.LetterTemplates;
        }

        // GET: api/LetterTemplates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLetterTemplates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var letterTemplates = await _context.LetterTemplates.SingleOrDefaultAsync(m => m.AutoId == id);

            if (letterTemplates == null)
            {
                return NotFound();
            }

            return Ok(letterTemplates);
        }

        // PUT: api/LetterTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLetterTemplates([FromRoute] int id, [FromBody] LetterTemplates letterTemplates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != letterTemplates.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(letterTemplates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LetterTemplatesExists(id))
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

        // POST: api/LetterTemplates
        [HttpPost]
        public async Task<IActionResult> PostLetterTemplates([FromBody] LetterTemplates letterTemplates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LetterTemplates.Add(letterTemplates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLetterTemplates", new { id = letterTemplates.AutoId }, letterTemplates);
        }

        // DELETE: api/LetterTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLetterTemplates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var letterTemplates = await _context.LetterTemplates.SingleOrDefaultAsync(m => m.AutoId == id);
            if (letterTemplates == null)
            {
                return NotFound();
            }

            _context.LetterTemplates.Remove(letterTemplates);
            await _context.SaveChangesAsync();

            return Ok(letterTemplates);
        }

        private bool LetterTemplatesExists(int id)
        {
            return _context.LetterTemplates.Any(e => e.AutoId == id);
        }
    }
}