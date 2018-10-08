using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Convey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Conveyances")]
    public class ConveyancesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public ConveyancesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Conveyances
        [HttpGet]
        public IEnumerable<Conveyance> Get(string clss, float stDate, string dSess, int mdBId)
        {
            string fName = "";
            string mName = "";
            string lName = "";
            string strReg = "";
            List<Conveyance> ConveyanceList = new List<Conveyance>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT  RegNumber, FirstName, MiddleName, LastName, PresentRollNo, Address, Address1, City," +
                         " State, PostalCode FROM Students  WITH (NOLOCK) ";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND PresentClass = '" + clss + "'";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND StdStatus <= 0";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Conveyance convs = new Conveyance();

                        if (!kMyReader.IsDBNull(0))
                        {
                            convs.RegNum = kMyReader.GetInt32(0);
                            strReg = strReg + ", " + convs.RegNum;

                        }
                        if (!kMyReader.IsDBNull(1)) { fName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { mName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { lName = kMyReader.GetString(3); }
                        convs.StdName = fName + " " + mName + " " + lName;
                        if (!kMyReader.IsDBNull(4)) { convs.RollNo = kMyReader.GetInt32(4); }
                        if (!kMyReader.IsDBNull(5)) { convs.Address = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { convs.Address = convs.Address + ": " + kMyReader.GetString(6); }
                        if (!kMyReader.IsDBNull(7)) { convs.Address = convs.Address + ": " + kMyReader.GetString(7); }
                        if (!kMyReader.IsDBNull(8)) { convs.Address = convs.Address + ": " + kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { convs.Address = convs.Address + ": " + kMyReader.GetString(9); }
                        convs.StopId = 0;
                        ConveyanceList.Add(convs);
                    }
                }
                kMyReader.Close();
                if (strReg.Trim(',') != "")
                {
                MySql = " SELECT   ConID, RegNum, StopId, RouteID, DateFrom "
                            + " FROM Conveyance WITH (NOLOCK)";
                MySql = MySql + " WHERE Dormant = 0";
                MySql = MySql + " AND RegNum IN (" + strReg.Trim(',') + ")";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND DateFrom <= " + (int)stDate;
                MySql = MySql + " ORDER BY DateFrom ASC ";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        foreach (Conveyance conv in ConveyanceList)
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (conv.RegNum == kMyReader.GetInt32(1))
                                {
                                    conv.ConId = kMyReader.GetInt32(0);
                                    conv.StopId = kMyReader.GetInt32(2);
                                    conv.DateFrom = DateTime.FromOADate(kMyReader.GetDouble(4));
                                }
                            }

                        }
                    }
                }
                kMyReader.Close();
                foreach (Conveyance conv in ConveyanceList)
                {
                    if (conv.StopId != 0)
                    {
                        MySql = " SELECT   Stops, FareFromMonth, ConveyanceMode, Circuit, MonthlyFare "
                                 + " FROM Stops WITH (NOLOCK)";
                        MySql = MySql + " WHERE Dormant = 0";
                        MySql = MySql + " AND dBID = " + mdBId;
                        MySql = MySql + " AND StopID = " + conv.StopId;
                        MySql = MySql + " AND FareFromMonth <= " + (int)stDate;
                        MySql = MySql + " ORDER BY FareFromMonth ASC ";
                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        kMyReader = command.ExecuteReader();
                        if (kMyReader.HasRows)
                        {
                            while (kMyReader.Read())
                            {
                                conv.Stops = kMyReader.GetString(0);
                                conv.Fare = kMyReader.GetDouble(4);
                            }
                        }
                        kMyReader.Close();
                    }
                }
                }

            }
            return ConveyanceList;
        }

        // GET: api/Conveyances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConveyance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conveyance = await _context.Conveyance.SingleOrDefaultAsync(m => m.AutoId == id);

            if (conveyance == null)
            {
                return NotFound();
            }

            return Ok(conveyance);
        }

        // PUT: api/Conveyances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConveyance([FromRoute] int id, [FromBody] Conveyance conveyance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                conveyance.StopId = SchDataApi.GenFunc.ConVeyFunc.getStopID(_context, conveyance.Stops, conveyance.DBid);
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    if (conveyance.Stops == "None")
                    {
                        if (conveyance.ConId != 0)
                        {
                            MySql = " UPDATE Conveyance SET ";
                            MySql = MySql + " Dormant = 1 ";
                            MySql = MySql + " WHERE ConID = " + conveyance.ConId;
                            MySql = MySql + " AND RegNumber = " + conveyance.RegNum;
                            command.CommandType = CommandType.Text;
                            command.CommandText = MySql;
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MySql = " INSERT INTO Conveyance (ConID, RegNum, StopID, ClssName, RouteID, DateFrom, "
                            + " UniReg, ";
                        MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, ";
                        MySql = MySql + conveyance.RegNum + "," + conveyance.StopId + ",'"
                            + conveyance.Clss + "'," + conveyance.RouteId + ","
                            + SchDataApi.GenFunc.GloFunc.ToOADate(conveyance.DateFrom) + ",0,";
                        MySql = MySql + "0,'" + conveyance.LoginName + "'," + SchDataApi.GenFunc.GloFunc.ToOADate(DateTime.Now);
                        MySql = MySql + ",'" + conveyance.CTerminal + "'," + conveyance.DBid + ")";

                        command.CommandType = CommandType.Text;
                        command.CommandText = MySql;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Conveyances
        [HttpPost]
        public async Task<IActionResult> PostConveyance([FromBody] Conveyance conveyance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Conveyance.Add(conveyance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConveyance", new { id = conveyance.AutoId }, conveyance);
        }

        // DELETE: api/Conveyances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConveyance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conveyance = await _context.Conveyance.SingleOrDefaultAsync(m => m.AutoId == id);
            if (conveyance == null)
            {
                return NotFound();
            }

            _context.Conveyance.Remove(conveyance);
            await _context.SaveChangesAsync();

            return Ok(conveyance);
        }

        private bool ConveyanceExists(int id)
        {
            return _context.Conveyance.Any(e => e.AutoId == id);
        }
    }
}