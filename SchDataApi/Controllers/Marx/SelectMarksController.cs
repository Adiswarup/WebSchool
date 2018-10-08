using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Marx;
using System.Data;
using static SchDataApi.GenFunc.GloFunc;

using static SchDataApi.GenFunc.GloVar;
using System.Data.Common;
using SchDataApi.GenFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/SelectMarks")]
    public class SelectMarksController : Controller
    {
        private readonly SchContext _context;

        public SelectMarksController(SchContext context)
        {
            _context = context;
        }

        // GET: api/SelectMarks
        [HttpGet]
        public IEnumerable<SelectMarks> GetSelectMarks()
        {
            return _context.SelectMarks;
        }

        // GET: api/SelectMarks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelectMarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectMarks = await _context.SelectMarks.SingleOrDefaultAsync(m => m.SelectMarksId == id);

            if (selectMarks == null)
            {
                return NotFound();
            }

            return Ok(selectMarks);
        }

        // PUT: api/SelectMarks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectMarks([FromRoute] int id, [FromBody] SelectMarks selectMarks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selectMarks.SelectMarksId)
            {
                return BadRequest();
            }

            _context.Entry(selectMarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectMarksExists(id))
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

        // POST: api/SelectMarks
        [HttpPost]
        public async Task<IActionResult> PostSelectMarks([FromBody] SelectMarks selectMarks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SelectMarks.Add(selectMarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelectMarks", new { id = selectMarks.SelectMarksId }, selectMarks);
        }

        // DELETE: api/SelectMarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectMarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectMarks = await _context.SelectMarks.SingleOrDefaultAsync(m => m.SelectMarksId == id);
            if (selectMarks == null)
            {
                return NotFound();
            }

            _context.SelectMarks.Remove(selectMarks);
            await _context.SaveChangesAsync();

            return Ok(selectMarks);
        }

        private bool SelectMarksExists(int id)
        {
            return _context.SelectMarks.Any(e => e.SelectMarksId == id);
        }

        [HttpGet]
        [ActionName("GetSubID")]
        [Route("GetSubID")]
        public async Task<int> GetSubID([FromBody] SelectMarks selectMarks)
        {
            if (!ModelState.IsValid)
            {
                return -1;
            }
            string MySql2 = "";
            object tmpObj;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql2 = " SELECT SubID FROM Subjects WITH (NOLOCK)";
                MySql2 = MySql2 + " WHERE SubName = '" + repSplChr(selectMarks.SubName) + "'";
                MySql2 = MySql2 + " AND Clss = '" + repSplChr(selectMarks.MClss) + "'";
                MySql2 = MySql2 + " AND AcaSession = '" + repSplChr(selectMarks.Sessn) + "'";
                MySql2 = MySql2 + " AND Dormant = 0";
                MySql2 = MySql2 + " AND dBID = " + selectMarks.DBid;

                command.CommandType = CommandType.Text;
                tmpObj = command.ExecuteScalarAsync();
                if (!((Object)tmpObj == null))
                {
                    if (GloFunc.IsNumeric(tmpObj.ToString()))
                    {
                        return int.Parse(tmpObj.ToString());
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
                //conn.Close();
            }


            //var subjects = await _context.Subjects.SingleOrDefaultAsync(m => m.SubAutoId == id);

            //if (subjects == null)
            //{
            //    return NotFound();
            //}

            //return Ok(subjects);
        }

        [HttpGet]
        [ActionName("GetGradeType")]
        [Route("GetGradeType")]

        public async Task<string> GetGradeType([FromBody] SelectMarks selectMarks)
        {
            string MySql;
            string cbGradesType = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT GradeType,GradeOrMarks";
                MySql = MySql + " FROM Subjects WITH (NOLOCK) ";
                MySql = MySql + " WHERE Dormant=0";
                MySql = MySql + " AND Clss='" + repSplChr(selectMarks.MClss ) + "'";
                MySql = MySql + " AND SubName='" + repSplChr(selectMarks.SubName ) + "'";
                MySql = MySql + " AND AcaSession='" + repSplChr(selectMarks.Sessn ) + "'";
                MySql = MySql + " AND Dormant =0";
                MySql = MySql + " AND DBID =  " + selectMarks.DBid;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0))
                    {
                        if (kMyReader.GetInt32(1) == 1)
                        {
                            cbGradesType = kMyReader.GetString(0);
                        }
                    }
                }
                conn.Close();
                return cbGradesType;
            }
        }

        [HttpGet]
        [ActionName("GetMarksLst")]
        [Route("GetMarksLst")]
        public async Task<List<Marks>> GetMarksLst([FromBody] SelectMarks selectMarks)
        {
            List<Marks> markList = new List<Marks>();
            string MySql;
            string fName = "";
            string mName = "";
            string lName = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT  RegNumber,PresentRollNo, FirstName, MiddleName, LastName,StdStatus,Unireg ";
                MySql = MySql + " FROM Students WITH (NOLOCK) ";
                MySql = MySql + " WHERE PresentClass='" + repSplChr(selectMarks.MClss) + "'";
                MySql = MySql + " AND StdSession='" + repSplChr(selectMarks.Sessn) + "'";
                MySql = MySql + " AND Dormant =0 ";
                MySql = MySql + " AND StdStatus <=1 ";
                MySql = MySql + " AND DBID = " + selectMarks.DBid;
                MySql = MySql + " ORDER BY PresentRollNo";

                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Marks marks = new Marks();
                        if (!kMyReader.IsDBNull(0)) { marks.RegNum = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { marks.presentRollNum = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) { fName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { mName = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { lName = kMyReader.GetString(4); }
                        marks.StdName = fName + mName + lName;
                        //if (!kMyReader.IsDBNull(5)) { marks.stdStatus = kMyReader.GetInt32(5); }
                        if (!kMyReader.IsDBNull(6)) { marks.UniReg = kMyReader.GetInt32(6); }
                        markList.Add(marks);
                    }
                }
                conn.Close();
                return markList;
            }

        }


    }
}