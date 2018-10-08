using Microsoft.EntityFrameworkCore;
using SchMod.Models;
using SchMod.Models.Studs;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebCat7.Data;
using static WebCat7.GenFunction.GloFunc;

namespace WebCat7.GenFunction
{
    public static class StdFns
    {
        public static async Task<List<Students>> GetStdList(SchContext _context, string tSess = "", string tCls = "", string tSearchstr = "")
        {
            string MySql;
            string fName = "";
            string mName = "";
            string lName = "";

            List<Students> schStdLst = new List<Students>();
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT  RegNumber, PresentRollNo, FirstName, MiddleName, LastName, Sex, DOB, ParentsNamesF, ";
                MySql = MySql + " StdGenCategory, ConPhone, UniReg, EmailAddress ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + GloVar.mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                if (!string.IsNullOrWhiteSpace(tSess))
                {
                    MySql = MySql + " AND StdSession = '" + tSess + "'";
                }
                if (!string.IsNullOrWhiteSpace(tCls))
                {
                    MySql = MySql + " AND  PresentClass = '" + tCls + "'";
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
                        students.StdName  = fName + mName + lName;
                        //Sex, DOB, ParentsNamesF,
                        if (!kMyReader.IsDBNull(5)) { students.Sex = kMyReader.GetInt32(5); }
                        if (!kMyReader.IsDBNull(6)) { students.Dob =GenFunction.GloFunc.FromOADate ( kMyReader.GetDouble(6)); }
                        if (!kMyReader.IsDBNull(7)) { students.ParentsNamesF = kMyReader.GetString(7); }
                        //StdGenCategory, ConPhone, UniReg, EmailAddress
                        if (!kMyReader.IsDBNull(8)) { students.StdGenCategory = kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { students.ConPhone = kMyReader.GetString(9); }
                        if (!kMyReader.IsDBNull(10)) { students.UniReg = kMyReader.GetInt32(10); }
                        if (!kMyReader.IsDBNull(11)) { students.EmailAddress = kMyReader.GetString(11); }
                        schStdLst.Add(students);
                    }
                }
                conn.Close();
            }
            return schStdLst;
        }
    }
}