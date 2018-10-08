using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Fcaptions")]
    public class FcaptionsController : Controller
    {
        private readonly SchContext _context;
        string MySql = "";

        public FcaptionsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Fcaptions
        [HttpGet]
        public IEnumerable<Fcaption> GetFcaption(string dSess, int mDbId)
        {
            List<Fcaption> stdfCapList = new List<Fcaption>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT  FeeNameId, FeeCaption, FeeDuration, FeeType, FeeOrder, ShowIt";
                MySql = MySql + " FROM FCaption WITH (NOLOCK) ";
                MySql = MySql + " WHERE Dormant =0 ";
                MySql = MySql + " AND DBID =  " + mDbId;
                MySql = MySql + " ORDER BY FeeCaption";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Fcaption fCaps = new Fcaption();
                        if (!kMyReader.IsDBNull(0)) { fCaps.FeeNameId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { fCaps.FeeCaption = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { fCaps.FeeDuration = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { fCaps.FeeType = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { fCaps.FeeOrder = kMyReader.GetInt32(4); }
                        if (!kMyReader.IsDBNull(5)) { fCaps.ShowIt =CIB( kMyReader.GetInt32(5)); }
                       stdfCapList.Add(fCaps);
                    }
                }
                    kMyReader.Close();
            }
            return stdfCapList;
            //return _context.Fcaption;
        }

        // GET: api/Fcaptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFcaption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fcaption = await _context.Fcaption.SingleOrDefaultAsync(m => m.AutoId == id);

            if (fcaption == null)
            {
                return NotFound();
            }

            return Ok(fcaption);
        }

        // PUT: api/Fcaptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFcaption([FromRoute] int id, [FromBody] Fcaption fcaption)
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
                    MySql = " UPDATE FCaption SET ";
                    MySql = MySql + " FeeCaption = '" + fcaption.FeeCaption + "',";
                    MySql = MySql + " FeeDuration = '" + fcaption.FeeDuration + "',";
                    MySql = MySql + " FeeType = '" + fcaption.FeeType + "',";
                    MySql = MySql + " ShowIt = " + CBI(fcaption.ShowIt) + ",";
                    MySql = MySql + " FeeOrder = " + fcaption.FeeOrder + "";
                    MySql = MySql + " WHERE FeeNameId = " + fcaption.FeeNameId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + fcaption.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FcaptionExists(id))
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

        // POST: api/Fcaptions
        [HttpPost]
        public async Task<IActionResult> PostFcaption([FromBody] Fcaption fcaption)
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
                    MySql = " INSERT INTO FCaption(FeeNameId, FeeCaption, FeeDuration, FeeType, FeeOrder, ShowIt,";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + fcaption.FeeCaption + "','" + fcaption.FeeDuration + "','"
                        + fcaption.FeeType + "'," + fcaption.FeeOrder + "," + CBI( fcaption.ShowIt)  ;
                    MySql = MySql + ",0,'" + fcaption.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + fcaption.CTerminal + "'," + fcaption.DBid + ")";
                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetFcaption", new { id = fcaption.FeeNameId }, fcaption);
        }

        // DELETE: api/Fcaptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFcaption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fcaption = await _context.Fcaption.SingleOrDefaultAsync(m => m.AutoId == id);
            if (fcaption == null)
            {
                return NotFound();
            }

            _context.Fcaption.Remove(fcaption);
            await _context.SaveChangesAsync();

            return Ok(fcaption);
        }

        private bool FcaptionExists(int id)
        {
            return _context.Fcaption.Any(e => e.AutoId == id);
        }
    }
}