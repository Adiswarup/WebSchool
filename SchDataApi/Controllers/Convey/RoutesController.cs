using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Convey;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Routes")]
    public class RoutesController : Controller
    {
        private readonly SchContext _context;

        public RoutesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public IEnumerable<Routes> GetRoutes()
        {
            return _context.Routes;
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoutes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var routes = await _context.Routes.SingleOrDefaultAsync(m => m.AutoId == id);

            if (routes == null)
            {
                return NotFound();
            }

            return Ok(routes);
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutes([FromRoute] int id, [FromBody] Routes routes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != routes.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(routes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutesExists(id))
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

        // POST: api/Routes
        [HttpPost]
        public async Task<IActionResult> PostRoutes([FromBody] Routes routes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Routes.Add(routes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutes", new { id = routes.AutoId }, routes);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var routes = await _context.Routes.SingleOrDefaultAsync(m => m.AutoId == id);
            if (routes == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(routes);
            await _context.SaveChangesAsync();

            return Ok(routes);
        }

        private bool RoutesExists(int id)
        {
            return _context.Routes.Any(e => e.AutoId == id);
        }
    }
}