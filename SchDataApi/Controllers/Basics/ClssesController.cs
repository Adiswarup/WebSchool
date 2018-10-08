using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Basics;
using System.Data;
using static SchDataApi.GenFunc.GloVar;
using System.Data.Common;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clsses")]
    public class ClssesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public ClssesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Clsses
        [HttpGet]
        public IEnumerable<Clss> Get(string sess, int mdBId)
        {
            List<Clss> clssList = new List<Clss>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT ClsId, ClsName, ClassTeacher, ClssNum FROM Clss WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                if (sess != "All") MySql = MySql + " AND AcaSession = '" + sess + "'";
                
               command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Clss clss = new Clss();
                        if (!kMyReader.IsDBNull(0)) { clss.ClsId  = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { clss.ClsName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { clss.ClassTeacher = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { clss.ClssNum = kMyReader.GetDouble(3); }
                        clssList.Add(clss);
                    }
                }
            }
            return clssList;
        }

        // GET: api/Clsses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClss([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clss = await _context.Clss.SingleOrDefaultAsync(m => m.AutoId == id);

            if (clss == null)
            {
                return NotFound();
            }

            return Ok(clss);
        }

        // PUT: api/Clsses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClss([FromRoute] int id, [FromBody] Clss clss)
        {
            var ssid = clss.ClsId;
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
                    MySql = " UPDATE Clss SET ";
                    MySql = MySql + " ClsName = '" + clss.ClsName + "',";
                    MySql = MySql + " ClassTeacher = '" + clss.ClassTeacher + "',";
                     MySql = MySql + " ClssNum = " + clss.ClssNum ;
                   MySql = MySql + " WHERE ClsId = " + clss.ClsId ;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + clss.DBid;
                    MySql = MySql + " AND AcaSession = '" + clss.AcaSession + "'";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClssExists(ssid))
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

        // POST: api/Clsses
        [HttpPost]
        public async Task<IActionResult> PostClss([FromBody] Clss clss)
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
                    MySql = " INSERT INTO Clss (ClsId, ClsName, TeachID, ClassTeacher, StdStrength, ClssNum, AcaSession";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + clss.ClsName + "','" + clss.TeachId + "','" + clss.ClassTeacher + "','" + clss.StdStrength
                        + clss.ClssNum + "','" + clss.AcaSession + "'";

                    MySql = MySql + "', 0,'" + clss.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + clss.CTerminal + "'," + clss.DBid + ")";

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

            //_context.Clss.Add(clss);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetClss", new { id = clss.AutoId }, clss);
        }

        // DELETE: api/Clsses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClss([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clss = await _context.Clss.SingleOrDefaultAsync(m => m.AutoId == id);
            if (clss == null)
            {
                return NotFound();
            }

            _context.Clss.Remove(clss);
            await _context.SaveChangesAsync();

            return Ok(clss);
        }

        private bool ClssExists(int id)
        {
            return _context.Clss.Any(e => e.AutoId == id);
        }
    }
}