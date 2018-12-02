using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class Fcaption
    {
        public int AutoId { get; set; }
        public int FeeNameId { get; set; }
        public string FeeCaption { get; set; }
        public string FeeDuration { get; set; }
        public string FeeType { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? FeeOrder { get; set; }
        public int? DBid { get; set; }
    }
}
