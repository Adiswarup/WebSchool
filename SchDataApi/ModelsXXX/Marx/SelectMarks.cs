using System.ComponentModel.DataAnnotations;
//using GridMvc.DataAnnotations;

namespace SchDataApi.Models.Marx
{
    public class SelectMarks
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SelectMarksId { get; set; }

        [StringLength(50)]
        public string MClss { get; set; }

        [StringLength(50)]
        public string SubName { get; set; }

        [StringLength(50)]
        public string Sessn { get; set; }
            //List<SelectListItem>
        [StringLength(50)]
        public string  ExamName { get; set; }
        
    }
}



