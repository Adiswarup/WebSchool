using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchDataApi.Models.Active
{
    [Table("Activity")]
    public partial class Activity
    {
        [Key]
        public int AutoId { get; set; }
        public int? ActivityId { get; set; }
        [StringLength(255)]
        public string ActivityName { get; set; }
        public double? ActivityValue { get; set; }
        public string ActivityGroup { get; set; }
        public int? ActGroupId { get; set; }
        public string ActivityRemarks { get; set; }
        public int? SendSms { get; set; }
        public int? SendEmail { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
