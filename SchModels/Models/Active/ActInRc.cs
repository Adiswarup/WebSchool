using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchMod.Models.Active
{
    [Table("ActInRC")]
    public partial class ActInRc
    {
        [Key]
        public int AutoId { get; set; }
        public int ActGrRcid { get; set; }
        public int ActGrId { get; set; }
        public string Cls { get; set; }
        public string AcaSession { get; set; }
        public int SlRc { get; set; }
        public string LoginName { get; set; }
        public int Dormant { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime  ModTime { get; set; }
        public string CTerminal { get; set; }
        public int DBid { get; set; }
    }
    public partial class ActInRcEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ActInRc Value { get; set; }
    }

}
