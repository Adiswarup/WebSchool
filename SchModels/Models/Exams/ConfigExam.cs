using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Exams
{
    public partial class ConfigExam
    {
        public int AutoId { get; set; }
        public int ConExamId { get; set; }
        public string Ssession { get; set; }
        public string Clss { get; set; }
        public string ExamFor { get; set; }
        public string ExamFrom { get; set; }
        public string Subj { get; set; }
        public double MarksPc { get; set; }
        public string MarksType { get; set; }

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
    public partial class ConfigExamEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ConfigExam Value { get; set; }
    }
}
