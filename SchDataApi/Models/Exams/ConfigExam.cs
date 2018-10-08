using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Exams
{
    public partial class ConfigExam
    {
        public int AutoId { get; set; }
        public int? ConExamId { get; set; }
        public string Ssession { get; set; }
        public string Clss { get; set; }
        public string ExamFor { get; set; }
        public string ExamFrom { get; set; }
        public string Subj { get; set; }
        public double? MarksPc { get; set; }
        public string MarksType { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
