using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Convey
{
    public partial class Routes
    {
        public int AutoId { get; set; }
        public int? RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteNo { get; set; }
        public string RouteMode { get; set; }
        public int StopsId { get; set; }
        public int? StopOrder { get; set; }
        public string StopTimeTo { get; set; }
        public string StopTimeFro { get; set; }
        public string RouteDes { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
