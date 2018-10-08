using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class LoginDetails
    {
        public int AutoId { get; set; }
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public int? LoginLevel { get; set; }
        public string SpecialDetail { get; set; }
        public double? LoginExpiry { get; set; }
        public string HintQuestion { get; set; }
        public string HintAnswer { get; set; }
        public string Email { get; set; }
        public int? Dormant { get; set; }
        public string LoginNameCh { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
