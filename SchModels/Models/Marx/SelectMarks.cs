using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using GridMvc.DataAnnotations;

namespace SchMod.Models.Marx
{
    public class SelectMarks
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SelectMarksId { get; set; }

        [StringLength(50)]
        [DisplayName("Class")]
        public string MClss { get; set; }

        [StringLength(50)]
        [DisplayName("Subject")]
        public string SubName { get; set; }

        [StringLength(50)]
        [DisplayName("Session")]
        public string Sessn { get; set; }
            //List<SelectListItem>
        [StringLength(50)]
        [DisplayName("Exam Name")]
        public string  ExamName { get; set; }
        public int DBid { get; set; }
    }
    public partial class SelectMarksEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public SelectMarks Value { get; set; }
    }
}



