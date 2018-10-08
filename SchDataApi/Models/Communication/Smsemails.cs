using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Communication
{
    public partial class Smsemails
    {
        public int AutoId { get; set; }
        public int? SmsemailId { get; set; }
        public int? Fdsdid { get; set; }
        public int? RegNum { get; set; }
        public int? UniReg { get; set; }
        public string Text { get; set; }
        public string TFile { get; set; }
        public int? Status { get; set; }
        public int? DBid { get; set; }
        public string MobNo { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public int? SmsorEmail { get; set; }
        public int? SendorRecieved { get; set; }
        public double? CheckDate { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public string Name { get; set; }
    }
}
