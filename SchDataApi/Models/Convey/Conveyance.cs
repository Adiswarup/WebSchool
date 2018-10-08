using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class Conveyance
    {
        public int AutoId { get; set; }
        public int? ConId { get; set; }
        public int? RegNum { get; set; }
        public int? StopId { get; set; }
        public string ClssName { get; set; }
        public int? RouteId { get; set; }
        public double? DateFrom { get; set; }
        public double? DateTo { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? UniReg { get; set; }
        public int? DBid { get; set; }
    }
}
