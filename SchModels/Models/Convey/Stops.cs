using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Convey
{
    public partial class Stops
    {
        public int AutoId { get; set; }
        [Key]
        public int stopId { get; set; }
        [DisplayName("Mode")]
        public string drptext { get; set; }
        //public string conveyanceMode { get; set; }
        [DisplayName("Stops")]
        public string stops1 { get; set; }
         [DisplayName("Circuit")]
       public string circuit { get; set; }
        [DisplayName("Fare (Monthly)")]
        public double monthlyFare { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM/yyyy}")]
        [DisplayName("Fare Start Month")]
        public DateTime fareFromMonth { get; set; }

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
    public partial class StopsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Stops Value { get; set; }
    }
}
