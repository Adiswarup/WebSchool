namespace SchDataApi.Models.Marx
{
    using System.ComponentModel.DataAnnotations;
    //using GridMvc.DataAnnotations;

    //[GridTable(PagingEnabled = true, PageSize = 10)]
    public class Marks
    {
        [Key]
        public int MkAutoID { get; set; }

        public int? MkID { get; set; }

        //[GridColumn(Title = "Class", SortEnabled = true, FilterEnabled = true)]
        [StringLength(50)]
        public string MClss { get; set; }

        //[GridColumn(Title = "Roll", SortEnabled = true, FilterEnabled = true)]
        public int presentRollNum { get; set; }

        //[GridColumn(Title = "Name", SortEnabled = true, FilterEnabled = true)]
        public string StdName { get; set; }

        [StringLength(100)]
        //[GridColumn(Title = "Subject", SortEnabled = true, FilterEnabled = true)]
        public string SubName { get; set; }

        [StringLength(50)]
        public string ExamName { get; set; }

        public double? ThMarks { get; set; }

        public double? PracMarks { get; set; }

        public double? OrMarks { get; set; }

        public double? AsgnMarks { get; set; }

        //[GridColumn(Title = "TotalMarks", SortEnabled = true, FilterEnabled = true)]
        public double? TotalMarks { get; set; }

        public double? TotalMarksCalc { get; set; }

        public double? GradesVal { get; set; }

        [StringLength(255)]
        //[GridColumn(Title = "Grades", SortEnabled = true, FilterEnabled = true)]
        public string Grades { get; set; }

        public int? RegNum { get; set; }

        [StringLength(255)]
        public string MSession { get; set; }

        [StringLength(50)]
        public string StdGrades { get; set; }

        //[GridColumn(Hidden = true)]
        public string RecMode { get; set; }
        public string LoginName { get; set; }

        public int? Dormant { get; set; }

        public double? ModTime { get; set; }

        [StringLength(255)]
        public string cTerminal { get; set; }

        public int? UniReg { get; set; }

        [StringLength(255)]
        public string ScaleUpGrade { get; set; }

        public int? dBID { get; set; }

        public double? Percentile { get; set; }

        public double? FMarks { get; set; }
    }
}
