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
    [Route("api/SubjectsRels")]
    public class SubjectsRelsController : Controller
    {
        private readonly SchContext _context;

        public SubjectsRelsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/SubjectsRels
        [HttpGet]
        public IEnumerable<SubjectsRel> GetSubjectsRel()
        {
            return _context.SubjectsRel;
        }

        // GET: api/SubjectsRels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectsRel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectsRel = await _context.SubjectsRel.SingleOrDefaultAsync(m => m.AutoId == id);

            if (subjectsRel == null)
            {
                return NotFound();
            }

            return Ok(subjectsRel);
        }

        // PUT: api/SubjectsRels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectsRel([FromRoute] int id, [FromBody] SubjectsRel subjectsRel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectsRel.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(subjectsRel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsRelExists(id))
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

        // POST: api/SubjectsRels
        [HttpPost]
        public async Task<IActionResult> PostSubjectsRel([FromBody] SubjectsRel subjectsRel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubjectsRel.Add(subjectsRel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectsRel", new { id = subjectsRel.AutoId }, subjectsRel);
        }

        // DELETE: api/SubjectsRels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectsRel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectsRel = await _context.SubjectsRel.SingleOrDefaultAsync(m => m.AutoId == id);
            if (subjectsRel == null)
            {
                return NotFound();
            }

            _context.SubjectsRel.Remove(subjectsRel);
            await _context.SaveChangesAsync();

            return Ok(subjectsRel);
        }

        private bool SubjectsRelExists(int id)
        {
            return _context.SubjectsRel.Any(e => e.AutoId == id);
        }
    }
}