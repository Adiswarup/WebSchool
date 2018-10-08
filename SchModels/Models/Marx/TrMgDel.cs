using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Marx
{
    public partial class TrMgDel
    {
        public int MkTrId { get; set; }
        public int MkId { get; set; }
        public string Mclss { get; set; }
        public string SubName { get; set; }
        public string ExamName { get; set; }
        public double ThMarks { get; set; }
        public double PracMarks { get; set; }
        public double OrMarks { get; set; }
        public double AsgnMarks { get; set; }
        public double TotalMarks { get; set; }
        public double TotalMarksCalc { get; set; }
        public string Grades { get; set; }
        public string TrMg { get; set; }
        public int RegNum { get; set; }
        public string Msession { get; set; }
        public string StdGrades { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
    }
    public partial class TrMgDelEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public TrMgDel Value { get; set; }
    }
}
