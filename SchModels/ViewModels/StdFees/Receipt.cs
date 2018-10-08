using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.ViewModels.StdFees
{
    public partial class Receipt
    {
        public int AutoId { get; set; }
        public int RecId { get; set; }
        public int ReceiptNo { get; set; }
        public string BillNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReceiptDate { get; set; }
        public int UniReg { get; set; }
        public int RegNo { get; set; }
        public int RollNo { get; set; }
        public string StdName { get; set; }
        public string Gender { get; set; }
        public string Clss { get; set; }
        public double ForPeriod { get; set; }
        public double AmountPayable { get; set; }
        public double AmountPaid { get; set; }
        public int IsDuesClearance { get; set; }
        public string PaymentMode { get; set; }
        public string BankName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ChqDated { get; set; }
        public string ChqNumber { get; set; }
        public string Remarks { get; set; }
        public string PaidAt { get; set; }
        public string SName { get; set; }
        public string FeeHeading { get; set; }
        public string DelRemarks { get; set; }
        public string AcaSession { get; set; }
        public string StdCat { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
        public List<ReceiptDetails> RecDetails { get; set;  }
    }
    public partial class ReceiptEdit
    {
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Receipt Value { get; set; }
    }
}
