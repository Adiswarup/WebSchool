using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Active
{
    public partial class ActivityGrades
    {
        public int AutoId { get; set; }
        public int? ActivityGradeId { get; set; }
        public string ActivityGrName { get; set; }
        public int? RegNum { get; set; }
        public string ActClss { get; set; }
        public string ActExamName { get; set; }
        public double? StdActMarks { get; set; }
        public string StdActGrades { get; set; }
        public string ActSession { get; set; }
        public int? ActGroupId { get; set; }
        public string DesIndicators { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public byte[] UpsizeTs { get; set; }
        public int? UniReg { get; set; }
        public string CdesIndicators { get; set; }
        public string CstdActGrades { get; set; }
        public int? ChangeType { get; set; }
        public int? DBid { get; set; }
    }
}
