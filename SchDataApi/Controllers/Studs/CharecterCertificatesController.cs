using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Studs;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CharecterCertificates")]
    public class CharecterCertificatesController : Controller
    {
        private readonly SchContext _context;

        public CharecterCertificatesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/CharecterCertificates
        [HttpGet]
        public IEnumerable<CharecterCertificate> GetCharecterCertificate()
        {
            return _context.CharecterCertificate;
        }

        // GET: api/CharecterCertificates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharecterCertificate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charecterCertificate = await _context.CharecterCertificate.SingleOrDefaultAsync(m => m.AutoId == id);

            if (charecterCertificate == null)
            {
                return NotFound();
            }

            return Ok(charecterCertificate);
        }

        // PUT: api/CharecterCertificates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharecterCertificate([FromRoute] int id, [FromBody] CharecterCertificate charecterCertificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charecterCertificate.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(charecterCertificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharecterCertificateExists(id))
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

        // POST: api/CharecterCertificates
        [HttpPost]
        public async Task<IActionResult> PostCharecterCertificate([FromBody] CharecterCertificate charecterCertificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CharecterCertificate.Add(charecterCertificate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharecterCertificate", new { id = charecterCertificate.AutoId }, charecterCertificate);
        }

        // DELETE: api/CharecterCertificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharecterCertificate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charecterCertificate = await _context.CharecterCertificate.SingleOrDefaultAsync(m => m.AutoId == id);
            if (charecterCertificate == null)
            {
                return NotFound();
            }

            _context.CharecterCertificate.Remove(charecterCertificate);
            await _context.SaveChangesAsync();

            return Ok(charecterCertificate);
        }

        private bool CharecterCertificateExists(int id)
        {
            return _context.CharecterCertificate.Any(e => e.AutoId == id);
        }
    }
}