using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.General
{
    public partial class LeaveDefinition
    {
        public int AutoId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public bool IsPaidLeave { get; set; }
        public bool CanbeCarriedOn { get; set; }
        public int CarryoverLimit { get; set; }
        public int IsSchLeave { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateStamp { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public byte[] UpsizeTs { get; set; }
    }
    public partial class LeaveDefinitionEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public LeaveDefinition Value { get; set; }
    }
}
