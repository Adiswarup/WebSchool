using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Basics;
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
    [Route("api/StdCats")]
    public class StdCatsController : Controller
    {
        private readonly SchContext _context;
        private String MySql;

        public StdCatsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/StdCats
        [HttpGet]
        public IEnumerable<StdCat> GetStdCat(int mdBId)
                    {
                List<StdCat> stdCatList = new List<StdCat>();
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (var command = conn.CreateCommand())
                {

                    MySql = " SELECT StdCatID, StdCategory FROM stdCat WITH (NOLOCK)";
                    MySql = MySql + " WHERE  Dormant = 0";
                    MySql = MySql + " AND dBID = " + mdBId;
                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            StdCat stdCat = new StdCat();
                            if (!kMyReader.IsDBNull(0)) { stdCat.StdCatId  = kMyReader.GetInt32(0); }
                            if (!kMyReader.IsDBNull(1)) { stdCat.StdCategory  = kMyReader.GetString(1); }
                            stdCatList.Add(stdCat);
                        }
                    }
                }
                return stdCatList;
            }

        // GET: api/StdCats/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetStdCat([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var stdCat = await _context.StdCat.SingleOrDefaultAsync(m => m.AutoId == id);

        //    if (stdCat == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(stdCat);
        //}

        // PUT: api/StdCats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStdCat([FromRoute] int id, [FromBody] StdCat stdCat)
        {
            var ssid = stdCat.StdCatId;
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
                    MySql = MySql + " StdCategory = '" + stdCat.StdCategory + "'";
                    MySql = MySql + " WHERE StdCatID = " + stdCat.StdCatId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + stdCat.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdCatExists(ssid))
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

        // POST: api/StdCats
        [HttpPost]
        public async Task<IActionResult> PostStdCat([FromBody] StdCat stdCat)
        {
            int HasCat = 0;
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
                    MySql = "SELECT StdCatID FROM StdCat";
                    MySql = MySql + " WHERE Dormant = 0";
                    MySql = MySql + " AND StdCategory = '" + stdCat.StdCategory + "'";
                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        HasCat = 1;
                        return BadRequest();
                         }
                    kMyReader.Close();
                    if (HasCat == 0)
                    {
                        MySql = " INSERT INTO StdCat ( StdCatID, StdCategory, ";
                        MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                        MySql = MySql + stdCat.StdCategory + "'";
                        MySql = MySql + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                        MySql = MySql + ",'" + Terminal + "'," + stdCat.DBid + ")";

                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    }
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetStdCat", new { id = stdCat.AutoId }, stdCat);
        }

        // DELETE: api/StdCats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStdCat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdCat = await _context.StdCat.SingleOrDefaultAsync(m => m.AutoId == id);
            if (stdCat == null)
            {
                return NotFound();
            }

            _context.StdCat.Remove(stdCat);
            await _context.SaveChangesAsync();

            return Ok(stdCat);
        }

        private bool StdCatExists(int id)
        {
            return _context.StdCat.Any(e => e.AutoId == id);
        }
    }
}