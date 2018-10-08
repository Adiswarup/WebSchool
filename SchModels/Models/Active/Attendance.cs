using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Active
{
    public partial class Attendance
    {
        [Key]
        public int AutoId { get; set; }
        public int AttId { get; set; }
        public int UniReg { get; set; }
        public int RegNum { get; set; }
        public string Clss { get; set; }
        public string StdName { get; set; }
        public bool isAbsent { get; set; }
        public int clsRoll { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string AtType { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AttDate { get; set; }
        public string Cause { get; set; }
        public string Remark { get; set; }

        public string AcaSession { get; set; }
        public int Dormant { get; set; }
        public string LoginName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        public string CTerminal { get; set; }
        public int DBid { get; set; }
    }
    public partial class AttendanceEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Attendance Value { get; set; }
    }

}
