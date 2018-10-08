using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.StdFees
{
    public partial class StdFee
    {
        public int AutoId { get; set; }
        public int StdFeeId { get; set; }
        public int UniReg { get; set; }
        public int RegNo { get; set; }
        public string Caption { get; set; }
        public double ForMonth { get; set; }
        public double Amount { get; set; }
        public int ChequeId { get; set; }
        public int FeeNo { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class StdFeeEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public StdFee Value { get; set; }
    }
}
