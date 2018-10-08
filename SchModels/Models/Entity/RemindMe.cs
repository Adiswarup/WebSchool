using System;
using System.Collections.Generic;

namespace SchMod.Models.Entity
{
    public partial class RemindMe
    {
        public int AutoId { get; set; }
        public int RemId { get; set; }
        public int AppId { get; set; }
        public double RemTime { get; set; }
        public string RemSetBy { get; set; }
        public int Remindead { get; set; }
        public int Dormant { get; set; }
        public string LoginName { get; set; }
        public double ModTime { get; set; }
        public string CTerminal { get; set; }
        public int DBid { get; set; }
    }
}
