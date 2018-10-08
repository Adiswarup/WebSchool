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
    [Route("api/AcaSessions")]
    public class AcaSessionsController : Controller
    {
        private readonly SchContext _context;
        private String MySql;
        public AcaSessionsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/AcaSessions
        [HttpGet]
        public IEnumerable<AcaSession> Get(int mdBID)
        {
            List<AcaSession> acaSessList = new List<AcaSession>();
            var conn = _context.Database.GetDbConnection();

            var queryString = Request.Query;
            var skip = Convert.ToInt32(queryString["$skip"]);
            var take = Convert.ToInt32(queryString["$top"]);
            if (take <= 0)
            {
                take = 10;
            }
            if (conn.State == ConnectionState.Closed)
            {
                 conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                 
                MySql = " SELECT SSDID, SessionName, SessionStartDate, SessionEndDate FROM AcaSession WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBID;
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader =  command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        AcaSession acaSess = new AcaSession();
                        if (!kMyReader.IsDBNull(0)) { acaSess.Ssdid = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { acaSess.SessionName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { acaSess.SessionStartDate = GenFunc.GloFunc .FromOADate (   kMyReader.GetDouble(2)); }
                        if (!kMyReader.IsDBNull(3)) { acaSess.SessionEndDate = GenFunc.GloFunc .FromOADate (  kMyReader.GetDouble(3)); }
                        acaSessList.Add(acaSess);
                    }
                }
            }
            //return Json(new { result = acaSessList.Skip(skip).Take(take), count = acaSessList.Count() });
            return  acaSessList;
        }

        // GET: api/AcaSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcaSession([FromRoute] int id ,string dSess, int mdBId)
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
                MySql = " SELECT SessionName, SessionStartDate, SessionEndDate FROM AcaSession WITH (NOLOCK)";
                MySql = MySql + " WHERE SSDID = " + id;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;

                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    AcaSession acaSess = new AcaSession();
                    acaSess.Ssdid = id;
                    if (!kMyReader.IsDBNull(0)) { acaSess.SessionName = kMyReader.GetString(0); }
                    if (!kMyReader.IsDBNull(1)) { acaSess.SessionStartDate =  GenFunc.GloFunc. FromOADate( kMyReader.GetDouble(1)); }
                    if (!kMyReader.IsDBNull(2)) { acaSess.SessionEndDate =  (GenFunc.GloFunc. FromOADate( kMyReader.GetDouble(2))); }
                    return Ok(acaSess);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // PUT: api/AcaSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcaSession( [FromBody] AcaSession acaSession)
        {
            var ssid = acaSession.Ssdid;
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
                    MySql = " UPDATE AcaSession SET ";
                    MySql = MySql + " SessionName = '" + acaSession.SessionName;
                    MySql = MySql + "', SessionStartDate = " + GenFunc.GloFunc.ToOADate(acaSession.SessionStartDate);
                    MySql = MySql + ", SessionEndDate = " + GenFunc.GloFunc.ToOADate(acaSession.SessionEndDate);
                    MySql = MySql + " WHERE SSDID = " + acaSession.Ssdid;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + acaSession.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                    //UpdateAcaSession(acaSession);
                    //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaSessionExists(ssid))
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

        // POST: api/AcaSessions
        [HttpPost]
        public async Task<IActionResult> PostAcaSession([FromBody] AcaSession acaSession)
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
                    MySql = " INSERT INTO AcaSession (ssdid, SessionName, SessionStartDate, SessionEndDate, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + acaSession.SessionName + "'," + GenFunc.GloFunc.ToOADate(acaSession.SessionStartDate) + ",";
                    MySql = MySql + GenFunc.GloFunc.ToOADate(acaSession.SessionEndDate) + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now) ;
                    MySql = MySql + ",'" + Terminal + "'," + acaSession.DBid + ")";

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

            //_context.AcaSession.Add(acaSession);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcaSession", new { id = acaSession.AutoId }, acaSession);
        }

        // DELETE: api/AcaSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcaSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acaSession = await _context.AcaSession.SingleOrDefaultAsync(m => m.AutoId == id);
            if (acaSession == null)
            {
                return NotFound();
            }

            _context.AcaSession.Remove(acaSession);
            await _context.SaveChangesAsync();

            return Ok(acaSession);
        }

        private bool AcaSessionExists(int id)
        {
            return _context.AcaSession.Any(e => e.AutoId == id);
        }
    }
}