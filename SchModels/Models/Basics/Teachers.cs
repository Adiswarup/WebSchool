using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    //autoId', 'teachId', 'tName', 'teachLoginName', 'tTelephone', 'teachEMail'
    public partial class Teachers
    {
        public Teachers()
        {
            AutoId = 0;
            teachId = 0;

            dBid = mdBId;
            loginName = mLoginName;
            dormant = 0;
            ModTime = DateTime.Now;
            cTerminal = mCTerminal;
        }
        [Key]
        //[ScaffoldColumn(false)]
        public int AutoId { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(0)]
        public int teachId { get; set; }
        [DisplayName("Search")]
        public string SeaStr { get; set; }
        [Required(ErrorMessage = "Teacher's Name is required")]
        [DisplayName("Teacher's Name ")]
        public string tName { get; set; }
        [DisplayName("Teacher's Mobile No. ")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string tTelephone { get; set; }
        [DisplayName("Teacher's Login Name ")]
        public string teachLoginName { get; set; }
        [DisplayName("Teacher's E-Mail Address ")]
        [EmailAddress]
        public string teachEMail { get; set; }
        [ScaffoldColumn(false)]
        public string loginName { get; set; }
        [ScaffoldColumn(false)]
        public int dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string cTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int dBid { get; set; }
    }
    public partial class TeachersEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Teachers Value { get; set; }
    }
}
