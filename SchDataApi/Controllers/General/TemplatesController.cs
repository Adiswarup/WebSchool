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
    [Route("api/Templates")]
    public class TemplatesController : Controller
    {
        private readonly SchContext _context;

        public TemplatesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public IEnumerable<Template> GetTemplate()
        {
            return _context.Template;
        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var template = await _context.Template.SingleOrDefaultAsync(m => m.AutoId == id);

            if (template == null)
            {
                return NotFound();
            }

            return Ok(template);
        }

        // PUT: api/Templates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplate([FromRoute] int id, [FromBody] Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != template.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(template).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
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

        // POST: api/Templates
        [HttpPost]
        public async Task<IActionResult> PostTemplate([FromBody] Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Template.Add(template);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplate", new { id = template.AutoId }, template);
        }

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var template = await _context.Template.SingleOrDefaultAsync(m => m.AutoId == id);
            if (template == null)
            {
                return NotFound();
            }

            _context.Template.Remove(template);
            await _context.SaveChangesAsync();

            return Ok(template);
        }

        private bool TemplateExists(int id)
        {
            return _context.Template.Any(e => e.AutoId == id);
        }
    }
}