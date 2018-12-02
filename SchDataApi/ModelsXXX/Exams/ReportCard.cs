using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Exams
{
    public partial class ReportCard
    {
        public int AutoId { get; set; }
        public int RcId { get; set; }
        public string RcName { get; set; }
        public string RcValue { get; set; }
        public string RcSession { get; set; }
        public string RcClass { get; set; }
        public string RcExam { get; set; }
        public string RcType { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
