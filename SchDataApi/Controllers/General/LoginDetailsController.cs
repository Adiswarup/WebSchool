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
    [Route("api/LoginDetails")]
    public class LoginDetailsController : Controller
    {
        private readonly SchContext _context;

        public LoginDetailsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/LoginDetails
        [HttpGet]
        public IEnumerable<LoginDetails> GetLoginDetails()
        {
            return _context.LoginDetails;
        }

        // GET: api/LoginDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoginDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginDetails = await _context.LoginDetails.SingleOrDefaultAsync(m => m.AutoId == id);

            if (loginDetails == null)
            {
                return NotFound();
            }

            return Ok(loginDetails);
        }

        // PUT: api/LoginDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginDetails([FromRoute] int id, [FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginDetails.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(loginDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginDetailsExists(id))
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

        // POST: api/LoginDetails
        [HttpPost]
        public async Task<IActionResult> PostLoginDetails([FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LoginDetails.Add(loginDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginDetails", new { id = loginDetails.AutoId }, loginDetails);
        }

        // DELETE: api/LoginDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginDetails = await _context.LoginDetails.SingleOrDefaultAsync(m => m.AutoId == id);
            if (loginDetails == null)
            {
                return NotFound();
            }

            _context.LoginDetails.Remove(loginDetails);
            await _context.SaveChangesAsync();

            return Ok(loginDetails);
        }

        private bool LoginDetailsExists(int id)
        {
            return _context.LoginDetails.Any(e => e.AutoId == id);
        }
    }
}