using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;
using SchMod.ViewModels.StdFees;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ReceiptDetails")]
    public class ReceiptDetailsController : Controller
    {
        private readonly SchContext _context;

        public ReceiptDetailsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptDetails
        [HttpGet]
        public IEnumerable<ReceiptDetails> GetReceiptDetails()
        {
            return _context.ReceiptDetails;
        }

        // GET: api/ReceiptDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receiptDetails = await _context.ReceiptDetails.SingleOrDefaultAsync(m => m.AutoId == id);

            if (receiptDetails == null)
            {
                return NotFound();
            }

            return Ok(receiptDetails);
        }

        // PUT: api/ReceiptDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptDetails([FromRoute] int id, [FromBody] ReceiptDetails receiptDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receiptDetails.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(receiptDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptDetailsExists(id))
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

        // POST: api/ReceiptDetails
        [HttpPost]
        public async Task<IActionResult> PostReceiptDetails([FromBody] ReceiptDetails receiptDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReceiptDetails.Add(receiptDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceiptDetails", new { id = receiptDetails.AutoId }, receiptDetails);
        }

        // DELETE: api/ReceiptDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receiptDetails = await _context.ReceiptDetails.SingleOrDefaultAsync(m => m.AutoId == id);
            if (receiptDetails == null)
            {
                return NotFound();
            }

            _context.ReceiptDetails.Remove(receiptDetails);
            await _context.SaveChangesAsync();

            return Ok(receiptDetails);
        }

        private bool ReceiptDetailsExists(int id)
        {
            return _context.ReceiptDetails.Any(e => e.AutoId == id);
        }
    }
}