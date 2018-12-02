using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class Stops
    {
        public int AutoId { get; set; }
        public int? StopId { get; set; }
        public string ConveyanceMode { get; set; }
        public string Stops1 { get; set; }
        public string Circuit { get; set; }
        public double? MonthlyFare { get; set; }
        public double? FareFromMonth { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
