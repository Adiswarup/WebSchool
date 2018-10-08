using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchDataApi.Models.Studs
{
    public class SearchStd
    {
        //public SearchStd ()
        //{

        //    sStdID = 0;
        //    sUniReg = 0;
        //    sRegNumber = 0;
        //    sStdName = "";
        //    sFNames = "";
        //    sClass = "";
        //    sGender = 0;
        //    sDOB = 0;
        //    List<String> sClssList = new List<String>();
        //    sClssList.Add("Select");
        //    Student stu = new Student();
        //   //List<Student> stdList =new  List<Student>();
        //    //stdList.Add(stu);
        //     IEnumerable<Student> stdList = new List<Student>{stu};
           
        //    //Student stu = new Student();
        //    //stdList.Add(stu);
        //}

        [Key]
        public int sStdID { get; set; }
        public int? sUniReg { get; set; }
        public int? sRegNumber { get; set; }
        public string sStdName { get; set; }
        public string sClass { get; set; }
        public string sFNames { get; set; }
        public int? sGender { get; set; }
        public double? sDOB { get; set; }
        //public IEnumerable <String> sClssList {get; set; }
        public IEnumerable <Students> stdList { get; set; }
    }
}