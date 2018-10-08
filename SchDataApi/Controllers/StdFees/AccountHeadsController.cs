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
    [Route("api/AccountHeads")]
    public class AccountHeadsController : Controller
    {
        private readonly SchContext _context;

        public AccountHeadsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/AccountHeads
        [HttpGet]
        public IEnumerable<AccountHead> GetAccountHead()
        {
            return _context.AccountHead;
        }

        // GET: api/AccountHeads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountHead([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountHead = await _context.AccountHead.SingleOrDefaultAsync(m => m.AccId == id);

            if (accountHead == null)
            {
                return NotFound();
            }

            return Ok(accountHead);
        }

        // PUT: api/AccountHeads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountHead([FromRoute] int id, [FromBody] AccountHead accountHead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountHead.AccId)
            {
                return BadRequest();
            }

            _context.Entry(accountHead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountHeadExists(id))
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

        // POST: api/AccountHeads
        [HttpPost]
        public async Task<IActionResult> PostAccountHead([FromBody] AccountHead accountHead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountHead.Add(accountHead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountHead", new { id = accountHead.AccId }, accountHead);
        }

        // DELETE: api/AccountHeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountHead([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountHead = await _context.AccountHead.SingleOrDefaultAsync(m => m.AccId == id);
            if (accountHead == null)
            {
                return NotFound();
            }

            _context.AccountHead.Remove(accountHead);
            await _context.SaveChangesAsync();

            return Ok(accountHead);
        }

        private bool AccountHeadExists(int id)
        {
            return _context.AccountHead.Any(e => e.AccId == id);
        }
    }
}