using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SchMod.StClass;

namespace SchMod.Models.Active
{
    public class ActiLog
    {
        public ActiLog()
        {
            AutoId = 0;

            ActName = "";
            ActVal = false;
            ActVis = false;
            ActName1 = "";
            ActVal1 = false;
            ActVis1 = false;
            ActName2 = "";
            ActVal2 = false;
            ActVis2 = false;
            //ActName3 = "";
            //ActVal3 = false;
            //ActVis3 = false;
            //ActName4 = "";
            //ActVal4 = false;
            //ActVis4 = false;
            //ActName5 = "";
            //ActVal5 = false;
            //ActVis5 = false;
            //ActName6 = "";
            //ActVal6 = false;
            //ActVis6 = false;
            //ActName7 = "";
            //ActVal7 = false;
            //ActVis7 = false;
            //ActName8 = "";
            //ActVal8 = false;
            //ActVis8 = false;
            //ActName9 = "";
            //ActVal9 = false;
            //ActVis9 = false;
            //ActName10 = "";
            //ActVal10 = false;
            //ActVis10 = false;


            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

        [Key]
        public int AutoId { get; set; }
        public string Clss { get; set; }
        public string ActGroup { get; set; }

        public int StdID { get; set; }
        public string StdName { get; set; }

        public string ActName { get; set; }
        public bool ActVal { get; set; }
        public bool ActVis { get; set; }
        public string ActName1 { get; set; }
        public bool ActVal1 { get; set; }
        public bool ActVis1 { get; set; }
        public string ActName2 { get; set; }
        public bool ActVal2 { get; set; }
        public bool ActVis2 { get; set; }
        //public string ActName3 { get; set; }
        //public bool ActVal3 { get; set; }
        //public bool ActVis3 { get; set; }
        //public string ActName4 { get; set; }
        //public bool ActVal4 { get; set; }
        //public bool ActVis4 { get; set; }
        //public string ActName5 { get; set; }
        //public bool ActVal5 { get; set; }
        //public bool ActVis5 { get; set; }
        //public string ActName6 { get; set; }
        //public bool ActVal6 { get; set; }
        //public bool ActVis6 { get; set; }
        //public string ActName7 { get; set; }
        //public bool ActVal7 { get; set; }
        //public bool ActVis7 { get; set; }
        //public string ActName8 { get; set; }
        //public bool ActVal8 { get; set; }
        //public bool ActVis8 { get; set; }
        //public string ActName9 { get; set; }
        //public bool ActVal9 { get; set; }
        //public bool ActVis9 { get; set; }
        //public string ActName10 { get; set; }
        //public bool ActVal10 { get; set; }
        //public bool ActVis10 { get; set; }

        public string LoginName { get; set; }
        public int Dormant { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        public string CTerminal { get; set; }
        public int DBid { get; set; }
        public string ActSession { get; set; }

    }

    public partial class ActiLogEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ActiLog Value { get; set; }
    }

}
