using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/StdFeeCats")]
    public class StdFeeCatsController : Controller
    {
        private readonly SchContext _context;
        private String MySql;

        public StdFeeCatsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/StdFeeCats
        [HttpGet]
        public IEnumerable<StdFeeCat> GetStdFeeCat(string dSess, int mdBId)
                    {
                List<StdFeeCat> StdFeeCatList = new List<StdFeeCat>();
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (var command = conn.CreateCommand())
                {

                    MySql = " SELECT StdCatID, StdCategory FROM StdCat WITH (NOLOCK)";
                    MySql = MySql + " WHERE  Dormant = 0";
                    MySql = MySql + " AND dBID = " + mdBId;
                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            StdFeeCat StdFeeCat = new StdFeeCat();
                            if (!kMyReader.IsDBNull(0)) { StdFeeCat.StdFeeCatId  = kMyReader.GetInt32(0); }
                            if (!kMyReader.IsDBNull(1)) { StdFeeCat.StdFeeCategory  = kMyReader.GetString(1); }
                            StdFeeCatList.Add(StdFeeCat);
                        }
                    }
                }
                return StdFeeCatList;
            }

        // GET: api/StdFeeCats/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetStdFeeCat([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var StdFeeCat = await _context.StdFeeCat.SingleOrDefaultAsync(m => m.AutoId == id);

        //    if (StdFeeCat == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(StdFeeCat);
        //}

        // PUT: api/StdFeeCats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStdFeeCat([FromRoute] int id, [FromBody] StdFeeCat StdFeeCat)
        {
            var ssid = StdFeeCat.StdFeeCatId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE StdCat SET ";
                    MySql = MySql + " StdCategory = '" + StdFeeCat.StdFeeCategory + "'";
                    MySql = MySql + " WHERE StdCatID = " + StdFeeCat.StdFeeCatId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + StdFeeCat.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdFeeCatExists(ssid))
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

        // POST: api/StdFeeCats
        [HttpPost]
        public async Task<IActionResult> PostStdFeeCat([FromBody] StdFeeCat StdFeeCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " INSERT INTO StdCat ( StdCatID, StdCategory, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + StdFeeCat.StdFeeCategory + "'";
                    MySql = MySql + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + Terminal + "'," + StdFeeCat.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetStdFeeCat", new { id = StdFeeCat.AutoId }, StdFeeCat);
        }

        // DELETE: api/StdFeeCats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStdFeeCat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StdFeeCat = await _context.StdFeeCat.SingleOrDefaultAsync(m => m.AutoId == id);
            if (StdFeeCat == null)
            {
                return NotFound();
            }

            _context.StdFeeCat.Remove(StdFeeCat);
            await _context.SaveChangesAsync();

            return Ok(StdFeeCat);
        }

        private bool StdFeeCatExists(int id)
        {
            return _context.StdFeeCat.Any(e => e.AutoId == id);
        }
    }
}