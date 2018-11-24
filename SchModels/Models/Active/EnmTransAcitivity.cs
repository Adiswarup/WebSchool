using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Active
{
    public class EnmTransActivity
    {
        public EnmTransActivity()
        {
            TransActId = 0;
            TransActGroup = "None";
            Dormant = 0;
            TransActDate =  DateTime.Now;
        }
        [Key]
        public int AutoId { get; set; }
        public int TransActId { get; set; }
        [DisplayName("Class")]
        public string StdClss { get; set; }
        [DisplayName("Activity Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TransActDate { get; set; }
        [DisplayName("Activity Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public String TransActDateStr { get; set; }
        [DisplayName("Activity Group")]
        public string TransActGroup { get; set; }
        public IEnumerable<TransActivity> ActivityList { get; set; }

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

    public partial class EnmTransActivityEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public EnmTransActivity Value { get; set; }
    }
}
