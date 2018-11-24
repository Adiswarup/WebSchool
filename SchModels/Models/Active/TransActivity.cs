using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Active
{
    public partial class TransActivity
    {
        public TransActivity()
            {
            TransActId = 0;
            Activity = "None";
            Dormant = 0;
            TransActDate = DateTime.Now;
            }
        [Key]
        public int AutoId { get; set; }
        public int TransActId { get; set; }
        [DisplayName("Activity")]
        public string Activity { get; set; }
        public int ActivityId { get; set; }
        public int ActGroupID { get; set; }
        [DisplayName("Reg #")]
        public int RegNumber { get; set; }
        [DisplayName("Roll #")]
        public int RollNumber { get; set; }
        public double TransActValue { get; set; }
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TransActDate { get; set; }
        [DisplayName("Observer")]
        public string TransActObserver { get; set; }
        [DisplayName("Name")]
        public string StdName { get; set; }
        public string ImgDataURL { get; set; }

        [DisplayName("Class")]
        public string StdClss { get; set; }
        public int TeachId { get; set; }
        [DisplayName("Remarks")]
        public string TransActRemarks { get; set; }
        public double Score { get; set; }
        [DisplayName("Save")]
        public Boolean Commit { get; set; }
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

    public partial class TransActivityEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public TransActivity Value { get; set; }
    }

}
