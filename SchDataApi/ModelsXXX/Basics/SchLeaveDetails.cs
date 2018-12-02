using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class SchLeaveDetails
    {
        public int AutoId { get; set; }
        public int? BranchId { get; set; }
        public int? SchLeaveId { get; set; }
        public string SchLeaveType { get; set; }
        public double? SchLeaveDate { get; set; }
        public string LoginName { get; set; }
        public double? DateStamp { get; set; }
        public int? Dormant { get; set; }
        public string CTerminal { get; set; }
    }
}
