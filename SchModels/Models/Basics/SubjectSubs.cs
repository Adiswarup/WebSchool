using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class SubjectSubs
    {
        public SubjectSubs()
        {
            AutoId = 0;
            SubjectSubId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }
        [Key]
        public int AutoId { get; set; }
        public int SubjectSubId { get; set; }
        public int SubId { get; set; }
        [DisplayName("Subject")]
        public string SubName { get; set; }
        [DisplayName("Class")]
        public string Clss { get; set; }
        [DisplayName("Teacher")]
        public string Teacher { get; set; }


        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class SubjectSubsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public SubjectSubs Value { get; set; }
    }
}
