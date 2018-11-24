using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Registration No.")]
        public int RegNo { get; set; }
        [DisplayName("Roll No. ")]
        public int RollNo { get; set; }
        [DisplayName("Students Name")]
        public string StdName { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
         [DisplayName("Class")]
       public string Clss { get; set; }
         [DisplayName("Father's Name")]
        public string FNames { get; set; }
         [DisplayName("Mother's Name")]
        public string MNames { get; set; }
         [DisplayName("Contact Phone")]
        public string ConPhone { get; set; }
         [DisplayName("E-Mail")]
        public string EmailAddress { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
         [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
         [DisplayName("Fee Category")]
         public string StdCat { get; set; }
        public List<FeeSumm> FeeSumList { get; set; }

    }

    public partial class FeeFormEdit
    {
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public FeeForm Value { get; set; }
    }
}

