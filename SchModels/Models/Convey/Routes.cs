using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Convey
{
    public partial class Routes
    {
        public int AutoId { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteNo { get; set; }
        public string RouteMode { get; set; }
        public int StopsId { get; set; }
        public int StopOrder { get; set; }
        public string StopTimeTo { get; set; }
        public string StopTimeFro { get; set; }
        public string RouteDes { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class RoutesEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Routes Value { get; set; }
    }
}
