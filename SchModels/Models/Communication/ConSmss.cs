using System;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Communication
{
    public partial class ConSmss
    {
        public int AutoId { get; set; }
        public int CsmsdateFduesId { get; set; }
        public double DuesCheckDate { get; set; }
        public int Status { get; set; }
        public string TextToSend { get; set; }
        public string ForClass { get; set; }
        public string StdCategory { get; set; }
        public string FeeCaption { get; set; }
        public string SessionName { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
    }
    public partial class ConSmssEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ConSmss Value { get; set; }
    }
}
