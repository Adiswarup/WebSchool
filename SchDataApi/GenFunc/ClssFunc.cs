using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloFunc;

namespace SchDataApi.GenFunc
{
    public class ClssFunc
    {
        //Home ClassList2ColAsync
        public async Task<string> ClassList(SchContext _context, string MyStdClass, string stdStatus, string dSess)
        {
            string tmpStr = "";
            string tempStr = "";
            string MySql = "";
            string MyXML = "";
            int rj = 0;
            string[] strXml = new string[100];

            MyXML = "<?xml version='1.0' encoding='UTF-8'?>";
            MyXML = MyXML + "<?xml-stylesheet type='text/xsl' href='../Templates/BlankMarksSheet.xsl'?>";
            MyXML = MyXML + "<Marks>";
            MyXML = MyXML + "<School>"  + "</School>"; //+ repSplChrXml(MySchoolName)
            MyXML = MyXML + "<SchoolAdd>"  + "</SchoolAdd>"; //+ repSplChrXml(MySchoolAddress)
            MyXML = MyXML + "<StdClass>" + repSplChrXml(MyStdClass) + "</StdClass>";
            MyXML = MyXML + "<StdSession>" +  "</StdSession>"; //repSplChrXml(MyCurrentSession) +

            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                //if sender.ToString = "Attendance Register" Then
                //    mNum = InputBox("Input Month No. Like " + Now.Month + 1 + " for " + MonthName(Now.Month + 1), "For the Month of...", Now.Month + 1)
                //    if mNum < 1 Or mNum > 12 Then
                //        MyXML = MyXML  + "<ForMonth></ForMonth>" 
                //    Else
                //        MyXML = MyXML  + "<ForMonth>" + MonthName(mNum) + "</ForMonth>" 
                //    End if
                //End if

                MySql = "Select RegNumber, FirstName, MiddleName, LastName, PresentRollNo";
                MySql = MySql + " FROM Students WITH (NOLOCK) ";
                MySql = MySql + " WHERE  StdSession ='" + repSplChr(dSess) + "'";
                switch (stdStatus)
                {
                    case "Present":
                        MySql = MySql + " AND  StdStatus <= 0";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Ex-Student":
                        MySql = MySql + " AND  StdStatus = 1";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Promoted":
                        MySql = MySql + " AND  StdStatus = 2";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Conditional Promoted":
                        MySql = MySql + " AND  StdStatus = 3";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Section Transferred":
                        MySql = MySql + " AND  StdStatus = 4";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Failed":
                        MySql = MySql + " AND  StdStatus = 5";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Detained":
                        MySql = MySql + " AND  StdStatus = 6";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Rollback":
                        MySql = MySql + " AND  StdStatus = 7";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Struck Off":
                        MySql = MySql + " AND  StdStatus = 12";
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    case "Dormant":
                        MySql = MySql + " AND  StdStatus = 1";
                        break;
                    case "All":
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                    default:
                        MySql = MySql + " AND Dormant = 0 ";
                        break;
                }
                //'MySql = MySql + " AND StdSession ='" + RepSplChr(MyCurrentSession) + "'"
                MySql = MySql + " AND PresentClass  ='" + repSplChr(MyStdClass) + "'";
                MySql = MySql + " Order By PresentRollNo";
                command.CommandText = MySql;
                DbDataReader MyReader = await command.ExecuteReaderAsync();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        rj = rj + 1;
                        if (rj <= 40)
                        {
                            tmpStr = "";
                            if (!MyReader.IsDBNull(0)) { tempStr = "<RegNoL>" + MyReader.GetValue(0) + "</RegNoL>"; }
                            if (!MyReader.IsDBNull(1)) { tmpStr = MyReader.GetString(1); }
                            if (!MyReader.IsDBNull(2)) { tmpStr = tmpStr + " " + MyReader.GetString(2); }
                            if (!MyReader.IsDBNull(3))
                            {
                                tmpStr = tmpStr + " " + MyReader.GetString(3);
                                tempStr = tempStr + "<StdNameL>" + repSplChrXml(properName(tmpStr)) + "</StdNameL>";
                            }
                            if (!MyReader.IsDBNull(0)) { tempStr = tempStr + "<RollNoL>" + MyReader.GetValue(4) + "</RollNoL>"; }
                        }
                        else
                        {
                            tmpStr = "";
                            if (!MyReader.IsDBNull(0)) { tempStr = "<RegNoR>" + MyReader.GetValue(0) + "</RegNoR>"; }
                            if (!MyReader.IsDBNull(1)) { tmpStr = MyReader.GetString(1); }
                            if (!MyReader.IsDBNull(2)) { tmpStr = tmpStr + " " + MyReader.GetString(2); }
                            if (!MyReader.IsDBNull(3)) { tmpStr = tmpStr + " " + MyReader.GetString(3); }
                            tempStr = tempStr + "<StdNameR>" + repSplChrXml(properName(tmpStr)) + "</StdNameR>";
                        }
                        if (!MyReader.IsDBNull(0)) { tempStr = tempStr + "<RollNoR>" + MyReader.GetValue(4) + "</RollNoR>"; }
                    }
                    strXml[rj] = tempStr;
                }
            }
            for (int i = 1; i < 40; i++)
            {
                MyXML = MyXML + "<Student>";
                MyXML = MyXML + strXml[i];
                MyXML = MyXML + strXml[i + 40];
                MyXML = MyXML + "</Student>";
            }
            MyXML = MyXML + "</Marks>";
            return MyXML;
        }
    }
}

