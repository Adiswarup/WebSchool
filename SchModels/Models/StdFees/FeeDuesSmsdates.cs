using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.StdFees
{
    public partial class FeeDuesSmsdates
    {
        public FeeDuesSmsdates() {
            AutoId = 0;
            Fdsdid = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

        public int AutoId { get; set; }
        public int Fdsdid { get; set; }
        public int ForMonth { get; set; }
        public string TextToSend { get; set; }
        public int Status { get; set; }
        public string ForClass { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public double DueCheckDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public double TimeOfDueCheck { get; set; }
        public string StdCategory { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }

        [ScaffoldColumn(false)]
        public int DBid { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
    }
    public partial class FeeDuesSmsdatesEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public FeeDuesSmsdates Value { get; set; }
    }
}
