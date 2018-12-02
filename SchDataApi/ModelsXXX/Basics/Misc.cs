using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class Misc
    {
        public int AutoId { get; set; }
        public int MiscId { get; set; }
        public string SchRegNum { get; set; }
        public string SchName { get; set; }
        public string SchAddress { get; set; }
        public string SchMotto { get; set; }
        public string SchPhone { get; set; }
        public string PcpName { get; set; }
        public string PcpPhone { get; set; }
        public string Emedium { get; set; }
        public string Curriculum { get; set; }
        public string BoardAffiliationno { get; set; }
        public string AcaSession { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int? RegMode { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public double? SessionStartDate { get; set; }
        public int? MdBid { get; set; }
        public int? DBid { get; set; }
        public string Version { get; set; }
        public int? RecMode { get; set; }
    }
}
