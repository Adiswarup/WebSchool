using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Active;
using System.Data;
using System.Data.Common;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Attendances")]
    public class AttendancesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public AttendancesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]
        public IEnumerable<Attendance> Get(string clss,  string atType, float atDate, string dSess, int mdBId)
        {
            string fName = "";
            string mName = "";
            string lName = "";
            List<Attendance> stdAttList = new List<Attendance>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT  RegNumber, FirstName, MiddleName, LastName, PresentRollNo, Photo FROM Students  WITH (NOLOCK) ";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND PresentClass = '" + clss + "'";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND StdStatus <= 0";
                MySql = MySql + " ORDER BY PresentRollNo";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Attendance atts = new Attendance();

                        if (!kMyReader.IsDBNull(0)) { atts.RegNum = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { fName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { mName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { lName = kMyReader.GetString(3); }
                        atts.StdName = fName + " " + mName + " " + lName;
                        if (!kMyReader.IsDBNull(4)) { atts.clsRoll = kMyReader.GetInt32(4); }
                        if (!kMyReader.IsDBNull(5)) {
                            atts.ImgDataURL = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])(kMyReader.GetValue(5))));
                        }
                        stdAttList.Add(atts);
                    }
                }
                kMyReader.Close();
                MySql = " SELECT AttID, RegNum, isAbsent, Cause, Remark FROM Attendance WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND AttDate = " + (int)atDate;
                MySql = MySql + " AND AtType = '" + atType + "'";
                MySql = MySql + " AND AcaSession = '" + dSess + "'";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        int nwLoopVal = -1;
                        foreach (Attendance atts in stdAttList)
                        {
                            if (!kMyReader.IsDBNull(1)) {
                                if (atts.RegNum == kMyReader.GetInt32(1))
                                {
                                    atts.AttId = kMyReader.GetInt32(0);
                                    atts.isAbsent = CIB(kMyReader.GetInt32(2));
                                    atts.Cause = kMyReader.GetString(3);
                                    atts.Remark = kMyReader.GetString(4);
                                }
                            }
                            
                        }                         
                    }
                }
                kMyReader.Close();
            }
            return stdAttList;
        }

        // GET: api/Attendances/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAttendance([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AutoId == id);

        //    if (attendance == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(attendance);
        //}

        // PUT: api/Attendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance([FromRoute] int id, [FromBody] Attendance attendance)
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
                    //if (attendance.AttId != 0)
                    //{
                        MySql = " UPDATE Attendance SET "
                                + " Dormant = 1 "
                                + " WHERE Dormant = 0  "
                                + " AND AttDate = " +  attendance.AttDate.ToOADate().ToString() 
                                + " AND RegNum = " + attendance.RegNum
                                + " AND AcaSession = '" + attendance.AcaSession + "'";
                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    //}
                    MySql = " INSERT INTO Attendance ( RegNum, Clss, Month, Year, AttDate, AtType, isAbsent, AcaSession, Cause, Remark,"
                            + " Dormant, LoginName, ModTime, cTerminal, dBID) Values ("
                            + attendance.RegNum + ",'" + attendance.Clss + "'," + (attendance.AttDate).Month + "," + (attendance.AttDate).Year + ","
                            +  attendance.AttDate.ToOADate().ToString()  + ",'" + attendance.AtType + "'," + CBI(attendance.isAbsent) + ",'" + attendance.AcaSession + "','" + attendance.Cause + "','" + attendance.Remark
                            + "', 0,'" + attendance.LoginName + "'," +  DateTime.Now.Date.ToOADate()
                            + ",'" + attendance.CTerminal + "'," + attendance.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            //_context.Entry(attendance).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AttendanceExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Attendances
        [HttpPost]
        public async Task<IActionResult> PostAttendance([FromBody] Attendance attendance)
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
                    //if (attendance.AttId != 0)
                    //{
                        MySql = " UPDATE Attendance SET "
                                + " Dormant = 1 "
                                + " WHERE Dormant = 0  "
                                + " AND AttDate = " + GenFunc.GloFunc.ToOADate(attendance.AttDate)
                                + " AND RegNum = " + attendance.RegNum
                                + " AND AcaSession = '" + attendance.AcaSession  + "'";
                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    //}
                    MySql = " INSERT INTO Attendance ( RegNum, Clss, Month, Year, AttDate, AcaSession, Cause, Remark,"
                            + " Dormant, LoginName, ModTime, cTerminal, dBID) Values ("
                            + attendance.RegNum + ",'" + attendance.Clss + "'," + (attendance.AttDate).Month + "," + (attendance.AttDate).Year + ","
                            + GenFunc.GloFunc.ToOADate(attendance.AttDate) + ",'" + attendance.AcaSession + "','" + attendance.Cause + "','" + attendance.Remark
                            + "', 0,'" + attendance.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now)
                            + ",'" + attendance.CTerminal + "'," + attendance.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetAttendance", new { id = attendance.AutoId }, attendance);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AutoId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AutoId == id);
        }
    }
}