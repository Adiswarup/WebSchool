using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SchMod.StClass;

namespace SchMod.Models.Active
{
    [Table("Activity")]
    public partial class Activity
    {
        public Activity()
        {
            AutoId = 0;
            ActivityId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }
        public int AutoId { get; set; }
        [Key]
        public int ActivityId { get; set; }
        [StringLength(255)]
        public string ActivityName { get; set; }
        public double ActivityValue { get; set; }
        public string ActivityGroup { get; set; }
        public int ActGroupId { get; set; }
        public string ActivityRemarks { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActivityDate { get; set; }
        public bool SendSms { get; set; }
        public bool SendEmail { get; set; }
        public string LoginName { get; set; }
        public int Dormant { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        public string CTerminal { get; set; }
        public int DBid { get; set; }
           public string ActSession { get; set; }
 }
    public partial class ActivityEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Activity Value { get; set; }
    }

}
