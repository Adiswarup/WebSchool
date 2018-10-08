using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class ChqDrafts
    {
        public int AutoId { get; set; }
        public int? ChequeId { get; set; }
        public double? RecDate { get; set; }
        public int? ReceiptNo { get; set; }
        public int? UniReg { get; set; }
        public string IssuedBy { get; set; }
        public double? Dated { get; set; }
        public double? Amount { get; set; }
        public string ChequeNo { get; set; }
        public int? Deposited { get; set; }
        public string DepositedIn { get; set; }
        public int? Bounced { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
        public string AcaSession { get; set; }
    }
}
