using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class Receipt
    {
        public int AutoId { get; set; }
        public int RecId { get; set; }
        public int? ReceiptNo { get; set; }
        public string BillNo { get; set; }
        public double? ReceiptDate { get; set; }
        public int? UniReg { get; set; }
        public int? RegNo { get; set; }
        public double? ForPeriod { get; set; }
        public double? AmountPayable { get; set; }
        public double? AmountPaid { get; set; }
        public int? IsDuesClearance { get; set; }
        public string PaymentMode { get; set; }
        public string BankName { get; set; }
        public string ChqDated { get; set; }
        public string ChqNumber { get; set; }
        public string Remarks { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
        public string PaidAt { get; set; }
        public string SName { get; set; }
        public string FeeHeading { get; set; }
        public string DelRemarks { get; set; }
        public string AcaSession { get; set; }
    }
}
