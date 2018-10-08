using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchDataApi.Models.Basics
{
    //autoId', 'teachId', 'tName', 'teachLoginName', 'tTelephone', 'teachEMail'
    public partial class Teachers
    {
        [Key]
        //[ScaffoldColumn(false)]
        public int autoId { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(0)]
        public int teachId { get; set; }
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
        public int? dormant { get; set; }
        [ScaffoldColumn(false)]
        public double? ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string cTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int? dBid { get; set; }
    }
}
