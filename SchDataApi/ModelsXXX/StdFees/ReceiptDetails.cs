using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class ReceiptDetails
    {
        public int AutoId { get; set; }
        public int RecId { get; set; }
        public int? ReceiptNo { get; set; }
        public string BillNo { get; set; }
        public int? RegNo { get; set; }
        public int? SlNo { get; set; }
        public double? ForPeriod { get; set; }
        public string FeenWahead { get; set; }
        public int? AmountPaid { get; set; }
        public string RemarkDetails { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? UniReg { get; set; }
        public int? DBid { get; set; }
        public string AcaSession { get; set; }
    }
}
