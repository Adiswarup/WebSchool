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
    [Route("api/Circuits")]
    public class CircuitsController : Controller
    {
        private readonly SchContext _context;

        public CircuitsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Circuits
        [HttpGet]
        public IEnumerable<Circuit> GetCircuit()
        {
            return _context.Circuit;
        }

        // GET: api/Circuits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCircuit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var circuit = await _context.Circuit.SingleOrDefaultAsync(m => m.AutoId == id);

            if (circuit == null)
            {
                return NotFound();
            }

            return Ok(circuit);
        }

        // PUT: api/Circuits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCircuit([FromRoute] int id, [FromBody] Circuit circuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != circuit.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(circuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitExists(id))
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

        // POST: api/Circuits
        [HttpPost]
        public async Task<IActionResult> PostCircuit([FromBody] Circuit circuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Circuit.Add(circuit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCircuit", new { id = circuit.AutoId }, circuit);
        }

        // DELETE: api/Circuits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCircuit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var circuit = await _context.Circuit.SingleOrDefaultAsync(m => m.AutoId == id);
            if (circuit == null)
            {
                return NotFound();
            }

            _context.Circuit.Remove(circuit);
            await _context.SaveChangesAsync();

            return Ok(circuit);
        }

        private bool CircuitExists(int id)
        {
            return _context.Circuit.Any(e => e.AutoId == id);
        }
    }
}