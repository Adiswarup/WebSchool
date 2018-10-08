using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Active
{
    public partial class ActivityGroup
    {
        public int AutoId { get; set; }
        public int? ActGroupId { get; set; }
        public string ActGroupName { get; set; }
        public int? IsReflectedInReportCard { get; set; }
        public string ActGroupReportCard { get; set; }
        public string ActGroupMotive { get; set; }
        public string ActCode { get; set; }
        public string GradeType { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public string Clss { get; set; }
        public int? ActSn { get; set; }
        public string ActClss { get; set; }
        public string ActSession { get; set; }
        public int? DBid { get; set; }
    }
}
