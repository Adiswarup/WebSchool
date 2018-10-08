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
    [Route("api/ActivityGroups")]
    public class ActivityGroupsController : Controller
    {
        private readonly SchContext _context;
        private String MySql;

        public ActivityGroupsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/ActivityGroups
        [HttpGet]
        public IEnumerable<ActivityGroup> Get(int mdBID)
        {
            List<ActivityGroup> actGroupList = new List<ActivityGroup>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT ActGroupID, ActGroupName, IsReflectedInReportCArd, ActGroupReportCard, ActGroupMotive, ActCode, GradeType,"
                            + " Clss, ActSn, ActClss FROM ActivityGroup WITH (NOLOCK)"
                            + " WHERE  Dormant = 0"
                            + " AND dBID = " + mdBID;
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        ActivityGroup actGrp = new ActivityGroup();
                        if (!kMyReader.IsDBNull(0)) { actGrp.ActGroupId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { actGrp.ActGroupName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { actGrp.IsReflectedInReportCard =CIB( kMyReader.GetInt32(2)); }
                        if (!kMyReader.IsDBNull(3)) { actGrp.ActGroupReportCard = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { actGrp.ActGroupMotive = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { actGrp.ActCode = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { actGrp.GradeType = kMyReader.GetString(6); }
                        if (!kMyReader.IsDBNull(7)) { actGrp.Clss = kMyReader.GetString(7); }
                        if (!kMyReader.IsDBNull(8)) { actGrp.ActSn = kMyReader.GetInt32(8); }
                        if (!kMyReader.IsDBNull(9)) { actGrp.ActClss = kMyReader.GetString(9); }
                        actGroupList.Add(actGrp);
                    }
                }
            }
            //return Json(new { result = acaSessList.Skip(skip).Take(take), count = acaSessList.Count() });
            return actGroupList;
        }

        // GET: api/ActivityGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityGroup = await _context.ActivityGroup.SingleOrDefaultAsync(m => m.AutoId == id);

            if (activityGroup == null)
            {
                return NotFound();
            }

            return Ok(activityGroup);
        }

        // PUT: api/ActivityGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityGroup([FromRoute] int id, [FromBody] ActivityGroup activityGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != activityGroup.AutoId)
            //{
            //    return BadRequest();
            //}

            _context.Entry(activityGroup).State = EntityState.Modified;

            var actGroupId =id;
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
                    MySql = " UPDATE ActivityGroup SET ";
                    MySql = MySql + " ActGroupName = '" + activityGroup.ActGroupName + "',";
                    MySql = MySql + " IsReflectedInReportCArd = " + CBI(activityGroup.IsReflectedInReportCard) + ",";
                    MySql = MySql + " ActGroupReportCard = '" + activityGroup.ActGroupReportCard + "',";
                    MySql = MySql + " ActGroupMotive = '" + activityGroup.ActGroupMotive+ "',";
                    MySql = MySql + " ActCode = '" + activityGroup.ActCode + "',";
                    MySql = MySql + " GradeType = '" + activityGroup.GradeType + "',";
                    MySql = MySql + " Clss = '" + activityGroup.ActClss + "',";
                    MySql = MySql + " ActSn = " + activityGroup.ActSn + ",";
                    MySql = MySql + " ActClss = '" + activityGroup.ActClss + "'";
                    MySql = MySql + " WHERE ActGroupId = " + activityGroup.ActGroupId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + activityGroup.DBid;
                    //MySql = MySql + " AND AcaSession = '" + activityGroup.ActSession + "'";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityGroupExists(id))
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

        // POST: api/ActivityGroups
        [HttpPost]
        public async Task<IActionResult> PostActivityGroup([FromBody] ActivityGroup activityGroup)
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
                    MySql = " INSERT INTO ActivityGroup (ActGroupID, ActGroupName, IsReflectedInReportCArd, ActGroupReportCard,"
                        + "ActGroupMotive, ActCode, GradeType, Clss, ActSn, ActClss, ActSession, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + activityGroup.ActGroupName + "'," + CBI(activityGroup.IsReflectedInReportCard) + ",'"
                        + activityGroup.ActGroupReportCard + "','" + activityGroup.ActGroupMotive + "','"
                        + activityGroup.ActCode + "','" + activityGroup.GradeType + "','" + activityGroup.Clss + "',"
                        + activityGroup.ActSn + ",'" + activityGroup.ActClss + "','"
                        + activityGroup.ActSession + "',";
                    MySql = MySql + "0,'" + activityGroup.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + activityGroup.CTerminal + "'," + activityGroup.DBid + ")";

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

            //_context.ActivityGroup.Add(activityGroup);
            //await _context.SaveChangesAsync();
            return CreatedAtAction("GetActivityGroup", new { id = activityGroup.AutoId }, activityGroup);
        }

        // DELETE: api/ActivityGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityGroup = await _context.ActivityGroup.SingleOrDefaultAsync(m => m.AutoId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }

            _context.ActivityGroup.Remove(activityGroup);
            await _context.SaveChangesAsync();

            return Ok(activityGroup);
        }

        private bool ActivityGroupExists(int id)
        {
            return _context.ActivityGroup.Any(e => e.AutoId == id);
        }
    }
}