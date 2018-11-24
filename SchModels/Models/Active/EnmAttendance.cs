using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models.Active
{
    public class EnmAttendance
    {
        [Key]
        public int AutoId { get; set; }
        public int TransActId { get; set; }
        [DisplayName("Class")]
        public string StdClss { get; set; }
        [DisplayName("Attendance Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AttDate { get; set; }
        [DisplayName("Attendance Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public String TransActDateStr { get; set; }
        [DisplayName("Attendance Type")]
        public string AttType { get; set; }
        public IEnumerable<Attendance> AttendanceList { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [ScaffoldColumn(false)]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        public int UniReg { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class EnmAttendanceEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public EnmAttendance Value { get; set; }
    }

}
