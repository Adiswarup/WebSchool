using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Exams
{
    public partial class ExamSub
    {
        public int ExamSubAutoId { get; set; }
        public int ExamSubId { get; set; }
        public string ExamName { get; set; }
        public string Clss { get; set; }
        public string Ssession { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
        public int UseInExamTotal { get; set; }
        public int SubType { get; set; }
        public int IsElective { get; set; }
        public double FullMarks { get; set; }
        public double PassMarks { get; set; }
        public int IsTheory { get; set; }
        public double Fmtheory { get; set; }
        public double Pmtheory { get; set; }
        public int IsOral { get; set; }
        public double Fmoral { get; set; }
        public double Pmoral { get; set; }
        public int IsPract { get; set; }
        public double Fmpract { get; set; }
        public double Pmpract { get; set; }
        public int IsAssign { get; set; }
        public double Fmassign { get; set; }
        public double Pmassign { get; set; }
        public double Factor { get; set; }
        public double DoevalutionTo { get; set; }
        public double DoevalutionFrom { get; set; }
        public int SubExamMarksDirty { get; set; }
        public int SubExamMarksLocked { get; set; }

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
    public partial class ExamSubEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ExamSub Value { get; set; }
    }
}
