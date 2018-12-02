using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Studs
{
    public partial class AwareNames
    {
        public int AutoId { get; set; }
        public int? AwareNameId { get; set; }
        public string AwareName { get; set; }
        public int? IsReflectedInReportCard { get; set; }
        public string AwareNameReportCard { get; set; }
        public string AwareNameMotive { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? AwareNameSn { get; set; }
        public int? DBid { get; set; }
    }
}
