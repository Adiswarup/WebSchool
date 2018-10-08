using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class Clss
    {
        public Clss()
        {
            AutoId = 0;
            ClsId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

        [ScaffoldColumn(false)]
        public int AutoId { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(0)]
         [Key]
       public int ClsId { get; set; }
        [Required(ErrorMessage = "Class' Name is required")]
        [DisplayName("Class")]
        public string ClsName { get; set; }
        [ScaffoldColumn(false)]
        public int TeachId { get; set; }
      [DisplayName("Class Teacher")]
        public String ClassTeacher { get; set; }
        [ScaffoldColumn(false)]
        public string Room { get; set; }
        public int StdStrength { get; set; }
        [ScaffoldColumn(false)]
        public int ClsPerDay { get; set; }
        [ScaffoldColumn(false)]
        public int ClsSat { get; set; }
        public int BoardCode { get; set; }
        [DisplayName("Class Order")]
        public double ClssNum { get; set; }
        [ScaffoldColumn(false)]
        public string AcaSession { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class ClssEdit
    {

        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Clss Value { get; set; }
    }
}
