using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Active
{
    public class Profile_Activity
    {
        public Profile_Activity()
        {
            this.AutoId = 0;
            this.ActivityId = 0;
            this.ActGroupID = 0;
            this.ActDate =   DateTime.Now;
            this.Activity = "";
            this.ActGroup = "";
            this.ActRemarks = "";
            this.LoggedBy = "";
        }
        [Key]
        public int AutoId { get; set; }
        public int ActivityId { get; set; }
        [DisplayName("Activity")]
        public string Activity { get; set; }
        public int ActGroupID { get; set; }
        public string ActGroup { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActDate { get; set; }
        public int TeachId { get; set; }
        [DisplayName("Remarks")]
        public string ActRemarks { get; set; }
        public string LoggedBy { get; set; }
    }
}
