using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class VehicleType
    {
        public int AutoId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleType1 { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
