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
    [Route("api/LeaveDefinitions")]
    public class LeaveDefinitionsController : Controller
    {
        private readonly SchContext _context;

        public LeaveDefinitionsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/LeaveDefinitions
        [HttpGet]
        public IEnumerable<LeaveDefinition> GetLeaveDefinition()
        {
            return _context.LeaveDefinition;
        }

        // GET: api/LeaveDefinitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveDefinition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveDefinition = await _context.LeaveDefinition.SingleOrDefaultAsync(m => m.AutoId == id);

            if (leaveDefinition == null)
            {
                return NotFound();
            }

            return Ok(leaveDefinition);
        }

        // PUT: api/LeaveDefinitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveDefinition([FromRoute] int id, [FromBody] LeaveDefinition leaveDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveDefinition.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(leaveDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveDefinitionExists(id))
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

        // POST: api/LeaveDefinitions
        [HttpPost]
        public async Task<IActionResult> PostLeaveDefinition([FromBody] LeaveDefinition leaveDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeaveDefinition.Add(leaveDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveDefinition", new { id = leaveDefinition.AutoId }, leaveDefinition);
        }

        // DELETE: api/LeaveDefinitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveDefinition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveDefinition = await _context.LeaveDefinition.SingleOrDefaultAsync(m => m.AutoId == id);
            if (leaveDefinition == null)
            {
                return NotFound();
            }

            _context.LeaveDefinition.Remove(leaveDefinition);
            await _context.SaveChangesAsync();

            return Ok(leaveDefinition);
        }

        private bool LeaveDefinitionExists(int id)
        {
            return _context.LeaveDefinition.Any(e => e.AutoId == id);
        }
    }
}