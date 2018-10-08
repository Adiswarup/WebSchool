using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class Subjects
    {
        public int SubAutoId { get; set; }
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public string SubCode { get; set; }
        public string Clss { get; set; }
        public int? ClsWeek { get; set; }
        public int? TutWeek { get; set; }
        public int? LabWeek { get; set; }
        public string PrefTeacher { get; set; }
        public int? TeachId { get; set; }
        public string StandByTeacher { get; set; }
        public string RoomLab { get; set; }
        public int? FullMarks { get; set; }
        public string Category { get; set; }
        public string PrefPeriod { get; set; }
        public string AcaSession { get; set; }
        public int? NLesson { get; set; }
        public int? NTutorials { get; set; }
        public int? NLaboratory { get; set; }
        public string SubjectExamName { get; set; }
        public int? SubType { get; set; }
        public int? FeatureInReport { get; set; }
        public int? AutoGrades { get; set; }
        public string GradeType { get; set; }
        public int? GradeOrMarks { get; set; }
        public int IsElective { get; set; }
        public int IsTheory { get; set; }
        public int IsPract { get; set; }
        public int IsAssign { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? SubSn { get; set; }
        public int? DBid { get; set; }
    }
}
