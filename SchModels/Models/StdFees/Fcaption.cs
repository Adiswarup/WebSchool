using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.StdFees
{
    public partial class Fcaption
    {
        public Fcaption()
        {
            AutoId = 0;
            DBid = 0;
            FeeNameId = 0;
            FeeCaption = "";
            FeeDuration = "Monthly";
            ShowIt = true;
            LoginName = "";
        }
        public int AutoId { get; set; }
        [Key]
        public int FeeNameId { get; set; }
        [Display(Name = "Fee Name/Caption")]
        public string FeeCaption { get; set; }
        [Display(Name = "Periodicity")]
        public string FeeDuration { get; set; }
        [Display(Name = "Fee Type")]
        public string FeeType { get; set; }
        public int FeeOrder { get; set; }
        [Display(Name ="Seen in Fee Scheduling")]
        public Boolean ShowIt { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class FcaptionEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Fcaption Value { get; set; }
    }
}
