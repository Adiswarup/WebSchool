using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Exams
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

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class ReportCardEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ReportCard Value { get; set; }
    }
}
