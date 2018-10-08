using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
{
    public partial class AwareNames
    {
        public int AutoId { get; set; }
        public int AwareNameId { get; set; }
        public string AwareName { get; set; }
        public int IsReflectedInReportCard { get; set; }
        public string AwareNameReportCard { get; set; }
        public string AwareNameMotive { get; set; }
        public int AwareNameSn { get; set; }

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
    public partial class AwareNamesEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public AwareNames Value { get; set; }
    }
}
