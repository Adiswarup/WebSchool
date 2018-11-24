using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Sl.No.")]
        public int Sn { get; set; }
        [DisplayName("Fee No.")]
        public int FeeNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        [DisplayName("Fee Month")]
        public int ForMonth { get; set; }
        [DisplayName("Fee Caption")]
        public string Caption { get; set; }
        [DisplayName("Receipt No.")]
        public string ReceiptNo { get; set; }
        [DisplayName("Amount")]
        public double Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
        [DisplayName("Due On")]
        public DateTime DueOn { get; set; }
        [DisplayName("Payment Date")]
        public DateTime PayDate { get; set; }
        [DisplayName("Is Fee Paid")]
        public string IsPaid { get; set; }
        [DisplayName("Remarks")]
        public string Remarks { get; set; }
        [DisplayName("Fee Caption")]
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

