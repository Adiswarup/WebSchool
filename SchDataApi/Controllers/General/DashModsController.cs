using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashModsController : ControllerBase
    {
        private readonly SchContext _context;
        string MySql = "";

        public DashModsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/DashMods
        [HttpGet]
        public DashMod GetDashMod(double actDate, string dSess, int mDbId)
        {
            DashMod dashMod = new DashMod();
            List<DashActivity> dashActList = new List<DashActivity>();
            List<DashAttendance> dashAttList = new List<DashAttendance>();
            List<DashFees> dashFeeList = new List<DashFees>();
            List<DashAttClss> dashAttClssList = new List<DashAttClss>();
            dashMod.DBid = mDbId;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT top(20) TransActName, ActivityID, TransActivity.RegNumber, Students.FirstName, Students.PresentRollNo, Students.PresentClass, ";
                MySql = MySql + " TransActObserver, TeachID, TransActRemarks";
                MySql = MySql + " FROM TransActivity WITH(NOLOCK)  INNER JOIN Students ON  Students.RegNumber = TransActivity.RegNumber";
                MySql = MySql + " WHERE TransActivity.TransActDate = " + actDate;
                MySql = MySql + " AND Students.StdSession='" + repSplChr(dSess) + "'";
                MySql = MySql + " AND TransActivity.Dormant = 0 ";
                MySql = MySql + " AND TransActivity.DBID =  " + mDbId;
                MySql = MySql + " ORDER BY TransActivity.AutoID Desc";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        DashActivity acts = new DashActivity();
                        acts.ActivityGroup = "";
                        if (!kMyReader.IsDBNull(0)) { acts.Activity = kMyReader.GetString(0); }
                        if (!kMyReader.IsDBNull(1)) { acts.ActivityID = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) { acts.RegNum = kMyReader.GetInt32(2).ToString(); }
                        if (!kMyReader.IsDBNull(3)) { acts.Name = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { acts.Roll = kMyReader.GetInt32(4).ToString(); }
                        if (!kMyReader.IsDBNull(5)) { acts.Clss = kMyReader.GetString(5); }
                        //if (!kMyReader.IsDBNull(6)) { acts.LoggedBY = kMyReader.GetInt32(6); }
                        if (!kMyReader.IsDBNull(8)) { acts.Remark = kMyReader.GetString(8); }
                        dashActList.Add(acts);
                    }
                }
                kMyReader.Close();
                dashMod.DashActivities = dashActList;

                MySql = "SELECT top(20) RegNum, Clss, Students.FirstName, Students.PresentRollNo, ";
                MySql = MySql + " AtType, Cause, Remark";
                MySql = MySql + " FROM Attendance WITH(NOLOCK)  INNER JOIN Students ON  Students.RegNumber = Attendance.RegNum ";
                MySql = MySql + " WHERE Attendance.AttDate = " + actDate;
                MySql = MySql + " AND Attendance.AcaSession = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Attendance.isAbsent = 0 ";
                MySql = MySql + " AND Attendance.DBID =  " + mDbId;
                //MySql = MySql + " AND Students.DBID =  " + mDbId;
                MySql = MySql + " ORDER BY Attendance.AutoID Desc";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        DashAttendance atts = new DashAttendance();
                        if (!kMyReader.IsDBNull(0)) { atts.RegNum = kMyReader.GetInt32(0).ToString(); }
                        if (!kMyReader.IsDBNull(1)) { atts.Clss = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { atts.Name = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { atts.Roll = kMyReader.GetInt32(3).ToString(); }
                        if (!kMyReader.IsDBNull(4)) { atts.AtType = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { atts.Cause = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { atts.Remarks = kMyReader.GetString(6); }
                        //if (!kMyReader.IsDBNull(7)) { atts.Roll = kMyReader.GetString(7); }
                        dashAttList.Add(atts);
                    }
                }
                kMyReader.Close();
                dashMod.DashAttendances = dashAttList;
                MySql = "SELECT SUM(AmountPaid) ";
                MySql = MySql + " FROM Receipt";
                MySql = MySql + " WHERE ReceiptDate  = " + actDate;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND  DBID = " + mDbId;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                        if (!kMyReader.IsDBNull(0)) {
                        dashMod.TodaysFeeCollection = kMyReader.GetDouble(0).ToString();
                    }
                    else
                    {
                        dashMod.TodaysFeeCollection = "0.00";
                    }
                }
                kMyReader.Close();
                MySql = "SELECT top(20) Receipt.RegNo, Receipt.ForPeriod, Receipt.AmountPaid, Receipt.FeeHeading, Students.FirstName, Students.PresentClass ";
                MySql = MySql + " FROM Receipt WITH (NOLOCK) INNER JOIN Students ON Students.RegNumber = Receipt.RegNo ";
                MySql = MySql + " WHERE Receipt.ReceiptDate = " + actDate;
                MySql = MySql + " AND Receipt.AcaSession = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Receipt.DBID =  " + mDbId;
                //MySql = MySql + " AND Students.DBID =  " + mDbId;
                MySql = MySql + " AND Receipt.Dormant = 0 ";
                //MySql = MySql + " AND Students.Dormant = 0 " ;
                MySql = MySql + " ORDER BY Receipt.AutoID Desc";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        DashFees atts = new DashFees();
                        if (!kMyReader.IsDBNull(0)) { atts.RegNum = kMyReader.GetInt32(0).ToString(); }
                        if (!kMyReader.IsDBNull(1)) { atts.FeeDate = DateTime.FromOADate( kMyReader.GetDouble(1)); }
                        if (!kMyReader.IsDBNull(2)) { atts.Amount =(int) kMyReader.GetDouble(2) ; }
                        if (!kMyReader.IsDBNull(3)) { atts.FeeName = kMyReader.GetString(3) ; }
                        if (!kMyReader.IsDBNull(4)) { atts.Name = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { atts.Clss = kMyReader.GetString(5); }
                        dashFeeList.Add(atts);
                    }
                }
                kMyReader.Close();
                dashMod.DashFeess = dashFeeList;
                DashAttClss attCs;
                MySql = "SELECT Count(RegNum), Clss  ";
                MySql = MySql + " FROM Attendance";
                MySql = MySql + " WHERE isAbsent = 0";
                MySql = MySql + " AND DBID =  " + mDbId;
                MySql = MySql + " AND Dormant = 0 ";
                MySql = MySql + " GROUP BY Clss";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        attCs = new DashAttClss();
                        if (!kMyReader.IsDBNull(0)) { attCs.Ccount = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { attCs.Cclss =  kMyReader.GetString(1); }
                        dashAttClssList.Add(attCs);
                    }
                }
                kMyReader.Close();
                dashMod.DashAttClss = dashAttClssList;
                return dashMod;
            }
        }

        // GET: api/DashMods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDashMod([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dashMod = await _context.DashMod.FindAsync(id);

            if (dashMod == null)
            {
                return NotFound();
            }
            return Ok(dashMod);
        }

        // PUT: api/DashMods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashMod([FromRoute] int id, [FromBody] DashMod dashMod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dashMod.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(dashMod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashModExists(id))
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

        // POST: api/DashMods
        [HttpPost]
        public async Task<IActionResult> PostDashMod([FromBody] DashMod dashMod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DashMod.Add(dashMod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashMod", new { id = dashMod.AutoId }, dashMod);
        }

        // DELETE: api/DashMods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashMod([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dashMod = await _context.DashMod.FindAsync(id);
            if (dashMod == null)
            {
                return NotFound();
            }

            _context.DashMod.Remove(dashMod);
            await _context.SaveChangesAsync();

            return Ok(dashMod);
        }

        private bool DashModExists(int id)
        {
            return _context.DashMod.Any(e => e.AutoId == id);
        }
    }
}