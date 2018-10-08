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
    [Route("api/PermissionTs")]
    public class PermissionTsController : Controller
    {
        private readonly SchContext _context;

        public PermissionTsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/PermissionTs
        [HttpGet]
        public IEnumerable<PermissionT> GetPermissionT()
        {
            return _context.PermissionT;
        }

        // GET: api/PermissionTs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionT([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permissionT = await _context.PermissionT.SingleOrDefaultAsync(m => m.AutoId == id);

            if (permissionT == null)
            {
                return NotFound();
            }

            return Ok(permissionT);
        }

        // PUT: api/PermissionTs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionT([FromRoute] int id, [FromBody] PermissionT permissionT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permissionT.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(permissionT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionTExists(id))
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

        // POST: api/PermissionTs
        [HttpPost]
        public async Task<IActionResult> PostPermissionT([FromBody] PermissionT permissionT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PermissionT.Add(permissionT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermissionT", new { id = permissionT.AutoId }, permissionT);
        }

        // DELETE: api/PermissionTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionT([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permissionT = await _context.PermissionT.SingleOrDefaultAsync(m => m.AutoId == id);
            if (permissionT == null)
            {
                return NotFound();
            }

            _context.PermissionT.Remove(permissionT);
            await _context.SaveChangesAsync();

            return Ok(permissionT);
        }

        private bool PermissionTExists(int id)
        {
            return _context.PermissionT.Any(e => e.AutoId == id);
        }
    }
}