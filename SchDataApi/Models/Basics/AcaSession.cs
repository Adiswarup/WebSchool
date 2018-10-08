using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class AcaSession
    {
        public int AutoId { get; set; }
        public int Ssdid { get; set; }
        public string SessionName { get; set; }
        public double? SessionStartDate { get; set; }
        public double? SessionEndDate { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
