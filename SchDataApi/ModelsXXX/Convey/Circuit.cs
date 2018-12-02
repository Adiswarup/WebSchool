using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class Circuit
    {
        public int AutoId { get; set; }
        public int? CircuitId { get; set; }
        public string CircuitName { get; set; }
        public string Stoppage { get; set; }
        public int? StopOrder { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
    }
}
