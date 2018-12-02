using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Exams
{
    public partial class StdSub
    {
        public int AutoId { get; set; }
        public int? StdSubId { get; set; }
        public string SessionA { get; set; }
        public int? StdId { get; set; }
        public int? SubId { get; set; }
        public string Clss { get; set; }
        public int? RegNum { get; set; }
        public string SubName { get; set; }
        public int? RollNum { get; set; }
        public string StdName { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
        public int? UniReg { get; set; }
    }
}
