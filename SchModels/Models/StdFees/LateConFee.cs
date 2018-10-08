using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.StdFees
{
    public partial class LateConFee
    {
        public int AutoId { get; set; }
        public int Clfid { get; set; }
        public int ForMonth { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public double LateDate { get; set; }
        public double Amount { get; set; }
        public string ForClass { get; set; }
        public int ForPart { get; set; }
        public string StdCategory { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }

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
    public partial class LateConFeeEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public LateConFee Value { get; set; }
    }
}
