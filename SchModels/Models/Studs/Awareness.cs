using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
{
    public partial class Awareness
    {
        public int AutoId { get; set; }
        public int AwareId { get; set; }
        public double RegNumber { get; set; }
        public int UniReg { get; set; }
        public string Clss { get; set; }
        public string Session { get; set; }
        public int AwareNameId { get; set; }
        public string AwareName { get; set; }
        public string AwareValue { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class AwarenessEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Awareness Value { get; set; }
    }
}
