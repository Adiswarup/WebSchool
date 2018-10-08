using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Basics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using WebCat7.Data;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.GenFunction
{
    public static class AcaFunctions
    {
        public static List<SelectListItem> SchTeachLst = new List<SelectListItem>();
        public static List<DropDownTeach> drpTeachLst = new List<DropDownTeach>();
        public static List<string> strTeachLst = new List<string>();

        public static List<SelectListItem> SchSessLst = new List<SelectListItem>();
        public static List<DropDown> drpSessLst = new List<DropDown>();
        public static List<string> strSessLst = new List<string>();

        public static List<SelectListItem> SchActGrdLst = new List<SelectListItem>();
        public static List<DropDown> drpActGrdLst = new List<DropDown>();
        public static List<string> strActGrdLst = new List<string>();

        public static List<SelectListItem> SchClsLst = new List<SelectListItem>();
        public static List<DropDown> drpClsLst = new List<DropDown>();
        public static List<String> StrClsLst = new List<String>();

        public static List<SelectListItem> SchActGrpLst = new List<SelectListItem>();
        public static List<String> StrActGrpLst = new List<String>();
        public static List<DropDown> drpActGrpLst = new List<DropDown>();

        public static List<SelectListItem> SchActLst = new List<SelectListItem>();
        public static List<String> StrActLst = new List<String>();
        public static List<DropDown> drpActLst = new List<DropDown>();

        public static List<SelectListItem> SchExmLst = new List<SelectListItem>();
        public static List<SelectListItem> SchSubLst = new List<SelectListItem>();
        //private   string kMySql;
        public static List<SelectListItem> SchVehTypLst = new List<SelectListItem>();
        public static List<String> StrVehTypLst = new List<String>();
        public static List<DropDown> drpVehTypLst = new List<DropDown>();

        public static List<SelectListItem> SchStopLst = new List<SelectListItem>();
        public static List<String> StrStopLst = new List<String>();
        public static List<DropDown> drpStopLst = new List<DropDown>();

         public static List<SelectListItem> SchStdFeeCat = new List<SelectListItem>();
        public static List<String> StrStdFeeCat = new List<String>();
        public static List<DropDown> drpStdFeeCat = new List<DropDown>();

       #region "Fill Lists"

        public static void GetSchTeachers(SchContext _context, Boolean tMode = false)
        {
            strTeachLst.Clear();
            SchTeachLst.Clear();
            drpTeachLst.Clear();

            string kMySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                //dSess = "";
                SchTeachLst.Clear();
                kMySql = " SELECT DISTINCT tName ";
                kMySql = kMySql + " FROM  Teachers";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                command.CommandText = kMySql;

                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            if (tMode)
                            {
                                SchTeachLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                            }
                            else
                            {
                                drpTeachLst.Add(new DropDownTeach { classTeacher = kMyReader.GetString(0)});
                            }
                            strTeachLst.Add(kMyReader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        public static async Task<List<Teachers>> GetTeachLst(SchContext _context, string tAcaSession)
        {
            List<Teachers> teachList = new List<Teachers>();
            string MySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT  AutoID, TeachID, tName, tTelephone, TeachEMail, TeachLoginName ";
                MySql = MySql + " FROM Teachers WITH (NOLOCK) ";
                MySql = MySql + " WHERE Dormant =0 ";
                MySql = MySql + " AND DBID = " + mdBId;
                MySql = MySql + " ORDER BY tName";

                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        Teachers teachs = new Teachers();
                        if (!kMyReader.IsDBNull(0)) { teachs.AutoId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { teachs.teachId = kMyReader.GetInt32(1); }
                        if (!kMyReader.IsDBNull(2)) { teachs.tName = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { teachs.tTelephone = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { teachs.teachEMail = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { teachs.teachLoginName = kMyReader.GetString(5); }
                        teachList.Add(teachs);
                    }
                }
                conn.Close();
                return teachList;
            }

        }

        public static void GetActivityGradeType(SchContext _context, Boolean tMode = true)
        {
            strActGrdLst.Clear();
            SchActGrdLst.Clear();
            drpActGrdLst.Clear();
            string kMySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                //dSess = "";
                SchSessLst.Clear();
                kMySql = " SELECT DISTINCT GradeType ";
                kMySql = kMySql + " FROM  ActivityGroup";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                command.CommandText = kMySql;

                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            //if (dSess == "") { dSess = kMyReader.GetString(0); }
                            if (tMode)
                            {
                                SchActGrdLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                            }
                            else
                            {
                                drpActGrdLst.Add(new DropDown { drptext = kMyReader.GetString(0) });//, value = kMyReader.GetString(0)
                            }
                            strActGrdLst.Add(kMyReader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        public static void GetSchSession(SchContext _context)
        {
            strSessLst.Clear();
            SchSessLst.Clear();
            drpSessLst.Clear();
            string kMySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                //dSess = "";
                SchSessLst.Clear();
                kMySql = " SELECT DISTINCT SessionName ";
                kMySql = kMySql + " FROM  AcaSession";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                command.CommandText = kMySql;

                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            drpSessLst.Add(new DropDown { drptext = kMyReader.GetString(0)});//, value = kMyReader.GetString(0) 
                            strSessLst.Add(kMyReader.GetString(0));
                            SchSessLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                        }
                    }
                }
                conn.Close();
            }
            //return new SelectList(SchSessLst, "Value", "Text", null);
        }

        public static void GetSchClss(SchContext _context)
        {
            SchClsLst.Clear();
            StrClsLst.Clear();
            drpClsLst.Clear();
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
                                StrClsLst.Add(kMyReader.GetString(0));
                                drpClsLst.Add(new DropDown { drptext = kMyReader.GetString(0) });//, value = kMyReader.GetString(0)
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
        }

        public static async Task<SelectList> GetSchExm(SchContext _context, string tCls = "")
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

        public static async Task<SelectList> GetSchSub(SchContext _context, string tCls = "", string tExm = "")
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

        public static async void GetStdFeeCat(SchContext _context )
        {
            string kMySql = "";
            SchStdFeeCat.Clear();
            StrStdFeeCat.Clear();
            drpStdFeeCat.Clear();
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT DISTINCT StdCategory  ";
                kMySql = kMySql + " FROM  stdCat";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                command.CommandText = kMySql;
                command.CommandType = CommandType.Text;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            drpStdFeeCat.Add(new DropDown { drptext = kMyReader.GetString(0) });//, value = kMyReader.GetString(0)
                            StrStdFeeCat.Add(kMyReader.GetString(0));
                            SchStdFeeCat.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                        }
                    }
                }
                conn.Close();
            }
        }
        #endregion

        //public static async Task<int> GetSubID(SchContext _context, string tSubjects, string tClass)
        //{
        //    string MySql2 = "";
        //    object tmpObj;
        //    var conn = _context.Database.GetDbConnection();
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        await conn.OpenAsync();
        //    }
        //    using (var command = conn.CreateCommand())
        //    {
        //        MySql2 = " SELECT SubID FROM Subjects WITH (NOLOCK)";
        //        MySql2 = MySql2 + " WHERE SubName = '" + repSplChr(tSubjects) + "'";
        //        MySql2 = MySql2 + " AND Clss = '" + repSplChr(tClass) + "'";
        //        MySql2 = MySql2 + " AND AcaSession = '" + dSess + "'";
        //        MySql2 = MySql2 + " AND Dormant = 0";
        //        MySql2 = MySql2 + " AND dBID = " + mdBId;

        //        command.CommandText = MySql2;
        //        command.CommandType = CommandType.Text;
        //        tmpObj =  command.ExecuteScalar();
        //        if (!((Object)tmpObj == null))
        //        {
        //            if (GloFunc.IsNumeric(tmpObj.ToString()))
        //            {
        //                return int.Parse(tmpObj.ToString());
        //            }
        //            else
        //            {
        //                return -1;
        //            }
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //        //conn.Close();
        //    }
        //}


        #region "Activity"

        public static void GetActGrpLst(SchContext _context)
        {
            drpActGrpLst.Clear();
            StrActGrpLst.Clear();
            SchActGrpLst.Clear();
            dActGrp = "";
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
                    kMySql = " SELECT DISTINCT ActGroupName ";
                    kMySql = kMySql + " FROM  ActivityGroup";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (dActGrp == "") { dActGrp = kMyReader.GetString(0); }
                                SchActGrpLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                                StrActGrpLst.Add(kMyReader.GetString(0));
                                drpActGrpLst.Add(new DropDown { drptext = kMyReader.GetString(0) });//, value = kMyReader.GetString(0)

                            }
                        }
                    }
                }
                else
                {
                    SchActGrpLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
                }
                conn.Close();
            }
        }

        public static void GetActivity(SchContext _context, string tActGrp, Boolean tMode = true)
        {
            StrActLst.Clear();
            SchActLst.Clear();
            drpActLst.Clear();
            StrActLst.Add("None");
            SchActLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
            drpActLst.Add(new DropDown { drptext = "None"});
            string kMySql;
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                //dSess = "";
                SchSessLst.Clear();
                kMySql = " SELECT DISTINCT ActivityName ";
                kMySql = kMySql + " FROM  Activity";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  ActivityGroup = '" + tActGrp + "'";
                kMySql = kMySql + " AND  Dormant = 0";
                command.CommandText = kMySql;

                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        if (!kMyReader.IsDBNull(0))
                        {
                            //if (dSess == "") { dSess = kMyReader.GetString(0); }
                            SchActLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                            drpActLst.Add(new DropDown { drptext = kMyReader.GetString(0)});
                            StrActLst.Add(kMyReader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        #endregion

        #region "Conveyance"

        public static void GetVehTypLst(SchContext _context)
        {
            SchVehTypLst.Clear();
            StrVehTypLst.Clear();
            drpVehTypLst.Clear();
            StrVehTypLst.Add("None");
            SchVehTypLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
            drpVehTypLst.Add(new DropDown { drptext = "None"});
            var dVeh = "";
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
                    kMySql = " SELECT DISTINCT VehicleType ";
                    kMySql = kMySql + " FROM  VehicleType";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (dVeh == "") { dVeh = kMyReader.GetString(0); }
                                SchVehTypLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                                StrVehTypLst.Add(kMyReader.GetString(0));
                                drpVehTypLst.Add(new DropDown { drptext = kMyReader.GetString(0)});
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        public static void GetStopLst(SchContext _context)
        {
            SchStopLst.Clear();
            StrStopLst.Clear();
            drpStopLst.Clear();
            StrStopLst.Add("None");
            SchStopLst.Add(new SelectListItem { Text = "None", Value = "None", Selected = true });
            drpStopLst.Add(new DropDown { drptext = "None"});

            var dVeh = "";
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
                    kMySql = " SELECT Stops, StopID ";
                    kMySql = kMySql + " FROM  Stops";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            if (!kMyReader.IsDBNull(0))
                            {
                                if (dVeh == "") { dVeh = kMyReader.GetString(0); }
                                SchStopLst.Add(new SelectListItem { Text = kMyReader.GetString(0), Value = kMyReader.GetString(0), Selected = true });
                                StrStopLst.Add(kMyReader.GetString(0));
                                drpStopLst.Add(new DropDown { drptext = kMyReader.GetString(0)});
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        #endregion

    }
}
//public static async Task<List<Marks>> GetMarksLst(SchContext _context, string tClass)
//{
//    List<Marks> markList = new List<Marks>();
//    string MySql;
//    string fName = "";
//    string mName = "";
//    string lName = "";
//    var conn = _context.Database.GetDbConnection();
//    if (conn.State != ConnectionState.Open)
//    {
//        await conn.OpenAsync();
//    }
//    using (var command = conn.CreateCommand())
//    {
//        MySql = "SELECT  RegNumber,PresentRollNo, FirstName, MiddleName, LastName,StdStatus,Unireg ";
//        MySql = MySql + " FROM Students WITH (NOLOCK) ";
//        MySql = MySql + " WHERE PresentClass='" + repSplChr(tClass) + "'";
//        MySql = MySql + " AND StdSession='" + dSess + "'";
//        MySql = MySql + " AND Dormant =0 ";
//        MySql = MySql + " AND StdStatus <=1 ";
//        MySql = MySql + " AND DBID = " + mdBId;
//        MySql = MySql + " ORDER BY PresentRollNo";

//        command.CommandText = MySql;
//        DbDataReader kMyReader = await command.ExecuteReaderAsync();
//        if (kMyReader.HasRows)
//        {
//            while (kMyReader.Read())
//            {
//                Marks marks = new Marks();
//                if (!kMyReader.IsDBNull(0)) { marks.RegNum = kMyReader.GetInt32(0); }
//                if (!kMyReader.IsDBNull(1)) { marks.presentRollNum = kMyReader.GetInt32(1); }
//                if (!kMyReader.IsDBNull(2)) { fName = kMyReader.GetString(2); }
//                if (!kMyReader.IsDBNull(3)) { mName = kMyReader.GetString(3); }
//                if (!kMyReader.IsDBNull(4)) { lName = kMyReader.GetString(4); }
//                marks.StdName = fName + mName + lName;
//                //if (!kMyReader.IsDBNull(5)) { marks.stdStatus = kMyReader.GetInt32(5); }
//                if (!kMyReader.IsDBNull(6)) { marks.UniReg = kMyReader.GetInt32(6); }
//                markList.Add(marks);
//            }
//        }
//        conn.Close();
//        return markList;
//    }

//}

//public static async Task<string> GetGradeType(SchContext _context, string tSubjects, string tClass)
//{
//    string MySql;
//    string cbGradesType = "";
//    var conn = _context.Database.GetDbConnection();
//    if (conn.State != ConnectionState.Open)
//    {
//        await conn.OpenAsync();
//    }
//    using (var command = conn.CreateCommand())
//    {
//        MySql = "SELECT GradeType,GradeOrMarks";
//        MySql = MySql + " FROM Subjects WITH (NOLOCK) ";
//        MySql = MySql + " WHERE Dormant=0";
//        MySql = MySql + " AND Clss='" + repSplChr(tClass) + "'";
//        MySql = MySql + " AND SubName='" + repSplChr(tSubjects) + "'";
//        MySql = MySql + " AND AcaSession='" + dSess + "'";
//        MySql = MySql + " AND Dormant =0";
//        MySql = MySql + " AND DBID =  " + mdBId;
//        command.CommandText = MySql;
//        DbDataReader kMyReader = await command.ExecuteReaderAsync();
//        if (kMyReader.HasRows)
//        {
//            kMyReader.Read();
//            if (!kMyReader.IsDBNull(0))
//            {
//                if (kMyReader.GetInt32(1) == 1)
//                {
//                    cbGradesType = kMyReader.GetString(0);
//                }
//            }
//        }
//        conn.Close();
//        return cbGradesType;
//    }
//}