using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models.Active
{
    public class AttReg
    {
        [Key]
        public int AttRegID { get; set; }
        public string AttDay { get; set; }
        public int AttRegNum { get; set; }
        public string AttStdName { get; set; }
        public string AttStdRoll { get; set; }
        public bool Attendance { get; set; }
        public string AttReason { get; set; }
        public string AttReMark { get; set; }
    }
}
