using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class Holidays
    {
        public int AutoId { get; set; }
        public int? Hid { get; set; }
        public double? Hdate { get; set; }
        public string Title { get; set; }
        public string Htype { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Clss { get; set; }
        public string AcaSession { get; set; }
        public string Descrptn { get; set; }
        public int? Dormant { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
