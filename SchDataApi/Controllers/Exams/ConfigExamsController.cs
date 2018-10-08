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
    [Route("api/ConfigExams")]
    public class ConfigExamsController : Controller
    {
        private readonly SchContext _context;

        public ConfigExamsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ConfigExams
        [HttpGet]
        public IEnumerable<ConfigExam> GetConfigExam()
        {
            return _context.ConfigExam;
        }

        // GET: api/ConfigExams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfigExam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configExam = await _context.ConfigExam.SingleOrDefaultAsync(m => m.AutoId == id);

            if (configExam == null)
            {
                return NotFound();
            }

            return Ok(configExam);
        }

        // PUT: api/ConfigExams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigExam([FromRoute] int id, [FromBody] ConfigExam configExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configExam.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(configExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigExamExists(id))
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

        // POST: api/ConfigExams
        [HttpPost]
        public async Task<IActionResult> PostConfigExam([FromBody] ConfigExam configExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConfigExam.Add(configExam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigExam", new { id = configExam.AutoId }, configExam);
        }

        // DELETE: api/ConfigExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigExam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configExam = await _context.ConfigExam.SingleOrDefaultAsync(m => m.AutoId == id);
            if (configExam == null)
            {
                return NotFound();
            }

            _context.ConfigExam.Remove(configExam);
            await _context.SaveChangesAsync();

            return Ok(configExam);
        }

        private bool ConfigExamExists(int id)
        {
            return _context.ConfigExam.Any(e => e.AutoId == id);
        }
    }
}