using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models.Basics
{
    public class DropDown
    {
        public string drptext { get; set; }
        //public string value { get; set; }
        public DropDown() { }
        public DropDown( string txt) //string val,
        {
            this.drptext = txt;
            //this.value = val;
        }
    }
    public class DropDownTeach
    {
        public string classTeacher { get; set; }
        //public string value { get; set; }
        public DropDownTeach() { }
        public DropDownTeach(string txt) //string val,
        {
            this.classTeacher = txt;
            //this.value = val;
        }
    }
    public class DropDownConv
    {
        public string convMode { get; set; }
        //public string value { get; set; }
        public DropDownConv() { }
        public DropDownConv(string txt) //string val,
        {
            this.convMode = txt;
            //this.value = val;
        }
    }


}
