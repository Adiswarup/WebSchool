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
    [Route("api/ReportCards")]
    public class ReportCardsController : Controller
    {
        private readonly SchContext _context;

        public ReportCardsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ReportCards
        [HttpGet]
        public IEnumerable<ReportCard> GetReportCard()
        {
            return _context.ReportCard;
        }

        // GET: api/ReportCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reportCard = await _context.ReportCard.SingleOrDefaultAsync(m => m.AutoId == id);

            if (reportCard == null)
            {
                return NotFound();
            }

            return Ok(reportCard);
        }

        // PUT: api/ReportCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportCard([FromRoute] int id, [FromBody] ReportCard reportCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportCard.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(reportCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCardExists(id))
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

        // POST: api/ReportCards
        [HttpPost]
        public async Task<IActionResult> PostReportCard([FromBody] ReportCard reportCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReportCard.Add(reportCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportCard", new { id = reportCard.AutoId }, reportCard);
        }

        // DELETE: api/ReportCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reportCard = await _context.ReportCard.SingleOrDefaultAsync(m => m.AutoId == id);
            if (reportCard == null)
            {
                return NotFound();
            }

            _context.ReportCard.Remove(reportCard);
            await _context.SaveChangesAsync();

            return Ok(reportCard);
        }

        private bool ReportCardExists(int id)
        {
            return _context.ReportCard.Any(e => e.AutoId == id);
        }
    }
}