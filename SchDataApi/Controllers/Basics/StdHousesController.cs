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
    [Route("api/StdHouses")]
    public class StdHousesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public StdHousesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/StdHouses
        [HttpGet]
        public IEnumerable<StdHouse> GetStdHouse(int mdBId)
        {
            List<StdHouse> stdHouseList = new List<StdHouse>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT StdHouseID, StdHouse FROM StdHouse WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        StdHouse stdHouse = new StdHouse();
                        if (!kMyReader.IsDBNull(0)) { stdHouse.StdHouseId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { stdHouse.StHouse = kMyReader.GetString(1); }
                        stdHouseList.Add(stdHouse);
                    }
                }
            }
            return stdHouseList;
        }

        // GET: api/StdHouses/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetStdHouse([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var stdHouse = await _context.StdHouse.SingleOrDefaultAsync(m => m.AutoId == id);

        //    if (stdHouse == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(stdHouse);
        //}

        // PUT: api/StdHouses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStdHouse([FromRoute] int id, [FromBody] StdHouse stdHouse)
        {
            var ssid = stdHouse.StdHouseId;
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
                    MySql = " UPDATE StdHouse SET ";
                    MySql = MySql + " StdHouse = '" + stdHouse.StHouse + "'";
                    MySql = MySql + " WHERE StdHouseID = " + stdHouse.StdHouseId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + stdHouse.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdHouseExists(ssid))
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

        // POST: api/StdHouses
        [HttpPost]
        public async Task<IActionResult> PostStdHouse([FromBody] StdHouse stdHouse)
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
                    MySql = " INSERT INTO StdHouse ( StdHouseID, StdHouse, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + stdHouse.StHouse  + "'";
                    MySql = MySql + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + Terminal + "'," + stdHouse.DBid + ")";

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
            return CreatedAtAction("GetStdHouse", new { id = stdHouse.StdHouseId }, stdHouse);
        }

        // DELETE: api/StdHouses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStdHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stdHouse = await _context.StdHouse.SingleOrDefaultAsync(m => m.AutoId == id);
            if (stdHouse == null)
            {
                return NotFound();
            }

            _context.StdHouse.Remove(stdHouse);
            await _context.SaveChangesAsync();

            return Ok(stdHouse);
        }

        private bool StdHouseExists(int id)
        {
            return _context.StdHouse.Any(e => e.AutoId == id);
        }
    }
}