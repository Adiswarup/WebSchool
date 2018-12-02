using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class Appoints
    {
        public int AutoId { get; set; }
        public decimal? AppId { get; set; }
        public string AppTitle { get; set; }
        public double? AppDate { get; set; }
        public string AppDuration { get; set; }
        public string AppLocation { get; set; }
        public string AppSubject { get; set; }
        public string AppAgenda { get; set; }
        public string AppNotes { get; set; }
        public int? AccessType { get; set; }
        public string AppPriorty { get; set; }
        public string AppStatus { get; set; }
        public string AppSetBy { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public string AppRemind { get; set; }
        public string AppPeriod { get; set; }
        public string AppHash { get; set; }
        public int? DBid { get; set; }
    }
}
