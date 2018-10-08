using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class AcaSession
    {
        //public AcaSession
        public AcaSession()
        {
            AutoId = 0;
            Ssdid = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

        public int AutoId { get; set; }
        [Key]
        public int Ssdid { get; set; }
        [DisplayName("Session Name")]
        [Required]
        [MinLength(4)]
        public string SessionName { get; set; }
        [DisplayName("Session Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime SessionStartDate { get; set; }
        [DisplayName("Session End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime SessionEndDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime SessionStartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime SessionEndDate { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }

    public partial class AcaSessionEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public AcaSession Value { get; set; }
    }
}
