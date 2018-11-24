using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Basics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Subjects")]
    public class SubjectsController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public SubjectsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public IEnumerable<Subjects> GetSubjects(string clss, string dSess, int mdBId)//[FromRoute] 
        {
            List<Subjects> stdSubsList = new List<Subjects>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT SubID, SubName, SubCode, Pref_Teacher, ";
                MySql = MySql + " SubjectExamName,SubType, FeatureInReport, AutoGrades, GradeType, GradeOrMarks, ";
                MySql = MySql + " IsElective, IsTheory, IsPract, IsAssign, SubSn";
                MySql = MySql + " FROM Subjects WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND Clss = '" + clss + "'";
                MySql = MySql + " AND AcaSession = '" + dSess + "'";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Subjects subjs = new Subjects();
                        if (!kMyReader.IsDBNull(0)) { subjs.SubId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { subjs.SubName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { subjs.SubCode = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { subjs.ClassTeacher = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { subjs.SubjectExamName = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { subjs.SubType = kMyReader.GetInt32(5); }
                        if (!kMyReader.IsDBNull(6)) { subjs.FeatureInReport = CIB(kMyReader.GetInt32(6)); }
                        if (!kMyReader.IsDBNull(7)) { subjs.AutoGrades = CIB(kMyReader.GetInt32(7)); }
                         if (!kMyReader.IsDBNull(8)) { subjs.GradeType =  kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { subjs.GradeOrMarks = CIB(kMyReader.GetInt32(9)); }
                        if (!kMyReader.IsDBNull(10)) { subjs.IsElective = CIB(kMyReader.GetInt32(10)); }
                        if (!kMyReader.IsDBNull(11)) { subjs.IsTheory = CIB(kMyReader.GetInt32(11)); }
                        if (!kMyReader.IsDBNull(12)) { subjs.IsPract = CIB(kMyReader.GetInt32(12)); }
                        if (!kMyReader.IsDBNull(13)) { subjs.IsAssign = CIB(kMyReader.GetInt32(13)); }
                        if (!kMyReader.IsDBNull(14)) { subjs.SubSn = kMyReader.GetInt32(14); }
                        stdSubsList.Add(subjs);
                    }
                }
                kMyReader.Close();
            }
            return stdSubsList;
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subjects = await _context.Subjects.SingleOrDefaultAsync(m => m.SubAutoId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return Ok(subjects);
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjects([FromRoute] int id, [FromBody] Subjects subjects)
        {
            var ssid = subjects.SubId;
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
                    MySql = " UPDATE Subjects SET ";
                    MySql = MySql + " SubName = '" + subjects.SubName + "',";
                    MySql = MySql + " SubCode = '" + subjects.SubCode + "',";
                    MySql = MySql + " SubjectExamName = '" + subjects.SubjectExamName + "',";
                    MySql = MySql + " SubType = " + subjects.SubType + ",";
                    MySql = MySql + " FeatureInReport = " + CBI(subjects.FeatureInReport) + ",";
                    MySql = MySql + " AutoGrades = " + CBI(subjects.AutoGrades) + ",";
                    MySql = MySql + " GradeOrMarks = " + CBI(subjects.GradeOrMarks) + ",";
                    MySql = MySql + " IsElective = " + CBI(subjects.IsElective) + ",";
                    MySql = MySql + " IsTheory = " + CBI(subjects.IsTheory) + ",";
                    MySql = MySql + " IsPract = " + CBI(subjects.IsPract) + ",";
                    MySql = MySql + " IsAssign = " + CBI(subjects.IsAssign) + ",";
                    MySql = MySql + " GradeType = '" + subjects.GradeType + "',";
                    MySql = MySql + " Pref_Teacher = '" + subjects.ClassTeacher + "'";
                    MySql = MySql + " WHERE SubID = " + subjects.SubId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + subjects.DBid;
                    MySql = MySql + " AND AcaSession = '" + subjects.AcaSession + "'";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(ssid))
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

        // POST: api/Subjects
        [HttpPost]
        public async Task<IActionResult> PostSubjects([FromBody] Subjects subjects)
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
                    MySql = " INSERT INTO Subjects (SubID, SubName, SubCode, Clss, Pref_Teacher, ";
                    MySql = MySql + " AcaSession, SubjectExamName, SubType, FeatureInReport, AutoGrades, GradeType, GradeOrMarks, IsElective, ";
                    MySql = MySql + " IsTheory, IsPract, IsAssign, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + subjects.SubName + "','" + subjects.SubCode + "','" + subjects.Clss + "','" + subjects.ClassTeacher;
                    MySql = MySql + "','" + subjects.AcaSession + "','" + subjects.SubjectExamName + "'," + subjects.SubType + "," + CBI(subjects.FeatureInReport);
                    MySql = MySql + "," + CBI(subjects.AutoGrades) + ",'" + subjects.GradeType + "'," + CBI(subjects.GradeOrMarks) + "," + CBI(subjects.IsElective);
                    MySql = MySql + "," + CBI(subjects.IsTheory) + "," + CBI(subjects.IsPract) + "," + CBI(subjects.IsAssign);
                    MySql = MySql + ", 0,'" + strLoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + Terminal + "'," + subjects.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return CreatedAtAction("GetSubjects", new { id = subjects.SubId }, subjects);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjects = await _context.Subjects.SingleOrDefaultAsync(m => m.SubAutoId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();

            return Ok(subjects);
        }

        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.SubAutoId == id);
        }

    }
}