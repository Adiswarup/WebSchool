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
using SchDataApi.GenFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Activities")]
    public class ActivitiesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public ActivitiesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public IEnumerable<Activity> Get(int mdBID, string actGrp)
        {
            List<Activity> actList = new List<Activity>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT  ActivityID, ActivityName, ActivityValue, ActivityGroup, ActGroupID, ActivityRemarks,"
                            + "   SendSMS, SendEMail FROM Activity WITH (NOLOCK)"
                            + " WHERE  Dormant = 0"
                            + " AND dBID = " + mdBID
                            + " AND ActivityGroup = '" + actGrp + "'";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Activity activ = new Activity();
                        if (!kMyReader.IsDBNull(0)) { activ.ActivityId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { activ.ActivityName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { activ.ActivityValue = kMyReader.GetDouble(2); }
                        if (!kMyReader.IsDBNull(3)) { activ.ActivityGroup = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { activ.ActGroupId = kMyReader.GetInt32(4); }
                        if (!kMyReader.IsDBNull(5)) { activ.ActivityRemarks = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { activ.SendSms = CIB( kMyReader.GetInt32(6)); }
                        if (!kMyReader.IsDBNull(7)) { activ.SendEmail = CIB(kMyReader.GetInt32(7)); }
                        actList.Add(activ);
                    }
                }
            }
            return actList;
        }

        // GET: api/Activities/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetActivity([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var activity = await _context.Activity.SingleOrDefaultAsync(m => m.AutoId == id);

        //    if (activity == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(activity);
        //}

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity([FromRoute] int id, [FromBody] Activity activity)
        {

            var actID = activity.ActivityId;
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
                    MySql = " UPDATE Activity SET ";
                    MySql = MySql + " ActivityName = '" + activity.ActivityName + "',";
                    MySql = MySql + " ActivityValue = '" + activity.ActivityValue + "',";
                    MySql = MySql + " ActivityGroup = '" + activity.ActivityGroup + "',";
                    MySql = MySql + " ActGroupID = '" + activity.ActGroupId + "'";
                    MySql = MySql + " ActivityRemarks = '" + activity.ActivityRemarks + "'";
                    MySql = MySql + " SendSMS = '" + activity.SendSms + "'";
                    MySql = MySql + " SendEMail = '" + activity.SendEmail + "'";
                    MySql = MySql + " WHERE ActivityID = " + activity.ActivityId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + activity.DBid;
                    //MySql = MySql + " AND AcaSession = '" + activity.ActSession + "'";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(actID))
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

        // POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> PostActivity([FromBody] Activity activity)
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
                    MySql = " INSERT INTO Activity ( ActivityID, ActivityName, ActivityValue, ActivityGroup, " +
                    "ActGroupID, ActivityRemarks,  SendSMS, SendEMail ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + activity.ActivityName + "'," + activity.ActivityValue + ",'"
                        + activity.ActivityGroup + "'," + activity.ActGroupId + ",'"
                        +activity.ActivityRemarks + "'," + CBI(activity.SendSms) + "," + CBI(activity.SendEmail) ;

                    MySql = MySql + ", 0,'" +activity.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + activity.CTerminal + "'," + activity.DBid + ")";

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
            return CreatedAtAction("GetActivity", new { id = activity.ActivityId }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.AutoId == id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            return Ok(activity);
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.AutoId == id);
        }
    }
}