using System;
using System.Text.RegularExpressions;

namespace WebCat7.GenFunction
{
    public static class GloFunc
    {
        public static DateTime FromOADate(this double dNum)
        {
            dNum = Math.Floor(dNum);
            return new DateTime(1900, 1, 1).AddDays(dNum - 2);
        }

        public static Double ToOADate(this DateTime dDate)
        {
            DateTime ODate = new DateTime(1900, 1, 1);
            return (dDate - ODate).Days + 2;
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

        public static string repSplXMLChr(string strInput)
        {

            strInput = strInput.Replace("&", "&amp;");
            strInput = strInput.Replace("'", "&apos;");
            //strInput = strInput.Replace(Char(34), "&quot;");
            strInput = strInput.Replace("<", "&lt;");
            strInput = strInput.Replace(">", "&gt;");
                 return strInput; 
        }

        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

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
