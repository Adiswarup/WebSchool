using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Marx
{
    public partial class TrMgDel
    {
        public int MkTrId { get; set; }
        public int? MkId { get; set; }
        public string Mclss { get; set; }
        public string SubName { get; set; }
        public string ExamName { get; set; }
        public double? ThMarks { get; set; }
        public double? PracMarks { get; set; }
        public double? OrMarks { get; set; }
        public double? AsgnMarks { get; set; }
        public double? TotalMarks { get; set; }
        public double? TotalMarksCalc { get; set; }
        public string Grades { get; set; }
        public int? RegNum { get; set; }
        public string Msession { get; set; }
        public string StdGrades { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public string TrMg { get; set; }
    }
}
