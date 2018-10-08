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
using System.Data.Common;

using static SchDataApi.GenFunc.GloVar;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Teachers")]
    public class TeachersController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public TeachersController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public IEnumerable<Teachers> GetTeachers(string dSess, int mdBId)
        {
            List<Teachers> teachList = new List<Teachers>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                //TeachID, tName, Sex, tAge, tAddress, tTelephone, tQualification, tSalary, Grade, TeachEMail, TeachLoginName, Proficiency, PresentToday, LoginName, Dormant, ModTime, cTerminal, dBID

                MySql = " SELECT TeachID, tName, tTelephone, TEMail, TeachLoginName FROM Teachers WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " ORDER BY tName";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Teachers teachs = new Teachers();
                        if (!kMyReader.IsDBNull(0)) { teachs.teachId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { teachs.tName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { teachs.tTelephone  = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { teachs.teachEMail = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { teachs.teachLoginName = kMyReader.GetString(4); }
                        teachs.dBid = mdBId;
                        teachList.Add(teachs);
                    }
                }
            }
            return teachList;
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeachers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.AutoId == id);

            if (teachers == null)
            {
                return NotFound();
            }

            return Ok(teachers);
        }

        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachers([FromRoute] int id, [FromBody] Teachers teachers)
        {
            var tId = teachers.teachId ;
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
                {        //tName, Sex, tAge, tAddress, tTelephone, tQualification, tSalary, Grade, TeachEMail, TeachLoginName,
                    MySql = " UPDATE Teachers SET ";
                    MySql = MySql + " tName = '" + teachers.tName + "',";
                    MySql = MySql + " tTelephone = '" + teachers.tTelephone + "',";
                    MySql = MySql + " TEMail = '" + teachers.teachEMail + "',";
                    MySql = MySql + " TeachLoginName = '" + teachers.teachLoginName + "'";
                    MySql = MySql + " WHERE TeachID = " + teachers.teachId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + teachers.dBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists (tId))
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

        // POST: api/Teachers
        [HttpPost]
        public async Task<IActionResult> PostTeachers([FromBody] Teachers teachers)
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
                    MySql = " INSERT INTO Teachers ( TeachID, tName, tTelephone, TEMail, TeachLoginName,";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + teachers.tName + "','" + teachers.tTelephone + "','" + teachers.teachEMail + "','" + teachers.teachLoginName + "'";
                    MySql = MySql + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + Terminal + "'," + teachers.dBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetTeachers", new { id = teachers.AutoId }, teachers);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.AutoId == id);
            if (teachers == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();

            return Ok(teachers);
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.AutoId == id);
        }

        [HttpGet]
        [ActionName("GetTeachLst")]
        [Route("SelectMarks/GetTeachLst")]
        public async Task<List<Teachers>> GetTeachLst([FromBody ] Teachers teachers)
        {
            List<Teachers> teachList = new List<Teachers>();
            string MySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT  AutoID, TeachID, tName, tTelephone, TeachEMail, TeachLoginName ";
                MySql = MySql + " FROM Teachers WITH (NOLOCK) ";
                MySql = MySql + " WHERE Dormant =0 ";
                MySql = MySql + " AND DBID = " + teachers.dBid;
                //MySql = MySql + " AND DBID = " + mdBId;
                MySql = MySql + " ORDER BY tName";

                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Teachers teachs = new Teachers();
                        if (!kMyReader.IsDBNull(0)) { teachs.AutoId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { teachs.teachId = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) { teachs.tName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { teachs.tTelephone = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { teachs.teachEMail = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { teachs.teachLoginName = kMyReader.GetString(5); }
                        teachList.Add(teachs);
                    }
                }
                conn.Close();
                return teachList;
            }

        }

    }
}