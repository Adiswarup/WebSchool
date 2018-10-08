using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;

namespace SchDataApi.GenFunc
{
    public static class GloFunc
    {
        public static List<SelectListItem> SchExmLst = new List<SelectListItem>();
        public static List<SelectListItem> SchSubLst = new List<SelectListItem>();

        #region Subjects

        public static int GetSubID(SchContext _context, string tSubjects, string tClass, string dSess, int mdBId)
        {
            string MySql2 = "";
            object tmpObj;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql2 = " SELECT SubID FROM Subjects WITH (NOLOCK)";
                MySql2 = MySql2 + " WHERE SubName = '" + repSplChr(tSubjects) + "'";
                MySql2 = MySql2 + " AND Clss = '" + repSplChr(tClass) + "'";
                MySql2 = MySql2 + " AND AcaSession = '" + dSess + "'";
                MySql2 = MySql2 + " AND Dormant = 0";
                MySql2 = MySql2 + " AND dBID = " + mdBId;

                command.CommandText = MySql2;
                command.CommandType = CommandType.Text;
                tmpObj = command.ExecuteScalar();
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
        }

        public static int GetSubName(SchContext _context, string tSubID, string tClass, string dSess, int mdBId)
        {
            string MySql2 = "";
            object tmpObj;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                MySql2 = " SELECT SubName FROM Subjects WITH (NOLOCK)";
                MySql2 = MySql2 + " WHERE SubID = " + tSubID;
                MySql2 = MySql2 + " AND Clss = '" + repSplChr(tClass) + "'";
                MySql2 = MySql2 + " AND AcaSession = '" + dSess + "'";
                MySql2 = MySql2 + " AND Dormant = 0";
                MySql2 = MySql2 + " AND dBID = " + mdBId;

                command.CommandText = MySql2;
                command.CommandType = CommandType.Text;
                tmpObj = command.ExecuteScalar();
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
        }
        #endregion

        #region Grades n Marks
        public static async Task<SelectList> GetSchExm(SchContext _context, string dSess, int mdBId, string tCls = "")
        {
            string kMySql = "";
            dExm = "";
            SchExmLst.Clear();
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT DISTINCT ExamName ";
                kMySql = kMySql + " FROM  ExamSub";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                if (!string.IsNullOrWhiteSpace(dSess))
                {
                    kMySql = kMySql + " AND Ssession = '" + dSess + "'";
                }
                if (!string.IsNullOrWhiteSpace(tCls))
                {
                    kMySql = kMySql + " AND  Clss = '" + tCls + "'";
                }
                command.CommandText = kMySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            if (dExm == "") { dExm = kMyReader.GetString(0); }
                            SchExmLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                        }
                    }
                }
                conn.Close();
            }
            return new SelectList(SchExmLst, "Value", "Text", null);
        }

        public static async Task<SelectList> GetSchSub(SchContext _context, string dSess, int mdBId, string tCls = "", string tExm = "")
        {
            string kMySql = "";
            dSub = 0;
            SchSubLst.Clear();
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT DISTINCT SubName ";
                kMySql = kMySql + " FROM  ExamSub";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                if (!string.IsNullOrWhiteSpace(dSess))
                {
                    kMySql = kMySql + " AND Ssession = '" + dSess + "'";
                }
                if (!string.IsNullOrWhiteSpace(tCls))
                {
                    kMySql = kMySql + " AND  Clss = '" + tCls + "'";
                }
                if (!string.IsNullOrWhiteSpace(tExm))
                {
                    kMySql = kMySql + " AND  ExamName = '" + tExm + "'";
                }
                command.CommandText = kMySql;
                command.CommandType = CommandType.Text;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            //if (dSub == 0) { dSub = kMyReader.GetInt32(0); }
                            SchSubLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                        }
                    }
                }
                conn.Close();
            }
            return new SelectList(SchSubLst, "Value", "Text", null);
        }

        public static string GetGradeType(SchContext _context, string gClss, string gSubName, string dSess, int mdBId)
        {
            string MySql;
            string gradesType = "";
            MySql = "SELECT GradeType,GradeOrMarks";
            MySql = MySql + " FROM Subjects WITH (NOLOCK) ";
            MySql = MySql + " WHERE Dormant=0";
            MySql = MySql + " AND Clss='" + repSplChr(gClss) + "'";
            MySql = MySql + " AND SubName='" + repSplChr(gSubName) + "'";
            MySql = MySql + " AND AcaSession='" + dSess + "'";
            MySql = MySql + " AND Dormant =0";
            MySql = MySql + " AND DBID =  " + mdBId;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                command.CommandText = MySql;
                command.CommandType = CommandType.Text;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0))
                    {
                        if (kMyReader.GetInt32(1) == 1)
                        {
                            gradesType = kMyReader.GetString(0);
                        }
                    }
                }
                conn.Close();

            }

            return gradesType;
        }

        public static int GetExamFullMarks(SchContext _context, string gClss, string gSubName, string tExamName, string dSess, int mdBId)
        {
            string MySql = "";
            object tmpObj;

            MySql = " SELECT FullMarks ";
            MySql = MySql + " From ExamSub WITH (NOLOCK)  ";
            MySql = MySql + " WHERE SubName ='" + repSplChr(gSubName) + "'";
            MySql = MySql + " AND ExamName ='" + repSplChr(tExamName) + "'";
            MySql = MySql + " AND Clss = '" + repSplChr(gClss) + "'";
            MySql = MySql + " AND SSession ='" + repSplChr(dSess) + "'";
            MySql = MySql + " AND Dormant = 0";
            MySql = MySql + " AND DBID =  " + mdBId;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                command.CommandText = MySql;
                command.CommandType = CommandType.Text;
                tmpObj = command.ExecuteScalar();
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
            }
        }

        public static Boolean HasSubSubjects(SchContext _context, string gClss, string gSubName, string tExamName, string dSess, int mdBId)
        {
            string MySql = "";

            MySql = " SELECT SubSubName, ExamName FROM SubjectsRel WITH (NOLOCK)  ";
            MySql = MySql + " WHERE SubName = '" + repSplChr(gSubName) + "'";
            MySql = MySql + " AND Clss = '" + repSplChr(gClss) + "'";
            MySql = MySql + " AND AcaSession = '" + repSplChr(dSess) + "'";
            MySql = MySql + " AND Dormant = 0";
            MySql = MySql + " AND DBID =  " + mdBId;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                command.CommandText = MySql;
                command.CommandType = CommandType.Text;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    return true;
                    //    kMyReader.Read();
                    //if (!kMyReader.IsDBNull(0))
                    //{
                    //    if (kMyReader.GetInt32(1) == 1)
                    //    {
                    //        gradesType = kMyReader.GetString(0);
                    //    }
                    //}
                }
                {
                    return false;
                }
            }
        }

        #endregion

        #region General
        public static string properName(string strName)
        {
        //    strName = strName.replace(strName, ".", ". ")

        //do
        //    {
        //        If InStr(1, strName, "  ") = 0 Then Exit Do
        //        strName = Replace(strName, "  ", " ")

        //    } while (true);


        //    Loop
        //    strName = Trim(strName);
        //    strName = StrConv(strName, vbProperCase);
            return strName;

        }

        public static string repSplChr(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return "";
            }
            else
            {
                return strInput.Replace("'", "''");
            }
        }

        public static string repSplChrXml(string strHindi  )
        {
            try
            {
                strHindi = strHindi.Replace("&", "&amp;");
                strHindi = strHindi.Replace("'", "&apos;");
                strHindi = strHindi.Replace("\"", "&quot;");
                strHindi = strHindi.Replace("<", "&lt;");
                strHindi = strHindi.Replace(">", "&gt;");
                return strHindi;
            }
            catch (Exception)
            {
                return strHindi;
                throw;
            }
}

        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        public static DateTime  FromOADate(this double dNum)
        {
            dNum = Math.Floor(dNum);
            return new DateTime(1900, 1, 1).AddDays(dNum - 2);
        }

        public static Double ToOADate(this DateTime dDate)
        {
            DateTime ODate = new DateTime(1900, 1, 1);
            return (dDate - ODate).Days + 2;
        }

        #endregion

        public static int CBI(bool bVal)
        {
            int retInt = 0;
            if (bVal)
            {
                retInt = 0;
            }
            else
            {
                retInt = 1;
            }
            return retInt;
        }

        public static bool CIB(int bVal)
        {
            bool retBool = true;
            if (bVal == 0)
            {
                retBool = true;
            }
            else
            {
                retBool = false;
            }
            return retBool;
        }

        //public static DateTime FromOADate(this double dNum)
        //{
        //    dNum = Math.Floor(dNum);
        //    return new DateTime(1900, 1, 1).AddDays(dNum - 2);
        //    //return new DateTime(DoubleDateToTicks(date), DateTimeKind.Unspecified);
        //}

        //public static Double ToOADate(this DateTime dDate)
        //{
        //    DateTime ODate = new DateTime(1900, 1, 1);
        //    return (dDate - ODate).Days + 2;
        //    //return new DateTime(1900, 1, 1).AddDays(dNum - 2);
        //    //return new DateTime(DoubleDateToTicks(date), DateTimeKind.Unspecified);
        //}
        //internal static long DoubleDateToTicks(double value)
        //{
        //    if (value >= 2958466.0 || value <= -657435.0)
        //        throw new ArgumentException("Not a valid value");
        //    long num1 = (long)(value * 86400000.0 + (value >= 0.0 ? 0.5 : -0.5));
        //    if (num1 < 0L)
        //        num1 -= num1 % 86400000L * 2L;
        //    long num2 = num1 + 59926435200000L;
        //    if (num2 < 0L || num2 >= 315537897600000L)
        //        throw new ArgumentException("Not a valid value");
        //    return num2 * 10000L;
        //}
    }
}
