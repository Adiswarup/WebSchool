using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class VonRt
    {
        public int AutoId { get; set; }
        public int? VonRtId { get; set; }
        public int? RouteId { get; set; }
        public int? VehicleId { get; set; }
        public double? FrDate { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
