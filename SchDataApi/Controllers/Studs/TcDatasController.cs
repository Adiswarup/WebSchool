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
    [Route("api/TcDatas")]
    public class TcDatasController : Controller
    {
        private readonly SchContext _context;

        public TcDatasController(SchContext context)
        {
            _context = context;
        }

        // GET: api/TcDatas
        [HttpGet]
        public IEnumerable<TcData> GetTcData()
        {
            return _context.TcData;
        }

        // GET: api/TcDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTcData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tcData = await _context.TcData.SingleOrDefaultAsync(m => m.AutoId == id);

            if (tcData == null)
            {
                return NotFound();
            }

            return Ok(tcData);
        }

        // PUT: api/TcDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcData([FromRoute] int id, [FromBody] TcData tcData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tcData.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(tcData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcDataExists(id))
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

        // POST: api/TcDatas
        [HttpPost]
        public async Task<IActionResult> PostTcData([FromBody] TcData tcData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TcData.Add(tcData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTcData", new { id = tcData.AutoId }, tcData);
        }

        // DELETE: api/TcDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTcData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tcData = await _context.TcData.SingleOrDefaultAsync(m => m.AutoId == id);
            if (tcData == null)
            {
                return NotFound();
            }

            _context.TcData.Remove(tcData);
            await _context.SaveChangesAsync();

            return Ok(tcData);
        }

        private bool TcDataExists(int id)
        {
            return _context.TcData.Any(e => e.AutoId == id);
        }
    }
}