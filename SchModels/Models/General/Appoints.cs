using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.General
{
    public partial class Appoints
    {
        public int AutoId { get; set; }
        public decimal? AppId { get; set; }
        public string AppTitle { get; set; }
        public double AppDate { get; set; }
        public string AppDuration { get; set; }
        public string AppLocation { get; set; }
        public string AppSubject { get; set; }
        public string AppAgenda { get; set; }
        public string AppNotes { get; set; }
        public int AccessType { get; set; }
        public string AppPriorty { get; set; }
        public string AppStatus { get; set; }
        public string AppSetBy { get; set; }
        public string AppRemind { get; set; }
        public string AppPeriod { get; set; }
        public string AppHash { get; set; }

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
    public partial class AppointsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Appoints Value { get; set; }
    }
}
