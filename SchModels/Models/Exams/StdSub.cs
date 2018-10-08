using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Exams
{
    public partial class StdSub
    {
        public int AutoId { get; set; }
        public int StdSubId { get; set; }
        public string SessionA { get; set; }
        public int StdId { get; set; }
        public int SubId { get; set; }
        public string Clss { get; set; }
        public int RegNum { get; set; }
        public int UniReg { get; set; }
        public string SubName { get; set; }
        public int RollNum { get; set; }
        public string StdName { get; set; }

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
        public int DBid { get; set; }
    }
    public partial class StdSubEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public StdSub Value { get; set; }
    }
}
