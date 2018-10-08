using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
{
    public partial class TrStdClassCat
    {
        public int AutoId { get; set; }
        public int TrStdId { get; set; }
        public int RegNumber { get; set; }
        public string StdName { get; set; }
        public string ClsPromTo { get; set; }
        public string ClsPromFrom { get; set; }
        public string StdCatTo { get; set; }
        public string StdCatFrom { get; set; }
        public string AcaSessionTo { get; set; }
        public string AcaSessionFrom { get; set; }

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
    public partial class TrStdClassCatEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public TrStdClassCat Value { get; set; }
    }
}
