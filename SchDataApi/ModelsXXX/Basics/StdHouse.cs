using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class StdHouse
    {
        public int AutoId { get; set; }
        public int StdHouseId { get; set; }
        public string StdHouse1 { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
