using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.StdFees
{
    public partial class StdFeeCat
    {
        public StdFeeCat()
        {
            AutoId = 0;
            StdFeeCatId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

        public int AutoId { get; set; }
        public int StdFeeCatId { get; set; }
        [DisplayName("Student Fee Category")]
        public string StdFeeCategory { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class StdFeeCatEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public StdFeeCat Value { get; set; }
    }
}
