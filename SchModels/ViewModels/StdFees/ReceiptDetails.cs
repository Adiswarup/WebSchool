using System;
using System.ComponentModel.DataAnnotations;

namespace SchMod.ViewModels.StdFees
{
    public partial class ReceiptDetails
    {
        public int AutoId { get; set; }
        [Key]
        public int RecId { get; set; }
        public int ReceiptNo { get; set; }
        public string BillNo { get; set; }
        public int RegNo { get; set; }
        public int UniReg { get; set; }
        public int SlNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ForPeriod { get; set; }
        public string FeenWahead { get; set; }
        public double AmountPaid { get; set; }
        public string RemarkDetails { get; set; }
        public string AcaSession { get; set; }

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
    public partial class ReceiptDetailsEdit
    {
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ReceiptDetails Value { get; set; }
    }
}
