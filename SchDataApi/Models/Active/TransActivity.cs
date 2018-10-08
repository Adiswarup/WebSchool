using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Active
{
    public partial class TransActivity
    {
        public int AutoId { get; set; }
        public int? TransActId { get; set; }
        public string TransActName { get; set; }
        public int? ActivityId { get; set; }
        public int? RegNumber { get; set; }
        public double? TransActValue { get; set; }
        public double? TransActDate { get; set; }
        public string TransActObserver { get; set; }
        public int? TeachId { get; set; }
        public string TransActRemarks { get; set; }
        public double? Score { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? UniReg { get; set; }
        public int? DBid { get; set; }
    }
}
