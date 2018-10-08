using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.General
{
    public partial class LoginDetails
    {
        public int AutoId { get; set; }
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public int LoginLevel { get; set; }
        public string SpecialDetail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LoginExpiry { get; set; }
        public string HintQuestion { get; set; }
        public string HintAnswer { get; set; }
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginNameCh { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class LoginDetailsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public LoginDetails Value { get; set; }
    }
}
