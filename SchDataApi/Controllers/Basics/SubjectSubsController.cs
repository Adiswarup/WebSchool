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
    [Route("api/SubjectSubs")]
    public class SubjectSubsController : Controller
    {
        private readonly SchContext _context;

        public SubjectSubsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/SubjectSubs
        [HttpGet]
        public IEnumerable<SubjectSubs> GetSubjectSubs()
        {
            return _context.SubjectSubs;
        }

        // GET: api/SubjectSubs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectSubs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectSubs = await _context.SubjectSubs.SingleOrDefaultAsync(m => m.AutoId == id);

            if (subjectSubs == null)
            {
                return NotFound();
            }

            return Ok(subjectSubs);
        }

        // PUT: api/SubjectSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectSubs([FromRoute] int id, [FromBody] SubjectSubs subjectSubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectSubs.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(subjectSubs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectSubsExists(id))
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

        // POST: api/SubjectSubs
        [HttpPost]
        public async Task<IActionResult> PostSubjectSubs([FromBody] SubjectSubs subjectSubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubjectSubs.Add(subjectSubs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectSubs", new { id = subjectSubs.AutoId }, subjectSubs);
        }

        // DELETE: api/SubjectSubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectSubs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectSubs = await _context.SubjectSubs.SingleOrDefaultAsync(m => m.AutoId == id);
            if (subjectSubs == null)
            {
                return NotFound();
            }

            _context.SubjectSubs.Remove(subjectSubs);
            await _context.SaveChangesAsync();

            return Ok(subjectSubs);
        }

        private bool SubjectSubsExists(int id)
        {
            return _context.SubjectSubs.Any(e => e.AutoId == id);
        }
    }
}