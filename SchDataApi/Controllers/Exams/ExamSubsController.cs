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
    [Route("api/ExamSubs")]
    public class ExamSubsController : Controller
    {
        private readonly SchContext _context;

        public ExamSubsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ExamSubs
        [HttpGet]
        public IEnumerable<ExamSub> GetExamSub()
        {
            return _context.ExamSub;
        }

        // GET: api/ExamSubs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamSub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examSub = await _context.ExamSub.SingleOrDefaultAsync(m => m.ExamSubAutoId == id);

            if (examSub == null)
            {
                return NotFound();
            }

            return Ok(examSub);
        }

        // PUT: api/ExamSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamSub([FromRoute] int id, [FromBody] ExamSub examSub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examSub.ExamSubAutoId)
            {
                return BadRequest();
            }

            _context.Entry(examSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamSubExists(id))
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

        // POST: api/ExamSubs
        [HttpPost]
        public async Task<IActionResult> PostExamSub([FromBody] ExamSub examSub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExamSub.Add(examSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamSub", new { id = examSub.ExamSubAutoId }, examSub);
        }

        // DELETE: api/ExamSubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamSub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examSub = await _context.ExamSub.SingleOrDefaultAsync(m => m.ExamSubAutoId == id);
            if (examSub == null)
            {
                return NotFound();
            }

            _context.ExamSub.Remove(examSub);
            await _context.SaveChangesAsync();

            return Ok(examSub);
        }

        private bool ExamSubExists(int id)
        {
            return _context.ExamSub.Any(e => e.ExamSubAutoId == id);
        }
    }
}