using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Convey;
using System.Data;
using System.Data.Common;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Stops")]
    public class StopsController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public StopsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Stops
        [HttpGet]
        public IEnumerable<Stops> Get(int mdBId)
        {
            List<Stops> StopsList = new List<Stops>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT  StopID, ConveyanceMode, Stops, Circuit, MonthlyFare, FareFromMonth"
                    + " FROM Stops WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Stops stops = new Stops();
                        if (!kMyReader.IsDBNull(0)) { stops.stopId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { stops.drptext = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { stops.stops1 = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { stops.circuit = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { stops.monthlyFare = kMyReader.GetDouble(4); }
                        if (!kMyReader.IsDBNull(5)) { stops.fareFromMonth =DateTime.FromOADate( kMyReader.GetDouble(5)); }
                        StopsList.Add(stops);
                    }
                }
            }
            return StopsList;
        }

        // GET: api/Stops/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStops([FromRoute] int stopId, string dSess, int mdBId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT ConveyanceMode, Stops, Circuit, MonthlyFare, FareFromMonth "
                    + " FROM Stops WITH (NOLOCK)";
                MySql = MySql + " WHERE StopID = " + stopId;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;

                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    Stops stops = new Stops();
                    stops.stopId = stopId;
                    if (!kMyReader.IsDBNull(0)) { stops.drptext = kMyReader.GetString(0); }
                    if (!kMyReader.IsDBNull(1)) { stops.stops1 = kMyReader.GetString(1); }
                    if (!kMyReader.IsDBNull(2)) { stops.circuit = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { stops.monthlyFare = kMyReader.GetDouble(3); }
                    if (!kMyReader.IsDBNull(4)) { stops.fareFromMonth =DateTime.FromOADate( kMyReader.GetDouble(4)); }
                    return Ok(stops);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // PUT: api/Stops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStops([FromRoute] int id, [FromBody] Stops stops)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stops.stopId)
            {
                return BadRequest();
            }

            if (id != stops.stopId)
            {
                return BadRequest();
            }
            var stopid = stops.stopId;
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    //ConveyanceMode, Stops, Circuit, MonthlyFare, FareFromMonth
                    MySql = " UPDATE Stops SET ";
                    MySql = MySql + " ConveyanceMode = '" + stops.drptext + "',";
                    MySql = MySql + " Stops = '" + stops.stops1 + "',";
                    MySql = MySql + " Circuit = '" + stops.circuit + "',";
                    MySql = MySql + " MonthlyFare = " + stops.monthlyFare + ",";
                    MySql = MySql + " FareFromMonth = " +  stops.fareFromMonth.ToOADate() ;

                    MySql = MySql + " WHERE StopID = " + stops.stopId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + stops.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopsExists(stopid))
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

        // POST: api/Stops
        [HttpPost]
        public async Task<IActionResult> PostStops([FromBody] Stops stops)
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
                    MySql = " INSERT INTO Stops (  StopID, ConveyanceMode, Stops, Circuit, MonthlyFare, FareFromMonth,";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + stops.drptext + "','" + stops.stops1 + "','" + stops.circuit + "',";
                    MySql = MySql + stops.monthlyFare + "," + stops.fareFromMonth.ToOADate() + "'" ;
                    MySql = MySql + ", 0,'" + stops.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + stops.CTerminal + "'," + stops.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetStops", new { id = stops.AutoId }, stops);
        }

        // DELETE: api/Stops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStops([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stops = await _context.Stops.SingleOrDefaultAsync(m => m.AutoId == id);
            if (stops == null)
            {
                return NotFound();
            }

            _context.Stops.Remove(stops);
            await _context.SaveChangesAsync();

            return Ok(stops);
        }

        private bool StopsExists(int id)
        {
            return _context.Stops.Any(e => e.stopId == id);
        }
    }
}