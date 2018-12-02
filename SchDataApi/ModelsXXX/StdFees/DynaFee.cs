using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class DynaFee
    {
        public int AutoId { get; set; }
        public int ClsFeeId { get; set; }
        public int? FeeNo { get; set; }
        public string Caption { get; set; }
        public int? ForMonth { get; set; }
        public double? Amount { get; set; }
        public string FeeCaption { get; set; }
        public double? PayByDate { get; set; }
        public string ForClass { get; set; }
        public string StdCategory { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string SessionName { get; set; }
        public string CTerminal { get; set; }
        public double? DueOn { get; set; }
        public int? DBid { get; set; }
    }
}
