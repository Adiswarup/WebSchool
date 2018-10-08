using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Convey
{
    public partial class VehicleDescription
    {
        public int AutoId { get; set; }
        [Key]
        public int VehicleId { get; set; }
        [DisplayName("Vehicle Name")]
        public string VehicleName { get; set; }
        [DisplayName("Vehicle Type")]
        public string VehicleType { get; set; }
        [DisplayName("Driver Name")]
        public string VDriver { get; set; }
        [DisplayName("Vehicle Number")]
        public string VNumber { get; set; }
        [DisplayName("Driver's Address")]
        public string DriverAddress { get; set; }
        [DisplayName("Driver's Details")]
        public string DriverDetails { get; set; }
        [DisplayName("Vehicle's Details")]
        public string VehicleDetails { get; set; }
        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }
        [DisplayName("Capacity")]
        public int Capacity { get; set; }
        [DisplayName("Circuit")]
        public string Circuit { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class VehicleDescriptionEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public VehicleDescription Value { get; set; }
    }
}
