using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Basics
{
    public partial class StdCat
    {
        public int AutoId { get; set; }
        public int StdCatId { get; set; }
        public string StdCategory { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
