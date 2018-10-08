using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Studs;
using static SchDataApi.GenFunc.StdFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/SearchStds")]
    public class SearchStdsController : Controller
    {
        private readonly SchContext _context;

        public SearchStdsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/SearchStds
        [HttpGet]
        public async Task<List<Students>> GetSearchStdAsync(string SClass, string tSearchStr , string dSess,int  mdBID )
        {
           return await GetStdList(_context, mdBID,dSess, SClass, tSearchStr);
        }

        // GET: api/SearchStds/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSearchStd([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var searchStd = await _context.SearchStd.SingleOrDefaultAsync(m => m.SStdID == id);

        //    if (searchStd == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(searchStd);
        //}

        // PUT: api/SearchStds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearchStd([FromRoute] int id, [FromBody] SearchStd searchStd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != searchStd.SStdID)
            {
                return BadRequest();
            }

            _context.Entry(searchStd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchStdExists(id))
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

        // POST: api/SearchStds
        [HttpPost]
        public async Task<IActionResult> PostSearchStd([FromBody] SearchStd searchStd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SearchStd.Add(searchStd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSearchStd", new { id = searchStd.SStdID }, searchStd);
        }

        // DELETE: api/SearchStds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchStd([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var searchStd = await _context.SearchStd.SingleOrDefaultAsync(m => m.SStdID == id);
            if (searchStd == null)
            {
                return NotFound();
            }

            _context.SearchStd.Remove(searchStd);
            await _context.SaveChangesAsync();

            return Ok(searchStd);
        }

        private bool SearchStdExists(int id)
        {
            return _context.SearchStd.Any(e => e.SStdID == id);
        }
    }
}