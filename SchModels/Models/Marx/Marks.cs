namespace SchMod.Models.Marx
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    //using GridMvc.DataAnnotations;

    //[GridTable(PagingEnabled = true, PageSize = 10)]
    public class Marks
    {
        
        [Key]
        public int MkID { get; set; }

        public int MkAutoID { get; set; }
        //[GridColumn(Title = "Class", SortEnabled = true, FilterEnabled = true)]
        [StringLength(50)]
        public string MClss { get; set; }

        //[GridColumn(Title = "Roll", SortEnabled = true, FilterEnabled = true)]
        [DisplayName("Class")]
        public int presentRollNum { get; set; }

        //[GridColumn(Title = "Name", SortEnabled = true, FilterEnabled = true)]
        [DisplayName("Roll")]
        public string StdName { get; set; }

        [StringLength(100)]
        //[GridColumn(Title = "Subject", SortEnabled = true, FilterEnabled = true)]
        [DisplayName("Subject")]
        public string SubName { get; set; }

        [StringLength(50)]
        [DisplayName("Exam Name")]
        public string ExamName { get; set; }

        [DisplayName("Theory")]
        public string ThMarks { get; set; }

        [DisplayName("Practicals")]
        public string PracMarks { get; set; }

        [DisplayName("Oral")]
        public string OrMarks { get; set; }

        [DisplayName("Assignment")]
        public string AsgnMarks { get; set; }

        //[GridColumn(Title = "TotalMarks", SortEnabled = true, FilterEnabled = true)]
        public string TotalMarks { get; set; }

        [DisplayName("Total Marks(Calculated)")]
        public string TotalMarksCalc { get; set; }

        [DisplayName("Grades Value")]
        public string GradesVal { get; set; }

        [StringLength(255)]
        //[GridColumn(Title = "Grades", SortEnabled = true, FilterEnabled = true)]
        [DisplayName("Grades")]
        public string Grades { get; set; }

        public int UniReg { get; set; }
        [DisplayName("Registration #")]
        public int RegNum { get; set; }

        [StringLength(255)]
        [DisplayName("Session")]
        public string MSession { get; set; }

        [StringLength(50)]
        public string StdGrades { get; set; }

        //[GridColumn(Hidden = true)]
        public string RecMode { get; set; }
        public string LoginName { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }

        [StringLength(255)]
        [ScaffoldColumn(false)]
        public string cTerminal { get; set; }


        [StringLength(255)]
        public string ScaleUpGrade { get; set; }

        [ScaffoldColumn(false)]
        public int dBID { get; set; }

        [DisplayName("Percentile")]
        public double Percentile { get; set; }

        [DisplayName("Full Marks")]
        public double FMarks { get; set; }
    }
    public partial class MarksEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Marks Value { get; set; }
    }
}
