using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Marx;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.BasicListFunc;
using static SchDataApi.GenFunc.GloFunc;
using System.Data;
using System.Data.Common;
using SchDataApi.GenFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Marks")]
    public class MarksController : Controller
    {
        private readonly SchContext _context;
        int ExamSubID;
        double  FullMarks;
        double PassMarks;

        public MarksController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Marks
        [HttpGet]
        public IEnumerable<Marks> GetMarks(string clss, string ExamName, string SubName, string dSess, int mdBId)
        {
            List<Marks> stdMarksList = new List<Marks>();
            string MySql = "";
            int SubID = GetSubID(_context, SubName, clss, dSess, mdBId);
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT ExamSubID, FullMarks, PassMarks";
                MySql = MySql + " From ExamSub WITH (NOLOCK) ";
                MySql = MySql + " WHERE ExamName = '" + repSplChr(ExamName) + "'";
                MySql = MySql + " AND Clss = '" + repSplChr(clss) + "'";
                MySql = MySql + " AND SubID = " + SubID;
                MySql = MySql + " AND Ssession = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND DBID =  " + mdBId;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { ExamSubID = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { FullMarks = kMyReader.GetDouble(1); }
                    if (!kMyReader.IsDBNull(2)) { PassMarks = kMyReader.GetDouble(2); }
                }
                kMyReader.Close();

                MySql = "SELECT IsElective, SubType, AutoGrades, GradeOrMarks";
                MySql = MySql + " FROM Subjects WITH (NOLOCK)  ";
                MySql = MySql + " WHERE Clss = '" + repSplChr(clss) + "'";
                MySql = MySql + " AND SubID = " + SubID;
                MySql = MySql + " AND AcaSession = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND DBID =  " + mdBId;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    // Execute Later
                }
                kMyReader.Close();


                MySql = "SELECT  RegNumber,PresentRollNo, FirstName, MiddleName, LastName, StdStatus, Unireg ";
                MySql = MySql + " FROM Students WITH (NOLOCK) ";
                MySql = MySql + " WHERE PresentClass='" + repSplChr(clss) + "'";
                MySql = MySql + " AND StdSession='" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Dormant =0 ";
                MySql = MySql + " AND StdStatus <=1";
                MySql = MySql + " AND DBID =  " + mdBId;
                MySql = MySql + " ORDER BY PresentRollNo, FirstName";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Marks mks = new Marks();
                        if (!kMyReader.IsDBNull(0)) { mks.RegNum = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { mks.presentRollNum = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) {
                            mks.StdName = kMyReader.GetString(2); // + " " + kMyReader.GetString(3) + " " + kMyReader.GetString(4);
                        }
                        if (!kMyReader.IsDBNull(6)) {
                            mks.UniReg = kMyReader.GetInt32(6);
                            mks.MkID = mks.UniReg;
                        }
                    stdMarksList.Add(mks);
                    }
                }
                kMyReader.Close();

                for (int jM = 0; jM < stdMarksList.Count; jM++)
                {
                    stdMarksList[jM].MClss = clss;
                    stdMarksList[jM].SubName = SubName;
                    stdMarksList[jM].ExamName = ExamName;
                    stdMarksList[jM].MSession = dSess;
                    stdMarksList[jM].dBID = mdBId;

                    MySql = " SELECT MkID, ThMarks, PracMarks, OrMarks, AsgnMarks, TotalMarksCalc, Grades, StdGrades,TotalMarks ";
                    MySql = MySql + " FROM Marks  WITH (nolock) ";
                    MySql = MySql + " WHERE SubName ='" + repSplChr(SubName) + "'";
                    MySql = MySql + " AND ExamName ='" + repSplChr(ExamName) + "'";
                    MySql = MySql + " AND MClss = '" + repSplChr(clss) + "'";
                    MySql = MySql + " AND MSession ='" + repSplChr(dSess) + "'";
                    MySql = MySql + " AND UniReg =" + stdMarksList[jM].UniReg;
                    MySql = MySql + " AND Dormant = 0";
                    //MySql = MySql & " AND ThMarks <> -1"
                    MySql = MySql + " AND DBID =  " + mdBId;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = MySql;
                    kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            //if (!kMyReader.IsDBNull(0)) { stdMarksList[jM].MkID = kMyReader.GetInt32(0); }
                            if (!kMyReader.IsDBNull(1)) { stdMarksList[jM].ThMarks =Convert.ToString( kMyReader.GetDouble(1)); }
                            if (!kMyReader.IsDBNull(2)) { stdMarksList[jM].PracMarks =Convert.ToString(  kMyReader.GetDouble(2)); }
                            if (!kMyReader.IsDBNull(3)) { stdMarksList[jM].OrMarks = Convert.ToString( kMyReader.GetDouble(3)); }
                            if (!kMyReader.IsDBNull(4)) { stdMarksList[jM].AsgnMarks =Convert.ToString(  kMyReader.GetDouble(4)); }
                            if (!kMyReader.IsDBNull(6)) { stdMarksList[jM].Grades = kMyReader.GetString(6); }
                            if (!kMyReader.IsDBNull(7)) { stdMarksList[jM].StdGrades = kMyReader.GetString(7); }
                        }
                    }
                    kMyReader.Close();
                }
             return stdMarksList;
            }
        }
        
        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marks = await _context.Marks.SingleOrDefaultAsync(m => m.MkAutoID == id);

            if (marks == null)
            {
                return NotFound();
            }

            return Ok(marks);
        }

        // PUT: api/Marks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarks([FromRoute] int id, [FromBody] Marks marks)
        {
            string MySql = "";
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
                    MySql = " UPDATE Marks SET ";
                    MySql = MySql + " Dormant = 1 ";
                    MySql = MySql + " WHERE SubName ='" + repSplChr(marks.SubName) + "'";
                    MySql = MySql + " AND ExamName ='" + repSplChr(marks.ExamName) + "'";
                    MySql = MySql + " AND MClss = '" + repSplChr(marks.MClss) + "'";
                    MySql = MySql + " AND MSession ='" + repSplChr(marks.MSession) + "'";
                    MySql = MySql + " AND DBID =  " + marks.dBID;
                    MySql = MySql + " AND UniReg =" + marks.UniReg;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();

                    MySql = "INSERT INTO Marks (";
                    MySql = MySql + " MkID, MClss, SubName, ExamName, TotalMarks, ThMarks, PracMarks, OrMarks, AsgnMarks,";
                    MySql = MySql + " RegNum, MSession, TotalMarksCalc, Grades, StdGrades, LoginName, ModTime, Dormant, cTerminal, dBID, UniReg) VALUES ( ";
                    MySql = MySql + marks.MkID + " ,'";
                    MySql = MySql + repSplChr(marks.MClss) + "','";
                    MySql = MySql + repSplChr(marks.SubName) + "','";
                    MySql = MySql + repSplChr(marks.ExamName) + "',";
                          switch (marks.TotalMarks){
                            case null:
                                MySql = MySql + " -1 ,";
                                break;
                            case "":
                                MySql = MySql + " -1 ,";
                                break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                            default: MySql = MySql + Convert.ToDouble(marks.TotalMarks) + ",";
                                break;
                        }

                    switch (marks.ThMarks)
                    {
                        case null:
                            MySql = MySql + " -1 ,";
                            break;
                        case "":
                            MySql = MySql + " -1 ,";
                            break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                        default:
                            MySql = MySql + Convert.ToDouble(marks.ThMarks) + ",";
                            break;
                    }
                    switch (marks.PracMarks)
                    {
                        case null:
                            MySql = MySql + " -1 ,";
                            break;
                        case "":
                            MySql = MySql + " -1 ,";
                            break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                        default:
                            MySql = MySql + Convert.ToDouble(marks.PracMarks) + ",";
                            break;
                    }

                    switch (marks.OrMarks)
                    {
                        case null:
                            MySql = MySql + " -1 ,";
                            break;
                        case "":
                            MySql = MySql + " -1 ,";
                            break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                        default:
                            MySql = MySql + Convert.ToDouble(marks.OrMarks) + ",";
                            break;
                    }


                    switch (marks.AsgnMarks)
                    {
                        case null:
                            MySql = MySql + " -1 ,";
                            break;
                        case "":
                            MySql = MySql + " -1 ,";
                            break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                        default:
                            MySql = MySql + Convert.ToDouble(marks.AsgnMarks) + ",";
                            break;
                    }
                    MySql = MySql + marks.RegNum + ",'";
                    MySql = MySql + repSplChr(marks.MSession) + "',";
                    switch (marks.TotalMarksCalc)
                    {
                        case null:
                            MySql = MySql + " -1 ,";
                            break;
                        case "":
                            MySql = MySql + " -1 ,";
                            break;
                        case "ab": case "Ab": case "AB": case "aB":
                            MySql = MySql + " -2 ,";
                            break;
                        case "na": case "Na":  case "NA":  case "nA":
                            MySql = MySql + " -5 ,";
                            break;
                        default:
                            MySql = MySql + Convert.ToDouble(marks.TotalMarksCalc) + ",";
                            break;
                    }

                    MySql = MySql + "'" + marks.Grades + "','";
                    MySql = MySql + repSplChr(marks.StdGrades) + "','";
                    MySql = MySql + repSplChr(strLoginName) + "'," + GloFunc.ToOADate(DateTime.Now) + ",0,'" + repSplChr(strComputerName) + "'," + marks.dBID + "," + marks.UniReg + ")";


                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarksExists(id))
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

        // POST: api/Marks
        [HttpPost]
        public async Task<IActionResult> PostMarks([FromBody] Marks marks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Marks.Add(marks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarks", new { id = marks.MkAutoID }, marks);
        }

        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marks = await _context.Marks.SingleOrDefaultAsync(m => m.MkAutoID == id);
            if (marks == null)
            {
                return NotFound();
            }

            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();

            return Ok(marks);
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.MkAutoID == id);
        }
    }
}