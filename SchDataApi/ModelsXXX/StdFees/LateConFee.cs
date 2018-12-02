using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class LateConFee
    {
        public int AutoId { get; set; }
        public int Clfid { get; set; }
        public int? ForMonth { get; set; }
        public double? LateDate { get; set; }
        public double? Amount { get; set; }
        public string ForClass { get; set; }
        public int? ForPart { get; set; }
        public string StdCategory { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
