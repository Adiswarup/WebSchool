using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class CashDenom
    {
        public int AutoId { get; set; }
        public int? CdenoId { get; set; }
        public double? RecDate { get; set; }
        public int? ReceiptNo { get; set; }
        public int? UniReg { get; set; }
        public string Denomination { get; set; }
        public double? Received { get; set; }
        public double? Returned { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
        public string AcaSession { get; set; }
    }
}
