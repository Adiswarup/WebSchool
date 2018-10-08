using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchDataApi.GenFunc;
using SchMod.Models.Active;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TransActivities")]
    public class TransActivitiesController : Controller
    {
        private readonly SchContext _context;
        string MySql = "";
        string strReg = "";
        TransActivity sActs;
        public TransActivitiesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/TransActivities
        [HttpGet]
        public IEnumerable<TransActivity> GetTransActivity(string clss, string actgrps, double actDate, string dSess, int mDbId)
        {
            List<TransActivity> stdActList = new List<TransActivity>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT  RegNumber,PresentRollNo, FirstName, MiddleName, LastName, StdStatus, Unireg ";
                MySql = MySql + " FROM Students WITH (NOLOCK) ";
                MySql = MySql + " WHERE PresentClass='" + repSplChr(clss) + "'";
                MySql = MySql + " AND StdSession='" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Dormant =0 ";
                MySql = MySql + " AND StdStatus <=1";
                MySql = MySql + " AND DBID =  " + mDbId;
                MySql = MySql + " ORDER BY PresentRollNo, FirstName";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        TransActivity acts = new TransActivity();
                        if (!kMyReader.IsDBNull(0))
                        {
                            acts.RegNumber = kMyReader.GetInt32(0);
                            strReg = strReg + ", " + acts.RegNumber;
                        }
                        if (!kMyReader.IsDBNull(1)) { acts.RollNumber = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2))
                        {
                            acts.StdName = kMyReader.GetString(2); // " " + kMyReader.GetString(3) + " " + kMyReader.GetString(4);
                        }
                        acts.TransActName = "None";
                        if (!kMyReader.IsDBNull(6))
                        {
                            acts.UniReg = kMyReader.GetInt32(6);
                        }
                        stdActList.Add(acts);
                    }
                }
                kMyReader.Close();


                MySql = "SELECT  TransActName, RegNumber, ActivityID, TransActID ";
                MySql = MySql + " FROM TransActivity WITH (NOLOCK) ";
                MySql = MySql + " WHERE RegNumber IN (" + strReg.Trim(',') + ")";
                MySql = MySql + " AND Dormant =0 ";
                MySql = MySql + " AND TransActDate = " + actDate;
                MySql = MySql + " AND DBID =  " + mDbId;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        for (int i = 0; i < stdActList.Count - 1; i++)
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (stdActList[i].RegNumber == kMyReader.GetInt32(1))
                                {
                                    if (stdActList[i].TransActName == "None")
                                    {
                                        stdActList[i].TransActName = kMyReader.GetString(0);
                                        stdActList[i].TransActId = kMyReader.GetInt32(3);
                                        break;
                                    }
                                    else
                                    {
                                        sActs = stdActList[i];
                                        sActs.TransActName = kMyReader.GetString(0);
                                        stdActList[i].TransActId = kMyReader.GetInt32(3);
                                        stdActList.Insert(i, sActs);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                kMyReader.Close();
            }
            return stdActList;
        }

        // GET: api/TransActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transActivity = await _context.TransActivity.SingleOrDefaultAsync(m => m.AutoId == id);

            if (transActivity == null)
            {
                return NotFound();
            }

            return Ok(transActivity);
        }

        // PUT: api/TransActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransActivity([FromRoute] int id, [FromBody] TransActivity transActivity)
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
                    if (transActivity.TransActName == "None")
                    {
                        if (transActivity.TransActId != 0)
                        {
                            MySql = " UPDATE TransActivity SET ";
                            MySql = MySql + " Dormant = 1 ";
                            MySql = MySql + " WHERE TransActID = " + transActivity.TransActId;
                            MySql = MySql + " AND RegNumber = " + transActivity.RegNumber;
                            command.CommandType = CommandType.Text;
                            command.CommandText = MySql;
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MySql = " INSERT INTO TransActivity (TransActID, TransActName, ActivityID, RegNumber, TransActValue, "
                            + "TransActDate, TransActObserver, TeachID, TransActRemarks, UniReg, Score, ";
                        MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                        MySql = MySql + transActivity.TransActName + "',0," + transActivity.RegNumber + ","
                            + transActivity.TransActValue + "," + GloFunc.ToOADate(transActivity.TransActDate) + ",'"
                            + transActivity.TransActObserver + "',0,'" + transActivity.TransActRemarks + "'," + transActivity.UniReg + ",0,";
                        MySql = MySql + "0,'" + transActivity.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                        MySql = MySql + ",'" + transActivity.CTerminal + "'," + transActivity.DBid + ")";

                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransActivityExists(id))
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

        // POST: api/TransActivities
        [HttpPost]
        public async Task<IActionResult> PostTransActivity([FromBody] TransActivity transActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TransActivity.Add(transActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransActivity", new { id = transActivity.AutoId }, transActivity);
        }

        // DELETE: api/TransActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transActivity = await _context.TransActivity.SingleOrDefaultAsync(m => m.AutoId == id);
            if (transActivity == null)
            {
                return NotFound();
            }

            _context.TransActivity.Remove(transActivity);
            await _context.SaveChangesAsync();

            return Ok(transActivity);
        }

        private bool TransActivityExists(int id)
        {
            return _context.TransActivity.Any(e => e.AutoId == id);
        }
    }
}