using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Convey;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/VonRts")]
    public class VonRtsController : Controller
    {
        private readonly SchContext _context;

        public VonRtsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/VonRts
        [HttpGet]
        public IEnumerable<VonRt> GetVonRt()
        {
            return _context.VonRt;
        }

        // GET: api/VonRts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVonRt([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vonRt = await _context.VonRt.SingleOrDefaultAsync(m => m.AutoId == id);

            if (vonRt == null)
            {
                return NotFound();
            }

            return Ok(vonRt);
        }

        // PUT: api/VonRts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVonRt([FromRoute] int id, [FromBody] VonRt vonRt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vonRt.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(vonRt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VonRtExists(id))
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

        // POST: api/VonRts
        [HttpPost]
        public async Task<IActionResult> PostVonRt([FromBody] VonRt vonRt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VonRt.Add(vonRt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVonRt", new { id = vonRt.AutoId }, vonRt);
        }

        // DELETE: api/VonRts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVonRt([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vonRt = await _context.VonRt.SingleOrDefaultAsync(m => m.AutoId == id);
            if (vonRt == null)
            {
                return NotFound();
            }

            _context.VonRt.Remove(vonRt);
            await _context.SaveChangesAsync();

            return Ok(vonRt);
        }

        private bool VonRtExists(int id)
        {
            return _context.VonRt.Any(e => e.AutoId == id);
        }
    }
}