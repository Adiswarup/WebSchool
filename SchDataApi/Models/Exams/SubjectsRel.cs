using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Exams
{
    public partial class SubjectsRel
    {
        public int AutoId { get; set; }
        public int? SubRelId { get; set; }
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public string Clss { get; set; }
        public string SubSubName { get; set; }
        public string AcaSession { get; set; }
        public string ExamName { get; set; }
        public double? MarksPro { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
