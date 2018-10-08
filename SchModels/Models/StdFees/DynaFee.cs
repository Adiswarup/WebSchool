using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.StdFees
{
    public partial class DynaFee
    {
        public DynaFee()
        {
            FeeNo = 0;
            Caption = "";
            ForMonth = DateTime.Now;
            Amount = 0;
            FeeCaption = "";
            ForClass = "";
            StdCategory = "";
            SessionName = "";
        }
        public int AutoId { get; set; }
        [Key]
        public int ClsFeeId { get; set; }
        [DisplayName("Fee No.")]
        public int FeeNo { get; set; }
        [DisplayName("Fee Caption/Head")]
        public string Caption { get; set; }
        [DisplayName("Fee Date")]
        public DateTime ForMonth { get; set; }
        [DisplayName("Amount")]
        public double Amount { get; set; }
        [DisplayName("Fee Name")]
        public string FeeCaption { get; set; }
        [DisplayName("Fee Due Date")]
        public DateTime PayByDate { get; set; }
        [DisplayName("Class")]
        public string ForClass { get; set; }
        [DisplayName("Category")]
        public string StdCategory { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueOn { get; set; }
        [DisplayName("Session")]
        public string SessionName { get; set; }


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
    public partial class DynaFeeEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public DynaFee Value { get; set; }
    }
}
