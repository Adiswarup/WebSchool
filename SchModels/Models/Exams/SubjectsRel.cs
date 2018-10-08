using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Exams
{
    public partial class SubjectsRel
    {
        public int AutoId { get; set; }
        public int SubRelId { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
        public string Clss { get; set; }
        public string SubSubName { get; set; }
        public string AcaSession { get; set; }
        public string ExamName { get; set; }
        public double MarksPro { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class SubjectsRelEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public SubjectsRel Value { get; set; }
    }
}
