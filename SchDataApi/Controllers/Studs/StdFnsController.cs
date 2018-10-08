using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchMod.Models.Studs;
using SchDataApi.DataLayer;
using Microsoft.EntityFrameworkCore;

using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.GloFunc;
using System.Data.Common;
using System.Data;

namespace SchDataApi.Controllers.Studs
{
    [Produces("application/json")]
    [Route("api/StdFns")]
    public class StdFnsController : Controller
    {
        private readonly SchContext _context;

        public StdFnsController(SchContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ActionName("GetStdList")]
        [Route("GetStdList")]
        public async Task<List<Students>> GetStdList([FromBody] string tclss, string dSess, int mdBId)
        {
            string MySql;
            string fName = "";
            string mName = "";
            string lName = "";

            List<Students> schStdLst = new List<Students>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT  RegNumber, PresentRollNo, FirstName, MiddleName, LastName, Sex, DOB, ParentsNamesF, ";
                MySql = MySql + " StdGenCategory, ConPhone, UniReg, EmailAddress ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                if (!string.IsNullOrWhiteSpace(dSess))
                {
                    MySql = MySql + " AND StdSession = '" + dSess + "'";
                }
                if (!string.IsNullOrWhiteSpace(tclss))
                {
                    MySql = MySql + " AND  PresentClass = '" + tclss + "'";
                }
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();

                // , command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Students students = new Students();
                        if (!kMyReader.IsDBNull(0)) { students.RegNumber = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { students.PresentRollNo = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) { fName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { mName = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { lName = kMyReader.GetString(4); }
                        students.StdName =repSplChr( fName + mName + lName);
                        //Sex, DOB, ParentsNamesF,
                        if (!kMyReader.IsDBNull(5)) {
                            if (kMyReader.GetInt32(5) == 1)
                                {
                                students.Sex = "Boy";
                            }
                            else
                            { students.Sex = "Girl"; }
                            students.Sex = kMyReader.GetInt32(5).ToString();
                        }
                        if (!kMyReader.IsDBNull(6)) { students.Dob = GenFunc.GloFunc .FromOADate( kMyReader.GetDouble(6)); }
                        if (!kMyReader.IsDBNull(7)) { students.ParentsNamesF = kMyReader.GetString(7); }
                        //StdGenCategory, ConPhone, UniReg, EmailAddress
                        if (!kMyReader.IsDBNull(8)) { students.StdGenCategory = kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { students.ConPhone = kMyReader.GetString(9); }
                        if (!kMyReader.IsDBNull(10)) { students.UniReg = kMyReader.GetInt32(10); }
                        if (!kMyReader.IsDBNull(11)) { students.EmailAddress = kMyReader.GetString(11); }
                        schStdLst.Add(students);
                    }
                }
                //conn.Close();
            }
            return schStdLst;
        }

    }
}