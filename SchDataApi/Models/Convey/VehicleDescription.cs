using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class VehicleDescription
    {
        public int AutoId { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string VDriver { get; set; }
        public string VNumber { get; set; }
        public string DriverAddress { get; set; }
        public string DriverDetails { get; set; }
        public string VehicleDetails { get; set; }
        public string ContactPhone { get; set; }
        public int? Capacity { get; set; }
        public string Circuit { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
