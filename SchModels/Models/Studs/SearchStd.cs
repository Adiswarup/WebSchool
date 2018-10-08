using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
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
        public int SStdID { get; set; }
        public int SUniReg { get; set; }
        [DisplayName("Reg #")]
        public int SRegNumber { get; set; }
        [DisplayName("Name")]
        public string SStdName { get; set; }
        [DisplayName("Class")]
        public string SClass { get; set; }
        [DisplayName("Search")]
        public string SeaStr { get; set; }
        [DisplayName("Gender")]
        public int SGender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Birth")]
        public DateTime SDOB { get; set; }
        //public IEnumerable <String> sClssList {get; set; }
        public IEnumerable<Students> StdList { get; set; }
    }
    public partial class SearchStdEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public SearchStd Value { get; set; }
    }
}