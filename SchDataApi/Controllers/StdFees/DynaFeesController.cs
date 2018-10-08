using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.GloFunc;
using System.Data;
using System.Data.Common;
using SchDataApi.GenFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/DynaFees")]
    public class DynaFeesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public DynaFeesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/DynaFees
        [HttpGet]
        public IEnumerable<DynaFee> GetDynaFee(string clss, string tSess, string stdFeeCat,  string FeeCap, string dSess, int mdBId, int Mode = 0)
        {
            int tAutoid = 0;
            List<DynaFee> dynaFeeList = new List<DynaFee>();
            List<string> FeeCaptionList = new List<string>();
            var conn = _context.Database.GetDbConnection();
            DbDataReader kMyReader;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                if (Mode == 0)
                {
                    MySql = " SELECT DISTINCT FeeCaption ";
                    MySql = MySql + " FROM FCaption WITH (NOLOCK)";
                    MySql = MySql + " WHERE  Dormant = 0";
                    MySql = MySql + " AND  ShowIt = 0";
                    MySql = MySql + " AND dBID = " + mdBId;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0)) { FeeCaptionList.Add(kMyReader.GetString(0)); }
                        }
                    }
                    kMyReader.Close();
                }

                MySql = " SELECT ClsFeeId, FeeNo, Caption, ForMonth, Amount, FeeCaption, ";
                MySql = MySql + " PayByDate, ForClass, StdCategory, SessionName, DueOn ";
                MySql = MySql + " FROM DynaFee WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND ForClass = '" + clss + "'";
                MySql = MySql + " AND SessionName = '" + tSess + "'";
                MySql = MySql + " AND StdCategory = '" + stdFeeCat + "'";
                 MySql = MySql + " AND FeeCaption = '" + FeeCap + "'";
               command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        DynaFee dynFee = new DynaFee();
                        dynFee.AutoId = tAutoid + 1;
                        if (!kMyReader.IsDBNull(0)) { dynFee.ClsFeeId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { dynFee.FeeNo = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) {
                            dynFee.Caption = kMyReader.GetString(2);
                            FeeCaptionList.Remove(dynFee.Caption);
                        }
                        if (!kMyReader.IsDBNull(3)) { dynFee.ForMonth = GloFunc.FromOADate( kMyReader.GetInt32(3)); }
                        if (!kMyReader.IsDBNull(4)) { dynFee.Amount = kMyReader.GetDouble(4); }
                        if (!kMyReader.IsDBNull(5)) { dynFee.FeeCaption = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { dynFee.PayByDate = GloFunc.FromOADate( kMyReader.GetDouble(6)); }
                        if (!kMyReader.IsDBNull(7)) { dynFee.ForClass = kMyReader.GetString(7); }
                        if (!kMyReader.IsDBNull(8)) { dynFee.StdCategory =  kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { dynFee.SessionName =  kMyReader.GetString(9); }
                        if (!kMyReader.IsDBNull(10)) { dynFee.DueOn = GloFunc.FromOADate(kMyReader.GetDouble(10)); }
                        dynaFeeList.Add(dynFee);
                        tAutoid = tAutoid + 1;
                    }
                }
                kMyReader.Close();
            }
            foreach (var item in FeeCaptionList)
            {
                DynaFee dynFee = new DynaFee();
                dynFee.AutoId = tAutoid + 1;
                dynFee.Caption = item;
                dynFee.ClsFeeId = 0;
                dynFee.FeeNo = 0;
                dynFee.ForMonth = dynaFeeList[0].ForMonth;
                dynFee.Amount = 0;
                dynFee.ForClass = clss;
                dynFee.StdCategory = stdFeeCat;
                dynFee.SessionName = tSess;
                dynaFeeList.Add(dynFee);
                tAutoid = tAutoid + 1;
            }
            return dynaFeeList;
        }

        // GET: api/DynaFees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDynaFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dynaFee = await _context.DynaFee.SingleOrDefaultAsync(m => m.AutoId == id);

            if (dynaFee == null)
            {
                return NotFound();
            }

            return Ok(dynaFee);
        }

        // PUT: api/DynaFees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDynaFee([FromRoute] int id, [FromBody] DynaFee dynaFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(dynaFee).State = EntityState.Modified;
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    if (dynaFee.ClsFeeId != 0)
                    {
                        MySql = " DELETE FROM DynaFee"
                                    + " WHERE Dormant = 0  "
                                    + " AND ClsFeeId = " + dynaFee.ClsFeeId  
                                    + " AND ForClass = '" + dynaFee.ForClass + "'"
                                    + " AND StdCategory = '" + dynaFee.StdCategory + "'"    
                                    + " AND SessionName = '" + dynaFee.SessionName + "'"
                                    + " AND FeeCaption = '" + dynaFee.FeeCaption + "'"
                                    + " AND Caption = '" + dynaFee.Caption + "'";
                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    }
                    MySql = " INSERT INTO DynaFee ( ClsFeeId, FeeNo, Caption, ForMonth, Amount, FeeCaption, PayByDate, ForClass, " +
                            "StdCategory,   SessionName, DueOn,"
                            + " Dormant, LoginName, ModTime, cTerminal, dBID) Values ("
                            + dynaFee.ClsFeeId + "," + dynaFee.FeeNo + ",'" + dynaFee.Caption + "'," + GloFunc.ToOADate(dynaFee.ForMonth)  + ","
                            + dynaFee.Amount + ",'" + dynaFee.FeeCaption + "'," + GloFunc.ToOADate(dynaFee.PayByDate) + ",'" + dynaFee.ForClass + "','" 
                            + dynaFee.StdCategory + "','" + dynaFee.SessionName + "'," + GloFunc.ToOADate(dynaFee.DueOn) 
                            + ", 0,'" + dynaFee.LoginName + "'," + DateTime.Now.Date.ToOADate()
                            + ",'" + dynaFee.CTerminal + "'," + dynaFee.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        // POST: api/DynaFees
        [HttpPost]
        public async Task<IActionResult> PostDynaFee([FromBody] DynaFee dynaFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DynaFee.Add(dynaFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDynaFee", new { id = dynaFee.AutoId }, dynaFee);
        }

        // DELETE: api/DynaFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDynaFee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dynaFee = await _context.DynaFee.SingleOrDefaultAsync(m => m.AutoId == id);
            if (dynaFee == null)
            {
                return NotFound();
            }

            _context.DynaFee.Remove(dynaFee);
            await _context.SaveChangesAsync();

            return Ok(dynaFee);
        }

        private bool DynaFeeExists(int id)
        {
            return _context.DynaFee.Any(e => e.AutoId == id);
        }
    }
}


//kMyReader.Close();
//MySql = " SELECT DISTINCT FeeCaption ";
//MySql = MySql + " FROM DynaFee WITH (NOLOCK)";
//MySql = MySql + " WHERE  Dormant = 0";
//MySql = MySql + " AND dBID = " + mdBId;
//MySql = MySql + " AND ForClass = '" + clss + "'";
//MySql = MySql + " AND SessionName = '" + tSess + "'";
//MySql = MySql + " AND StdCategory = '" + stdFeeCat + "'";
//command.CommandType = CommandType.Text;
//command.CommandText = MySql;
//kMyReader = command.ExecuteReader();
//if (kMyReader.HasRows)
//{
//while (kMyReader.Read())
//{

//}
//}
//kMyReader.Close();
