using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace SchMod.ViewModels.StdFees
{
    public class FeeSumm
    {
        public FeeSumm()
        {
            FeeId = 0;
            Sn = 0;
            FeeNo = 0;
            ForMonth = 0;
            Caption = "-";
            ReceiptNo = "-";
            Amount = 100;
            DueDate = DateTime.Now;
            PayDate = DateTime.Now;
            IsPaid = "";
            Remarks = "";
        }

        [Key]
        public int FeeId { get; set; }
        public int Sn { get; set; }
        public int FeeNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public int ForMonth { get; set; }
        public string Caption { get; set; }
        public string ReceiptNo { get; set; }
        public double Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { get; set; }
        public DateTime DueOn { get; set; }
        public DateTime PayDate { get; set; }
        public string IsPaid { get; set; }
        public string Remarks { get; set; }
        public string FeeCaption { get; set; }


        //[ScaffoldColumn(false)]
        //public int Dormant { get; set; }
        //[ScaffoldColumn(false)]
        //public string LoginName { get; set; }
        //[ScaffoldColumn(false)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime ModTime { get; set; }
        //[ScaffoldColumn(false)]
        //public string CTerminal { get; set; }
        //[ScaffoldColumn(false)]
        //public int DBid { get; set; }


    }
    public partial class FeeSummEdit
    {
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public FeeSumm Value { get; set; }
    }

}

