using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Studs
{
    public partial class Awareness
    {
        public int AutoId { get; set; }
        public int? AwareId { get; set; }
        public double? RegNumber { get; set; }
        public string Clss { get; set; }
        public string Session { get; set; }
        public int? AwareNameId { get; set; }
        public string AwareName { get; set; }
        public string AwareValue { get; set; }
        public int? Dormant { get; set; }
        public string CTerminal { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public int? UniReg { get; set; }
        public int? DBid { get; set; }
    }
}
