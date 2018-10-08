using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class Misc
    {
        public Misc()
        {
            AutoId = 0;
            MiscId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

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
        public int RegMode { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public double SessionStartDate { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
        [ScaffoldColumn(false)]
        public string Version { get; set; }
        [ScaffoldColumn(false)]
        public int RecMode { get; set; }
    }

    public partial class MiscEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Misc Value { get; set; }
    }


}
