using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class Subjects
    {
        public Subjects()
        {
            SubAutoId = 0;
            SubId = 0;
            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }
        public int SubAutoId { get; set; }
        [Key]
        public int SubId { get; set; }
        [DisplayName("Subject")]
        public string SubName { get; set; }
        [DisplayName("Subject Code")]
        public string SubCode { get; set; }
        [DisplayName("Class")]
        public string Clss { get; set; }
        public int ClsWeek { get; set; }
        public int TutWeek { get; set; }
        public int LabWeek { get; set; }
        [DisplayName("Subject Teacher")]
        public string classTeacher { get; set; }
        public int TeachId { get; set; }
        public string StandByTeacher { get; set; }
        public string RoomLab { get; set; }
        public int FullMarks { get; set; }
        public string Category { get; set; }
        public string PrefPeriod { get; set; }
        public string AcaSession { get; set; }
        public int NLesson { get; set; }
        public int NTutorials { get; set; }
        public int NLaboratory { get; set; }
        [DisplayName("Subject As Featured in Report")]
        public string SubjectExamName { get; set; }
        [DisplayName("Subject Type")]
        public int SubType { get; set; }
        [DisplayName("Shown in Report Card")]
        public Boolean FeatureInReport { get; set; }
        public Boolean AutoGrades { get; set; }
        [DisplayName("Grade Type")]
        public string GradeType { get; set; }
        [DisplayName("Grade or Marks")]
        public Boolean GradeOrMarks { get; set; }
        [DisplayName("Is Elective")]
        public Boolean IsElective { get; set; }
        [DisplayName("Has Theory")]
        public Boolean IsTheory { get; set; }
        [DisplayName("Has Practical")]
        public Boolean IsPract { get; set; }
        [DisplayName("Has Assignment")]
        public Boolean IsAssign { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        public int SubSn { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }

    public partial class SubjectsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Subjects Value { get; set; }
    }
}
