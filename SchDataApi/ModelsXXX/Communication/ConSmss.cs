using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Communication
{
    public partial class ConSmss
    {
        public int AutoId { get; set; }
        public int? CsmsdateFduesId { get; set; }
        public double? DuesCheckDate { get; set; }
        public int? Status { get; set; }
        public string TextToSend { get; set; }
        public string ForClass { get; set; }
        public string StdCategory { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }
        public int? DBid { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
    }
}
