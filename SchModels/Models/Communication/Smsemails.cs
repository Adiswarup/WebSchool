using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Communication
{
    public partial class Smsemails
    {
        public int AutoId { get; set; }
        public int SmsemailId { get; set; }
        public int Fdsdid { get; set; }
        public int RegNum { get; set; }
        public int UniReg { get; set; }
        public string Text { get; set; }
        public string TFile { get; set; }
        public int Status { get; set; }
        public string MobNo { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public int SmsorEmail { get; set; }
        public int SendorRecieved { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CheckDate { get; set; }
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
        public string Name { get; set; }
        public int DBid { get; set; }
    }
    public partial class SmsemailsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Smsemails Value { get; set; }
    }
}
