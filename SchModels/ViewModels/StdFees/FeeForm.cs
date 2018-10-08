using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchMod.ViewModels.StdFees
{
    public class FeeForm
    {
        public FeeForm()
        {
            Sn = 0;
            UniReg = 0;
            RegNo = 0;
            RollNo = 0;
            StdName = "--";
            Gender = "";
            Clss = "";
            FNames = "";
            MNames = "";
            ConPhone = "";
            EmailAddress = "";
            DOB = DateTime.Now;
            StdCat = "New";            //{
            //    new FeeSumm()
            //};

        }
        [Key]
        public int Sn { get; set; }
        public int UniReg { get; set; }
        public int RegNo { get; set; }
        public int RollNo { get; set; }
        public string StdName { get; set; }
        public string Gender { get; set; }
        public string Clss { get; set; }
        public string FNames { get; set; }
        public string MNames { get; set; }
        public string ConPhone { get; set; }
        public string EmailAddress { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }
         public string StdCat { get; set; }
       //public List<FeeSumm> FeeSumList { get; set; }

    }

    public partial class FeeFormEdit
    {
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public FeeForm Value { get; set; }
    }
}

