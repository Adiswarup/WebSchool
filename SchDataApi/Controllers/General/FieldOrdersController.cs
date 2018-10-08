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
    [Route("api/FieldOrders")]
    public class FieldOrdersController : Controller
    {
        private readonly SchContext _context;

        public FieldOrdersController(SchContext context)
        {
            _context = context;
        }

        // GET: api/FieldOrders
        [HttpGet]
        public IEnumerable<FieldOrder> GetFieldOrder()
        {
            return _context.FieldOrder;
        }

        // GET: api/FieldOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFieldOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fieldOrder = await _context.FieldOrder.SingleOrDefaultAsync(m => m.AutoId == id);

            if (fieldOrder == null)
            {
                return NotFound();
            }

            return Ok(fieldOrder);
        }

        // PUT: api/FieldOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFieldOrder([FromRoute] int id, [FromBody] FieldOrder fieldOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fieldOrder.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(fieldOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldOrderExists(id))
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

        // POST: api/FieldOrders
        [HttpPost]
        public async Task<IActionResult> PostFieldOrder([FromBody] FieldOrder fieldOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FieldOrder.Add(fieldOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFieldOrder", new { id = fieldOrder.AutoId }, fieldOrder);
        }

        // DELETE: api/FieldOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFieldOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fieldOrder = await _context.FieldOrder.SingleOrDefaultAsync(m => m.AutoId == id);
            if (fieldOrder == null)
            {
                return NotFound();
            }

            _context.FieldOrder.Remove(fieldOrder);
            await _context.SaveChangesAsync();

            return Ok(fieldOrder);
        }

        private bool FieldOrderExists(int id)
        {
            return _context.FieldOrder.Any(e => e.AutoId == id);
        }
    }
}