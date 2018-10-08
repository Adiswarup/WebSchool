using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class SubjectSubs
    {
        public int AutoId { get; set; }
        public int SubjectSubId { get; set; }
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public string Clss { get; set; }
        public string Teacher { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
