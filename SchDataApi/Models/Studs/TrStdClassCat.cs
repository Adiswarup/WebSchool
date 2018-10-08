using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Studs
{
    public partial class TrStdClassCat
    {
        public int AutoId { get; set; }
        public int TrStdId { get; set; }
        public int? RegNumber { get; set; }
        public string StdName { get; set; }
        public string ClsPromTo { get; set; }
        public string ClsPromFrom { get; set; }
        public string StdCatTo { get; set; }
        public string StdCatFrom { get; set; }
        public string AcaSessionTo { get; set; }
        public string AcaSessionFrom { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
