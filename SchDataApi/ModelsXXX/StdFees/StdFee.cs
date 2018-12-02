using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class StdFee
    {
        public int AutoId { get; set; }
        public int StdFeeId { get; set; }
        public int? RegNo { get; set; }
        public string Caption { get; set; }
        public double? ForMonth { get; set; }
        public double? Amount { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? UniReg { get; set; }
        public int? DBid { get; set; }
        public int? ChequeId { get; set; }
        public int? FeeNo { get; set; }
    }
}
