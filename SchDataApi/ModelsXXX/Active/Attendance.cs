using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Active
{
    public partial class Attendance
    {
        public int AutoId { get; set; }
        public int? AttId { get; set; }
        public int? UniReg { get; set; }
        public int? RegNum { get; set; }
        public string Clss { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public double? AttDate { get; set; }
        public string AcaSession { get; set; }
        public string Cause { get; set; }
        public string Remark { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
