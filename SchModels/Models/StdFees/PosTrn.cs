using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.StdFees
{
    public partial class PosTrn
    {
        public int AutoId { get; set; }
        public int PosTrnId { get; set; }
        public int ReceiptNo { get; set; }
        public int UniReg { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RecDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dated { get; set; }
        public double Amount { get; set; }
        public string PosTrnNo { get; set; }
        public string AcaSession { get; set; }

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
    public partial class PosTrnEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public PosTrn Value { get; set; }
    }
}
