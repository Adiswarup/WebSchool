using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Active
{
    public class Profile_Attendance
    {
        public Profile_Attendance()
        {

        }
        [Key]
        public int AutoId { get; set; }
        public int AttId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime AttDate { get; set; }
        [DisplayName("Reason")]
        public string AttReason { get; set; }
        public string AttRemarks { get; set; }
        public string AtType { get; set; }

    }
}
