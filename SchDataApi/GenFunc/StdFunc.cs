using Microsoft.EntityFrameworkCore;
using SchDataApi.Controllers.StdFees;
using SchDataApi.DataLayer;
using SchMod.Models.Active;
using SchMod.Models.Studs;
using SchMod.ViewModels.StdFees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.GenFunc
{
    public static class StdFunc
    {
        public static async Task<List<Students>> GetStdList(SchContext _context, int mdBId, string tSess = "", string tCls = "", string tSearchstr = "")
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
                MySql = MySql + " StdGenCategory, ConPhone, UniReg, EmailAddress, ";
                MySql = MySql + " Religion, ParentsNamesM, StdCategory, Color_House,";
                MySql = MySql + " PermIdentification,   MPhone,    Nationality,";
                MySql = MySql + " BoardRollCode, AAdhar,Photo";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND ( FirstName LIKE  '%" + tSearchstr + "%' OR ParentsNamesF LIKE  '%" + tSearchstr + "%' OR ParentsNamesM LIKE  '%" + tSearchstr + "%')";
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
                        students.StdName = fName + mName + lName;
                        //Sex, DOB, ParentsNamesF,
                        if (!kMyReader.IsDBNull(5))
                        {
                            if (kMyReader.GetInt32(5) == 1)
                            {
                                students.Sex = "Boy";
                            }
                            else
                            {
                                students.Sex = "Girl";
                            }
                        }
                        if (!kMyReader.IsDBNull(6)) { students.Dob = GloFunc.FromOADate(kMyReader.GetDouble(6)); }
                        if (!kMyReader.IsDBNull(7)) { students.ParentsNamesF = kMyReader.GetString(7); }
                        //StdGenCategory, ConPhone, UniReg, EmailAddress
                        if (!kMyReader.IsDBNull(8)) { students.StdGenCategory = kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { students.ConPhone = kMyReader.GetString(9); }
                        if (!kMyReader.IsDBNull(10)) { students.UniReg = kMyReader.GetInt32(10); }
                        if (!kMyReader.IsDBNull(11)) { students.EmailAddress = kMyReader.GetString(11); }

                        //" Religion,    ParentsNamesM,";
                        if (!kMyReader.IsDBNull(12)) { students.Religion = kMyReader.GetString(12); }
                        if (!kMyReader.IsDBNull(13)) { students.ParentsNamesM = kMyReader.GetString(13); }
                        //" StdCategory,   Color_House,";
                        if (!kMyReader.IsDBNull(14)) { students.StdCategory = kMyReader.GetString(14); }
                        if (!kMyReader.IsDBNull(15)) { students.Color_House = kMyReader.GetString(15); }
                        //" PermIdentification,   MPhone,    Nationality,";
                        if (!kMyReader.IsDBNull(16)) { students.PermIdentification = kMyReader.GetString(16); }
                        if (!kMyReader.IsDBNull(17)) { students.Mphone = kMyReader.GetString(17); }
                        if (!kMyReader.IsDBNull(18)) { students.Nationality = kMyReader.GetString(18); }
                        //BoardRollCode, AAdhar
                        if (!kMyReader.IsDBNull(19)) { students.BoardRollCode = kMyReader.GetString(19); }
                        if (!kMyReader.IsDBNull(20)) { students.Aadhar = kMyReader.GetString(20); }
                        if (!kMyReader.IsDBNull(21))
                        {
                            students.ImgDataURL = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])(kMyReader.GetValue(21))));
                        }
                        schStdLst.Add(students);
                    }
                }
                conn.Close();
            }
            return schStdLst;
        }

        public static async Task<FeeForm> getStdDetails(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            string fName = "";
            string mName = "";
            string lName = "";

            FeeForm stdDetFee = new FeeForm
            {
                Sn = 1
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT UniReg, PresentRollNo, FirstName, MiddleName, LastName, Sex, DOB, ParentsNamesF, ParentsNamesM, ";
                MySql = MySql + " ConPhone, PresentClass, EmailAddress, StdCategory ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND   RegNumber = " + regNum;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { stdDetFee.UniReg = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { stdDetFee.RollNo = kMyReader.GetInt32(1); }
                    if (!kMyReader.IsDBNull(2)) { fName = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { mName = kMyReader.GetString(3); }
                    if (!kMyReader.IsDBNull(4)) { lName = kMyReader.GetString(4); }
                    stdDetFee.StdName = fName + " " + mName + " " + lName;
                    //Sex, DOB, ParentsNamesF,
                    if (!kMyReader.IsDBNull(5))
                    {
                        if (kMyReader.GetInt32(5) == 1)
                        {
                            stdDetFee.Gender = "Boy";
                        }
                        else
                        {
                            stdDetFee.Gender = "Girl";
                        }
                        if (!kMyReader.IsDBNull(6)) { stdDetFee.DOB = GloFunc.FromOADate(kMyReader.GetDouble(6)); }
                        if (!kMyReader.IsDBNull(7)) { stdDetFee.FNames = kMyReader.GetString(7); }
                        if (!kMyReader.IsDBNull(8)) { stdDetFee.MNames = kMyReader.GetString(8); }
                        //StdGenCategory, ConPhone, UniReg, EmailAddress
                        if (!kMyReader.IsDBNull(9)) { stdDetFee.ConPhone = kMyReader.GetString(9); }
                        if (!kMyReader.IsDBNull(10)) { stdDetFee.Clss = kMyReader.GetString(10); }
                        if (!kMyReader.IsDBNull(11)) { stdDetFee.EmailAddress = kMyReader.GetString(11); }
                        if (!kMyReader.IsDBNull(12)) { stdDetFee.StdCat = kMyReader.GetString(12); }
                    }
                }
                conn.Close();
                return stdDetFee;

            }
        }

        public static async Task<Students> getStdGenEdit(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            string fName = "";
            string mName = "";
            string lName = "";
            List<Profile_Attendance> schAttLst = new List<Profile_Attendance>();
            List<Profile_Activity> schActLst = new List<Profile_Activity>();
            List<Profile_Receipt> schRecLst = new List<Profile_Receipt>();
            Students stdGenEdit = new Students
            {
                RegNumber = regNum,
                StdSession = dSess,
                DBid = mdBId
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT UniReg, PresentRollNo, FirstName, MiddleName, LastName, Sex, DOB, ParentsNamesF, ParentsNamesM, ";
                MySql = MySql + " ConPhone, PresentClass, EmailAddress, StdCategory ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND   RegNumber = " + regNum;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { stdGenEdit.UniReg = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { stdGenEdit.PresentRollNo = kMyReader.GetInt32(1); }
                    if (!kMyReader.IsDBNull(2)) { fName = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { mName = kMyReader.GetString(3); }
                    if (!kMyReader.IsDBNull(4)) { lName = kMyReader.GetString(4); }
                    stdGenEdit.StdName = fName + " " + mName + " " + lName;
                    //Sex, DOB, ParentsNamesF,
                    if (!kMyReader.IsDBNull(5))
                    {
                        if (kMyReader.GetInt32(5) == 1)
                        {
                            stdGenEdit.Sex = "Boy";
                        }
                        else
                        {
                            stdGenEdit.Sex = "Girl";
                        }
                    }
                    if (!kMyReader.IsDBNull(6)) { stdGenEdit.Dob = GloFunc.FromOADate(kMyReader.GetDouble(6)); }
                    if (!kMyReader.IsDBNull(7)) { stdGenEdit.ParentsNamesF = kMyReader.GetString(7); }
                    if (!kMyReader.IsDBNull(8)) { stdGenEdit.ParentsNamesM = kMyReader.GetString(8); }
                    //StdGenCategory, ConPhone, UniReg, EmailAddress
                    if (!kMyReader.IsDBNull(9)) { stdGenEdit.ConPhone = kMyReader.GetString(9); }
                    if (!kMyReader.IsDBNull(10)) { stdGenEdit.PresentClass = kMyReader.GetString(10); }
                    if (!kMyReader.IsDBNull(11)) { stdGenEdit.EmailAddress = kMyReader.GetString(11); }
                    if (!kMyReader.IsDBNull(12)) { stdGenEdit.StdCategory = kMyReader.GetString(12); }
                }
                kMyReader.Close();
            }
            var pathPict = Path.Combine(
               Directory.GetCurrentDirectory(),
               "wwwroot" + "/userImages/", regNum + "Pict.jpg");
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT Photo FROM Students"
                            + " WHERE RegNumber = " + regNum
                             + " AND StdStatus = 0"
                             + " AND dBID = " + mdBId
                                + " AND Dormant = 0";
                command.CommandText = MySql;
                DbDataReader MyReaderPict = command.ExecuteReader();
                if (MyReaderPict.HasRows)
                {
                    MyReaderPict.Read();
                    stdGenEdit.ImajePict = (byte[])(MyReaderPict.GetValue(0));
                    System.IO.File.WriteAllBytes(pathPict, stdGenEdit.ImajePict);
                }
                MyReaderPict.Close();
            }
            //Profile Attendance
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT  TransActID, TransActName,  TransActDate, TransActObserver, TeachID, TransActRemarks FROM TransActivity"
                            + " WHERE RegNumber = " + regNum
                              + " AND Dormant = 0"
                                + " AND dBID = " + mdBId
                                    + " Order BY TransActDate DESC";
                command.CommandText = MySql;
                DbDataReader MyReaderAtt = command.ExecuteReader();
                if (MyReaderAtt.HasRows)
                {
                    while (MyReaderAtt.Read())
                    {
                        Profile_Activity schAct = new Profile_Activity();
                        if (!MyReaderAtt.IsDBNull(0)) { schAct.AutoId = MyReaderAtt.GetInt32(0); }
                        if (!MyReaderAtt.IsDBNull(1)) { schAct.Activity = MyReaderAtt.GetString(1); }
                        if (!MyReaderAtt.IsDBNull(2)) { schAct.ActDate = DateTime.FromOADate(MyReaderAtt.GetDouble(2)); }
                        if (!MyReaderAtt.IsDBNull(3)) { schAct.LoggedBy = MyReaderAtt.GetString(3); }
                        if (!MyReaderAtt.IsDBNull(5)) { schAct.ActRemarks = MyReaderAtt.GetString(5); }
                        schActLst.Add(schAct);
                    }
                }
                MyReaderAtt.Close();
                stdGenEdit.StdActLst = schActLst;
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT AttID, AtType, AttDate, Cause, Remark FROM Attendance"
                            + " WHERE RegNum = " + regNum
                                + " AND Dormant = 0"
                                   + " AND dBID = " + mdBId
                                    + " Order BY AttDate DESC";
                command.CommandText = MySql;
                DbDataReader MyReaderAtt = command.ExecuteReader();
                if (MyReaderAtt.HasRows)
                {
                    while (MyReaderAtt.Read())
                    {
                        Profile_Attendance schAtt = new Profile_Attendance();
                        if (!MyReaderAtt.IsDBNull(0)) { schAtt.AutoId = MyReaderAtt.GetInt32(0); }
                        if (!MyReaderAtt.IsDBNull(1)) { schAtt.AtType = MyReaderAtt.GetString(1); }
                        if (!MyReaderAtt.IsDBNull(2)) { schAtt.AttDate = DateTime.FromOADate(MyReaderAtt.GetDouble(2)); }
                        if (!MyReaderAtt.IsDBNull(3)) { schAtt.AttReason = MyReaderAtt.GetString(3); }
                        if (!MyReaderAtt.IsDBNull(4)) { schAtt.AttRemarks = MyReaderAtt.GetString(4); }
                        schAttLst.Add(schAtt);
                    }
                }
                MyReaderAtt.Close();
                stdGenEdit.StdAttLst = schAttLst;
            }
            //Receipt 
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT DISTINCT FeeCaption, ForMonth FROM DynaFee"
                            + " WHERE Dormant = 0"
                                  + " AND ForClass   = '" + stdGenEdit.PresentClass + "'"
                                  + " AND StdCategory    = '" + stdGenEdit.StdCategory + "'"
                                  + " AND SessionName  = '" + dSess + "'"
                                  + " AND dBID = " + mdBId
                                   + " Order BY ForMonth";
                command.CommandText = MySql;
                DbDataReader MyReaderRec = command.ExecuteReader();
                if (MyReaderRec.HasRows)
                {
                    while (MyReaderRec.Read())
                    {
                        Profile_Receipt schRec = new Profile_Receipt();
                        if (!MyReaderRec.IsDBNull(0)) { schRec.FeeName = MyReaderRec.GetString(0); }
                        if (!MyReaderRec.IsDBNull(1))
                        {
                            schRec.ForMonthX = MyReaderRec.GetInt32(1);
                            schRec.ForMonth = DateTime.FromOADate(MyReaderRec.GetInt32(1)).ToLongDateString();
                        }
                        schRecLst.Add(schRec);
                    }
                }
                MyReaderRec.Close();

                stdGenEdit.StdRecLst = schRecLst;
            }
            using (var command = conn.CreateCommand())
            {
                DbDataReader MyReaderRec;
                foreach (var item in schRecLst)
                {
                    MySql = " SELECT Sum(Amount) FROM DynaFee"
                                  + " WHERE Dormant = 0"
                                        + " AND ForClass   = '" + stdGenEdit.PresentClass + "'"
                                        + " AND StdCategory    = '" + stdGenEdit.StdCategory + "'"
                                        + " AND SessionName  = '" + dSess + "'"
                                        + " AND dBID = " + mdBId
                                        + " AND ForMonth = " + item.ForMonthX;
                    command.CommandText = MySql;
                    MyReaderRec = command.ExecuteReader();
                    if (MyReaderRec.HasRows)
                    {
                        MyReaderRec.Read();
                        if (!MyReaderRec.IsDBNull(0))
                        {
                            item.Amount = MyReaderRec.GetDouble(0).ToString();
                        }
                    }
                    MyReaderRec.Close();
                }

                foreach (var item in schRecLst)
                {
                    MySql = " SELECT ReceiptDate, AmountPaid FROM Receipt"
                                  + " WHERE Dormant = 0"
                                        + " AND RegNo   = " + stdGenEdit.RegNumber  
                                        + " AND AcaSession  = '" + dSess + "'"
                                        + " AND dBID = " + mdBId
                                        + " AND ForPeriod = " + item.ForMonthX;
                    command.CommandText = MySql;
                    MyReaderRec = command.ExecuteReader();
                    if (MyReaderRec.HasRows)
                    {
                        MyReaderRec.Read();
                        if (!MyReaderRec.IsDBNull(0)) { item.RecDate = DateTime.FromOADate(MyReaderRec.GetDouble(0)).ToLongDateString(); }
                        if (!MyReaderRec.IsDBNull(1)) { item.Paid = MyReaderRec.GetDouble(1).ToString(); }
                    }
                    MyReaderRec.Close();
                }
            }
            conn.Close();

            return stdGenEdit;
        }

        public static async Task<Students> SaveEditGenAsync(SchContext _context, Students Stds)
        {
            try
            {
                string MySql;
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE Students SET ";
                    MySql = MySql + " PresentRollNo = " + Stds.PresentRollNo + ",";
                    MySql = MySql + " FirstName = '" + Stds.StdName + "',";
                    switch (Stds.Sex)
                    {
                        case "Boy":
                            MySql = MySql + " Sex = 1,";
                            break;
                        case "Girl":
                            MySql = MySql + " Sex = 0,";
                            break;
                        default:
                            MySql = MySql + " Sex = -1,";
                            break;
                    }
                    MySql = MySql + " DOB = " + GloFunc.ToOADate(Stds.Dob) + ",";
                    MySql = MySql + " ParentsNamesF = '" + Stds.ParentsNamesF + "',";
                    MySql = MySql + " ParentsNamesM = '" + Stds.ParentsNamesM + "',";
                    MySql = MySql + " ConPhone = '" + Stds.ConPhone + "',";
                    MySql = MySql + " PresentClass = '" + Stds.PresentClass + "',";
                    MySql = MySql + " EmailAddress = '" + Stds.EmailAddress + "',";
                    MySql = MySql + " StdCategory = '" + Stds.StdCategory + "'";
                    MySql = MySql + " WHERE StdSession ='" + repSplChr(Stds.StdSession) + "'";
                    MySql = MySql + " AND DBID =  " + Stds.DBid;
                    //MySql = MySql + " AND UniReg =" + Stds.UniReg;
                    MySql = MySql + " AND RegNumber =" + Stds.RegNumber;
                    MySql = MySql + " AND Dormant = 0 ";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MarksExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //} 
                //return HttpStatusCode.NotModified();
            }
            return Stds;
            //return new OkObjectResult(Stds);
        }

        public static async Task<Students> getStdAddressEdit(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            Students stdAddrEdit = new Students
            {
                RegNumber = regNum,
                StdSession = dSess,
                DBid = mdBId
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT UniReg, FirstName, Address, Address1, City, State, PostalCode, PermAddress,  ";
                MySql = MySql + " PermAddress1, PermCity, PermState, PermPostalCode, BusRoute, Notes ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND   RegNumber = " + regNum;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { stdAddrEdit.UniReg = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { stdAddrEdit.StdName = kMyReader.GetString(1); }
                    if (!kMyReader.IsDBNull(2)) { stdAddrEdit.Address = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { stdAddrEdit.Address1 = kMyReader.GetString(3); }
                    if (!kMyReader.IsDBNull(5)) { stdAddrEdit.City = kMyReader.GetString(4); }
                    if (!kMyReader.IsDBNull(5)) { stdAddrEdit.State = kMyReader.GetString(5); }
                    if (!kMyReader.IsDBNull(6)) { stdAddrEdit.PostalCode = kMyReader.GetString(6); }
                    if (!kMyReader.IsDBNull(7)) { stdAddrEdit.PermAddress = kMyReader.GetString(7); }
                    if (!kMyReader.IsDBNull(8)) { stdAddrEdit.PermAddress1 = kMyReader.GetString(8); }
                    if (!kMyReader.IsDBNull(9)) { stdAddrEdit.PermCity = kMyReader.GetString(9); }
                    if (!kMyReader.IsDBNull(10)) { stdAddrEdit.PermState = kMyReader.GetString(10); }
                    if (!kMyReader.IsDBNull(11)) { stdAddrEdit.PermPostalCode = kMyReader.GetString(11); }
                    if (!kMyReader.IsDBNull(12)) { stdAddrEdit.BusRoute = kMyReader.GetString(12); }
                    if (!kMyReader.IsDBNull(13)) { stdAddrEdit.Notes = kMyReader.GetString(13); }
                }
                conn.Close();
                return stdAddrEdit;

            }
        }

        public static async Task<Students> SaveEditAddressAsync(SchContext _context, Students Stds)
        {
            try
            {
                string MySql;
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE Students SET ";
                    MySql = MySql + " Address = '" + Stds.Address + "',";
                    MySql = MySql + " Address1 = '" + Stds.Address1 + "',";
                    MySql = MySql + " City = '" + Stds.City + "',";
                    MySql = MySql + " State = '" + Stds.State + "',";
                    MySql = MySql + " PostalCode = '" + Stds.PostalCode + "',";
                    //PermAddress1, PermCity, PermState, PermPostalCode, BusRoute, Notes
                    MySql = MySql + " PermAddress1 = '" + Stds.PermAddress1 + "',";
                    MySql = MySql + " PermCity = '" + Stds.PermCity + "',";
                    MySql = MySql + " PermState = '" + Stds.PermState + "',";
                    MySql = MySql + " PermPostalCode = '" + Stds.PermPostalCode + "',";
                    MySql = MySql + " BusRoute = '" + Stds.BusRoute + "',";
                    MySql = MySql + " Notes = '" + Stds.Notes + "'";
                    MySql = MySql + " WHERE StdSession ='" + repSplChr(Stds.StdSession) + "'";
                    MySql = MySql + " AND DBID =  " + Stds.DBid;
                    //MySql = MySql + " AND UniReg =" + Stds.UniReg;
                    MySql = MySql + " AND RegNumber =" + Stds.RegNumber;
                    MySql = MySql + " AND Dormant = 0 ";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return Stds;
            //return new OkObjectResult(Stds);
        }

        public static async Task<Students> getStdFamilyEdit(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            Students stdFamEdit = new Students
            {
                RegNumber = regNum,
                StdSession = dSess,
                DBid = mdBId
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT UniReg, FirstName, ParentsNamesF, AnnualIncome, HPhone, StdGenCategory, Aadhar, ";
                MySql = MySql + "  OccupationF, QualificationF, ParentsNamesM, OccupationM, QualificationM ";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND   RegNumber = " + regNum;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { stdFamEdit.UniReg = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { stdFamEdit.StdName = kMyReader.GetString(1); }
                    if (!kMyReader.IsDBNull(2)) { stdFamEdit.ParentsNamesF = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { stdFamEdit.AnnualIncome = kMyReader.GetValue(3).ToString(); }
                    if (!kMyReader.IsDBNull(4)) { stdFamEdit.Hphone = kMyReader.GetString(4); }
                    if (!kMyReader.IsDBNull(5)) { stdFamEdit.StdGenCategory = kMyReader.GetString(5); }
                    if (!kMyReader.IsDBNull(6)) { stdFamEdit.Aadhar = kMyReader.GetString(6); }
                    if (!kMyReader.IsDBNull(7)) { stdFamEdit.OccupationF = kMyReader.GetString(7); }
                    if (!kMyReader.IsDBNull(8)) { stdFamEdit.QualificationF = kMyReader.GetString(8); }
                    if (!kMyReader.IsDBNull(9)) { stdFamEdit.ParentsNamesM = kMyReader.GetString(9); }
                    if (!kMyReader.IsDBNull(10)) { stdFamEdit.OccupationM = kMyReader.GetString(10); }
                    if (!kMyReader.IsDBNull(11)) { stdFamEdit.QualificationM = kMyReader.GetString(11); }
                }
                conn.Close();
                return stdFamEdit;

            }
        }

        public static async Task<Students> SaveEditFamilyAsync(SchContext _context, Students Stds)
        {
            try
            {
                string MySql;
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE Students SET ";
                    MySql = MySql + " ParentsNamesF = '" + Stds.ParentsNamesF + "',";
                    MySql = MySql + " AnnualIncome = '" + Stds.AnnualIncome + "',";
                    MySql = MySql + " HPhone = '" + Stds.Hphone + "',";
                    MySql = MySql + " StdGenCategory = '" + Stds.StdGenCategory + "',";
                    MySql = MySql + " Aadhar = '" + Stds.Aadhar + "',";
                    //OccupationF, QualificationF, ParentsNamesM, OccupationM, QualificationM
                    MySql = MySql + " OccupationF = '" + Stds.OccupationF + "',";
                    MySql = MySql + " QualificationF = '" + Stds.QualificationF + "',";
                    MySql = MySql + " ParentsNamesM = '" + Stds.ParentsNamesM + "',";
                    MySql = MySql + " OccupationM = '" + Stds.OccupationM + "',";
                    MySql = MySql + " QualificationM = '" + Stds.QualificationM + "'";
                    MySql = MySql + " WHERE StdSession ='" + repSplChr(Stds.StdSession) + "'";
                    MySql = MySql + " AND DBID =  " + Stds.DBid;
                    //MySql = MySql + " AND UniReg =" + Stds.UniReg;
                    MySql = MySql + " AND RegNumber =" + Stds.RegNumber;
                    MySql = MySql + " AND Dormant = 0 ";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return Stds;
            //return new OkObjectResult(Stds);
        }

        public static async Task<Students> getStdHealthEdit(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            Students stdHealthEdit = new Students
            {
                RegNumber = regNum,
                StdSession = dSess,
                DBid = mdBId
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT UniReg, FirstName, Notes, PermAilment, BloodGroup, Height, ";
                MySql = MySql + "  Weight, Teeth, VisionL, VisionR, OralHygiene, SplAilment, PermIdentification";
                MySql = MySql + " FROM  Students";
                MySql = MySql + " WHERE dBID = " + mdBId;
                MySql = MySql + " AND  StdStatus = 0";
                MySql = MySql + " AND  Dormant = 0";
                MySql = MySql + " AND StdSession = '" + dSess + "'";
                MySql = MySql + " AND   RegNumber = " + regNum;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { stdHealthEdit.UniReg = kMyReader.GetInt32(0); }
                    if (!kMyReader.IsDBNull(1)) { stdHealthEdit.StdName = kMyReader.GetString(1); }
                    if (!kMyReader.IsDBNull(2)) { stdHealthEdit.Notes = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { stdHealthEdit.PermAilment = kMyReader.GetString(3); }
                    if (!kMyReader.IsDBNull(4)) { stdHealthEdit.BloodGroup = kMyReader.GetString(4); }
                    if (!kMyReader.IsDBNull(5)) { stdHealthEdit.Height = kMyReader.GetString(5); }
                    if (!kMyReader.IsDBNull(6)) { stdHealthEdit.Weight = kMyReader.GetValue(6).ToString(); }
                    if (!kMyReader.IsDBNull(7)) { stdHealthEdit.Teeth = kMyReader.GetString(7); }
                    if (!kMyReader.IsDBNull(8)) { stdHealthEdit.VisionL = kMyReader.GetString(8); }
                    if (!kMyReader.IsDBNull(9)) { stdHealthEdit.VisionR = kMyReader.GetString(9); }
                    if (!kMyReader.IsDBNull(10)) { stdHealthEdit.OralHygiene = kMyReader.GetString(10); }
                    if (!kMyReader.IsDBNull(11)) { stdHealthEdit.SplAilment = kMyReader.GetString(11); }
                    if (!kMyReader.IsDBNull(12)) { stdHealthEdit.PermIdentification = kMyReader.GetString(12); }
                }
            }
            conn.Close();
            return stdHealthEdit;

        }

        public static async Task<Students> SaveEditHealthAsync(SchContext _context, Students Stds)
        {
            try
            {
                string MySql;
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE Students SET ";
                    MySql = MySql + " Notes = '" + Stds.Notes + "',";
                    MySql = MySql + " PermAilment = '" + Stds.PermAilment + "',";
                    MySql = MySql + " BloodGroup = '" + Stds.BloodGroup + "',";
                    MySql = MySql + " Height = '" + Stds.Height + "',";
                    MySql = MySql + " Weight = '" + Stds.Weight + "',";
                    MySql = MySql + " Teeth = '" + Stds.Teeth + "',";
                    MySql = MySql + " VisionL = '" + Stds.VisionL + "',";
                    MySql = MySql + " VisionR = '" + Stds.VisionR + "',";
                    MySql = MySql + " OralHygiene = '" + Stds.OralHygiene + "',";
                    MySql = MySql + " SplAilment = '" + Stds.SplAilment + "',";
                    MySql = MySql + " PermIdentification = '" + Stds.PermIdentification + "'";
                    MySql = MySql + " WHERE StdSession ='" + repSplChr(Stds.StdSession) + "'";
                    MySql = MySql + " AND DBID =  " + Stds.DBid;
                    //MySql = MySql + " AND UniReg =" + Stds.UniReg;
                    MySql = MySql + " AND RegNumber =" + Stds.RegNumber;
                    MySql = MySql + " AND Dormant = 0 ";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return Stds;
        }

        public static async Task<IEnumerable<FeeSumm>> getFeeSumm(SchContext _context, int regNum, string dSess, int mdBId)
        {
            string MySql;
            DateTime SessionStartDate = DateTime.Now;
            DateTime SessionEndDate = DateTime.Now;
            Boolean PayOnce = true;

            FeeForm feeForm = await getStdDetails(_context, regNum, dSess, mdBId);
            List<FeeSumm> stdFeeList = new List<FeeSumm>();

            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT SessionStartDate, SessionEndDate From AcaSession WITH (NOLOCK) ";
                MySql = MySql + " WHERE SessionName = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND Dormant =0";
                MySql = MySql + " AND dBID = " + mdBId;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    if (!kMyReader.IsDBNull(0)) { SessionStartDate = GloFunc.FromOADate(kMyReader.GetDouble(0)); }
                    if (!kMyReader.IsDBNull(1)) { SessionEndDate = GloFunc.FromOADate(kMyReader.GetDouble(1)); }
                }
                kMyReader.Close();

                MySql = " SELECT DISTINCT ForMonth From DynaFee WITH (NOLOCK)";
                MySql = MySql + " WHERE ForMonth >= " + GloFunc.ToOADate(SessionStartDate);
                MySql = MySql + " AND ForMonth <= " + GloFunc.ToOADate(SessionEndDate);
                MySql = MySql + " AND StdCategory ='" + repSplChr(feeForm.StdCat) + "'";
                MySql = MySql + " AND SessionName = '" + repSplChr(dSess) + "'";
                MySql = MySql + " AND ForClass = '" + repSplChr(feeForm.Clss) + "'";
                MySql = MySql + " AND Dormant = 0 ";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " ORDER BY ForMonth";
                command.CommandText = MySql;
                kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        FeeSumm feeSumm = new FeeSumm();
                        if (!kMyReader.IsDBNull(0)) { feeSumm.ForMonth = kMyReader.GetInt32(0); }
                        stdFeeList.Add(feeSumm);
                    }
                }
                kMyReader.Close();

                for (int i = 0; i < stdFeeList.Count; i++)
                {
                    MySql = " SELECT FeeCaption, PayByDate ";
                    MySql = MySql + " From DynaFee WITH (NOLOCK)  ";
                    MySql = MySql + " WHERE ForClass='" + repSplChr(feeForm.Clss) + "'";
                    MySql = MySql + " AND ForMonth =" + stdFeeList[i].ForMonth;//+ DGVFee.Columns(J + 2).Name
                    MySql = MySql + " AND SessionName='" + repSplChr(dSess) + "'";
                    MySql = MySql + " AND StdCategory='" + repSplChr(feeForm.StdCat) + "'";
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + mdBId;
                    command.CommandText = MySql;
                    kMyReader = await command.ExecuteReaderAsync();
                    if (kMyReader.HasRows)
                    {
                        kMyReader.Read();
                        if (!kMyReader.IsDBNull(0)) { stdFeeList[i].FeeCaption = kMyReader.GetString(0); }
                        if (!kMyReader.IsDBNull(1)) { stdFeeList[i].PayDate = GloFunc.FromOADate(kMyReader.GetDouble(1)); }
                    }
                    kMyReader.Close();

                    MySql = " SELECT Sum(Amount)  ";
                    MySql = MySql + " From DynaFee WITH (NOLOCK)  ";
                    MySql = MySql + " WHERE ForClass='" + repSplChr(feeForm.Clss) + "'";
                    MySql = MySql + " AND ForMonth =" + stdFeeList[i].ForMonth;
                    MySql = MySql + " AND SessionName='" + repSplChr(dSess) + "'";
                    MySql = MySql + " AND StdCategory='" + repSplChr(feeForm.StdCat) + "'";
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + mdBId;
                    command.CommandText = MySql;
                    kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        kMyReader.Read();
                        if (!kMyReader.IsDBNull(0)) { stdFeeList[i].Amount = kMyReader.GetDouble(0); }
                    }
                    kMyReader.Close();

                    MySql = " Select AmountPaid, ReceiptNo, ReceiptDate, PaidAt From Receipt WITH (NOLOCK) ";
                    MySql = MySql + " WHERE RegNo = " + regNum;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND IsDuesClearance = 0";
                    MySql = MySql + " AND ForPeriod = " + stdFeeList[i].ForMonth;
                    MySql = MySql + " AND AcaSession='" + repSplChr(dSess) + "'";
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + mdBId;
                    command.CommandText = MySql;
                    kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        kMyReader.Read();
                        stdFeeList[i].IsPaid = "<a onclick = \"clkPaid(this)\" href = #>Paid</a>";
                        if (!kMyReader.IsDBNull(0)) { stdFeeList[i].Remarks = "Amnt:" + kMyReader.GetDouble(0).ToString(); }
                        if (!kMyReader.IsDBNull(1))
                        {
                            stdFeeList[i].ReceiptNo = kMyReader.GetInt32(1).ToString();
                            stdFeeList[i].Remarks = stdFeeList[i].Remarks + ", Rec #:" + kMyReader.GetInt32(1).ToString();
                        }
                        if (!kMyReader.IsDBNull(2)) { stdFeeList[i].Remarks = stdFeeList[i].Remarks + ", Rec Date:" + GloFunc.FromOADate(kMyReader.GetDouble(2)).ToShortDateString(); }
                        if (!kMyReader.IsDBNull(3)) { stdFeeList[i].Remarks = stdFeeList[i].Remarks + ", PaidAt:" + kMyReader.GetString(3); }
                    }
                    else
                    {
                        if (PayOnce)
                        {
                            stdFeeList[i].IsPaid = "<a onclick = \"clkPay(this)\" href = #>Pay</a>";
                            PayOnce = false;
                        }
                    }
                    kMyReader.Close();
                    stdFeeList[i].DueOn = GloFunc.FromOADate(stdFeeList[i].ForMonth);
                }

                conn.Close();
            }

            return stdFeeList;
        }

        public static async Task<Boolean> IsFeePaidForPrevMonth(SchContext _context, int RegNum, int ForPeriod, string dSess, int mdBId)
        {
            string MySql = "";
            Boolean retBool = false;
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                MySql = "SELECT ReceiptNo ";
                MySql = MySql + " FROM Receipt  WITH (NOLOCK) ";
                MySql = MySql + " WHERE RegNo = " + RegNum;
                MySql = MySql + " AND ForPeriod <= " + ForPeriod;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND AcaSession = '" + dSess + "'";
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                //return !kMyReader.HasRows
                if (kMyReader.HasRows)
                {
                    retBool = false;
                }
                else
                {
                    retBool = true;
                }
                kMyReader.Close();
            }
            return retBool;
        }

        public static async Task<Receipt> getFeeDetail(SchContext _context, Receipt recX, string dSess, int mdBId)
        {
            string MySql = "";
            int jSl = 0;
            try
            {
                var conn = _context.Database.GetDbConnection();
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    MySql = "Select Caption, Amount, ForMonth From DynaFee WITH (NOLOCK)  ";
                    MySql = MySql + " WHERE ForMonth = " + (int)(recX.ForPeriod);
                    MySql = MySql + " AND ForClass = '" + recX.Clss + "'";
                    MySql = MySql + " AND StdCategory ='" + recX.StdCat + "'";
                    MySql = MySql + " AND SessionName ='" + dSess + "'";
                    MySql = MySql + " AND Dormant = 0 ";
                    MySql = MySql + " AND dBID = " + mdBId;
                    MySql = MySql + " ORDER BY FeeNo,Caption,ForMonth";
                    command.CommandText = MySql;
                    DbDataReader kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            ReceiptDetails receiptDetails = new ReceiptDetails();
                            receiptDetails.SlNo = jSl + 1;
                            receiptDetails.RecId = jSl + 1;
                            if (!kMyReader.IsDBNull(0)) { receiptDetails.FeenWahead = kMyReader.GetString(0); }
                            if (!kMyReader.IsDBNull(1)) { receiptDetails.AmountPaid = kMyReader.GetDouble(1); }
                            if (!kMyReader.IsDBNull(2)) { receiptDetails.ForPeriod = GloFunc.FromOADate(kMyReader.GetInt32(2)); }
                            recX.RecDetails.Add(receiptDetails);
                            jSl = jSl + 1;
                        }
                    }
                    kMyReader.Close();

                    MySql = " SELECT  Caption, Amount, ForMonth FROM StdFee WITH (NOLOCK) ";
                    MySql = MySql + " WHERE RegNo  = " + recX.RegNo;
                    MySql = MySql + " AND ForMonth = " + (int)(recX.ForPeriod);
                    MySql = MySql + " And dBID = " + mdBId;
                    MySql = MySql + " AND Dormant=0 ";
                    MySql = MySql + " ORDER BY FeeNo,Caption,ForMonth";
                    command.CommandText = MySql;
                    kMyReader = command.ExecuteReader();
                    if (kMyReader.HasRows)
                    {
                        while (kMyReader.Read())
                        {
                            ReceiptDetails receiptDetails = new ReceiptDetails();
                            receiptDetails.SlNo = jSl + 1;
                            receiptDetails.RecId = jSl + 1;
                            if (!kMyReader.IsDBNull(0)) { receiptDetails.FeenWahead = kMyReader.GetString(0); }
                            if (!kMyReader.IsDBNull(1)) { receiptDetails.AmountPaid = kMyReader.GetDouble(1); }
                            if (!kMyReader.IsDBNull(2)) { receiptDetails.ForPeriod = GloFunc.FromOADate(kMyReader.GetDouble(2)); }
                            recX.RecDetails.Add(receiptDetails);
                            jSl = jSl + 1;
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            //ReceiptDetails receiptDet = new ReceiptDetails();
            //receiptDet.FeenWahead = "Convenience Charge";
            //receiptDet.AmountPaid = 30;
            //receiptDet.ForPeriod = GloFunc.FromOADate(recX.ForPeriod);
            //recX.RecDetails.Add(receiptDet);
            for (int jI = 0; jI < recX.RecDetails.Count; jI++)
            {
                recX.AmountPaid += recX.RecDetails[jI].AmountPaid;
            }
            recX.AmountPaid = recX.AmountPaid;
            recX.AmountPayable = recX.AmountPaid;
            return recX;
        }

    }
}

