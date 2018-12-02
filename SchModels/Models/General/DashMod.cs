using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.General
{
    public class DashMod
    {
        public DashMod()
        {

        }
        [Key]
        public int AutoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DmDate { get; set; }

        public string TodaysFeeCollection { get; set; }
        public string TodayAbsentees { get; set; }
        public string AppNotes { get; set; }
        public string TotalFeesToday { get; set; }
        public int DBid { get; set; }
        public IEnumerable<DashActivity> DashActivities { get; set; }
        public IEnumerable<DashAttendance> DashAttendances { get; set; }
        public IEnumerable<DashFees> DashFeess { get; set; }
        public IEnumerable<DashAttClss> DashAttClss { get; set; }
    }

    public class DashActivity
    {
        public DashActivity()
        {

        }
        [Key]
        public int AutoId { get; set; }
        public string ActivityGroup { get; set; }
        public string Activity { get; set; }
        public int ActivityID { get; set; }
        public string Remark { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActDate { get; set; }
        public string Clss { get; set; }
        public string Roll { get; set; }
        public string RegNum { get; set; }
        public string Name { get; set; }
        public string LoggedBY { get; set; }
        public int DBid { get; set; }
    }

    public class DashAttendance
    {
        [Key]
        public int AutoId { get; set; }
        public string Clss { get; set; }
        public string Roll { get; set; }
        public string RegNum { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AttDate { get; set; }
        public string AtType { get; set; }
        public string Cause { get; set; }
        public string Remarks { get; set; }
        public int DBid { get; set; }
    }

    public class DashFees
    {
        public DashFees()
        {

        }
        [Key]
        public int AutoId { get; set; }
        public string RegNum { get; set; }
        public string Name { get; set; }
        public string Clss { get; set; }
        public string FeeName { get; set; }
        //[DataType("Currency")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FeeDate { get; set; }
        public int DBid { get; set; }
    }

    public class DashAttClss
    {
        [Key]
        public int AutoId { get; set; }
        public int AttCId { get; set; }

        public string Cclss { get; set; }
        public int Ccount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AttDate { get; set; }
    }

}
