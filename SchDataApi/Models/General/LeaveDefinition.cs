using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class LeaveDefinition
    {
        public int AutoId { get; set; }
        public int? LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public bool IsPaidLeave { get; set; }
        public bool CanbeCarriedOn { get; set; }
        public int? CarryoverLimit { get; set; }
        public int? IsSchLeave { get; set; }
        public string LoginName { get; set; }
        public double? DateStamp { get; set; }
        public int? Dormant { get; set; }
        public string CTerminal { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
}
