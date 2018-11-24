using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models.Basics
{
    public class DropDown
    {
        public string drptext { get; set; }
        public string drpvalue { get; set; }
        public DropDown() { }
        public DropDown( string txt,string val) //
        {
            this.drptext = txt;
            this.drpvalue = val;
        }
    }
    public class DropDownTeach
    {
        public string ClassTeacher { get; set; }
        //public string value { get; set; }
        public DropDownTeach() { }
        public DropDownTeach(string txt) //string val,
        {
            this.ClassTeacher = txt;
            //this.value = val;
        }
    }
    public class DropDownConv
    {
        public string convMode { get; set; }
        public DropDownConv() { }
        public DropDownConv(string txt) //string val,
        {
            this.convMode = txt;
        }
    }

    public class DropDownGradeType
    {
        public string GradeType { get; set; }
        public DropDownGradeType() { }
        public DropDownGradeType(string txt) //string val,
        {
            this.GradeType = txt;
        }
    }
    public class DropDownCls
    {
        public string Clss { get; set; }
        public DropDownCls() { }
        public DropDownCls(string txt) //string val,
        {
            this.Clss = txt;
        }
    }
    public class DropDownActivityGroup
    {
        public string ActivityGroup { get; set; }
        public DropDownActivityGroup() { }
        public DropDownActivityGroup(string txt) //string val,
        {
            this.ActivityGroup = txt;
        }
    }

    public class DropDownActivity
    {
        public string Activity { get; set; }
        public DropDownActivity() { }
        public DropDownActivity(string txt) //string val,
        {
            this.Activity = txt;
        }
    }

}
