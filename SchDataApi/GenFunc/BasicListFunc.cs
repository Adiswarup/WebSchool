using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Basics;
using SchMod.Models.Studs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.GloFunc;


namespace SchDataApi.GenFunc
{
    public static class BasicListFunc
    {
        //private readonly SchContext _context;
        public static List<SelectListItem> SchClsLst = new List<SelectListItem>();
        public static List<SelectListItem> SchFeeCatLst = new List<SelectListItem>();
        public static List<SelectListItem> SchFeeNameLst = new List<SelectListItem>();
        public static DateTime feeDate = new DateTime();

        //public static BasicListFunc(SchContext context)
        //{
        //    _context = context;
        //}

        public static List<SelectListItem> GetSchClssF(SchContext _context, string dSess, int mdBId)
        {
            dClss = "";
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                if (!(string.IsNullOrWhiteSpace(dSess) || (dSess == "None")))
                {
                    kMySql = " SELECT DISTINCT ClsName ";
                    kMySql = kMySql + " FROM  Clss";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    kMySql = kMySql + " AND AcaSession = '" + dSess + "'";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (dClss == "") { dClss = kMyReader.GetString(0); }
                                SchClsLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                                //StrClsLst.Add(kMyReader.GetString(0));
                            }
                        }
                    }
                }
                else
                {
                    SchClsLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
                }
                conn.Close();
            }
            return SchClsLst;
        }

        public static List<SelectListItem> GetFeeCatF(SchContext _context, string dSess, int mdBId)
        {
            SchFeeCatLst.Clear();
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                if (!(string.IsNullOrWhiteSpace(dSess) || (dSess == "None")))
                {
                    kMySql = " SELECT DISTINCT StdCategory ";
                    kMySql = kMySql + " FROM  stdCat";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    //kMySql = kMySql + " AND AcaSession = '" + dSess + "'";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                SchFeeCatLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                            }
                        }
                    }
                }
                else
                {
                    SchFeeCatLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
                }
                conn.Close();
            }
            return SchFeeCatLst;
        }

        public static List<SelectListItem> GetStdFeeNameF(SchContext _context, string clss, string tSess, string stdFeeCat, string dSess, int mdBId)
        {
            SchFeeNameLst.Clear();
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                if (!(string.IsNullOrWhiteSpace(dSess) || (dSess == "None")))
                {
                    kMySql = " SELECT DISTINCT FeeCaption,ForMonth";
                    kMySql = kMySql + " FROM  DynaFee";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    kMySql = kMySql + " AND SessionName = '" + tSess + "'";
                    kMySql = kMySql + " AND ForClass = '" + clss + "'";
                    kMySql = kMySql + " AND StdCategory = '" + stdFeeCat + "'";
                    kMySql = kMySql + " ORDER BY ForMonth";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                SchFeeNameLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                            }
                        }
                    }
                }
                else
                {
                    SchFeeNameLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
                }
                conn.Close();
            }
            return SchFeeNameLst;
        }

        public static DateTime GetStdFeeDateF(SchContext _context, string clss, string tSess, string stdFeeCat, string stdFeeCap, string dSess, int mdBId)
        {
            feeDate = DateTime.Now;
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT ForMonth ";
                kMySql = kMySql + " FROM  DynaFee";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                kMySql = kMySql + " AND SessionName = '" + tSess + "'";
                kMySql = kMySql + " AND ForClass = '" + clss + "'";
                kMySql = kMySql + " AND FeeCaption = '" + stdFeeCap + "'";
                kMySql = kMySql + " AND StdCategory = '" + stdFeeCat + "'";
                command.CommandText = kMySql;
                command.CommandType = CommandType.Text;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            feeDate = GloFunc.FromOADate(kMyReader.GetInt32(0));
                        }
                    }
                }
            }
            conn.Close();
            return feeDate;
        }

        public static async System.Threading.Tasks.Task<int> CreateStdFAsync(SchContext _context, Students stdnts)
        {
            string MySql = "";
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = "INSERT INTO Students (";
                    MySql = MySql + " RegNumber, FirstName, Sex, DOB, ParentsNamesF, PresentClass, StdCategory, StdSession, StdStatus, EmailAddress,";
                    MySql = MySql + " UniReg, DateOfAdmission, ConPhone, StdGenCategory,";
                    MySql = MySql + " LoginName, ModTime, Dormant, cTerminal, dBID ) VALUES ( ";
                    MySql = MySql + " 0,'" + stdnts.StdName + "',";
                    if (stdnts.Sex == "Boy")
                    {
                        MySql = MySql + "1,";
                    }
                    else
                    {
                        MySql = MySql + "0,";
                    }
                    MySql = MySql + GloFunc.ToOADate(stdnts.Dob) + ",'" + stdnts.ParentsNamesF + "','" + stdnts.PresentClass + "','";
                    MySql = MySql + stdnts.StdCategory + "','" + stdnts.StdSession + "', 0,'" + stdnts.EmailAddress + "',0,";
                    MySql = MySql + GloFunc.ToOADate(DateTime.Now) + ",'" + stdnts.ConPhone + "','" + stdnts.StdGenCategory + "','";
                    MySql = MySql + repSplChr(strLoginName) + "'," + GloFunc.ToOADate(DateTime.Now) + ",0,'" + repSplChr(strComputerName) + "'," + stdnts.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                conn.Close();
                return 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return 1;
            }

        }

        public static Boolean UpdateAcaSession(AcaSession acaSession)
        {
            return true;
        }


    }
}
