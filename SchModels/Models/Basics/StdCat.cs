using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Basics
{
    public partial class StdCat
    {
        public StdCat()
        {
            AutoId = 0;
            StdCatId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }

       public int AutoId { get; set; }
         [Key]
        public int StdCatId { get; set; }
        [DisplayName("Student Category")]
        public string StdCategory { get; set; }

        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class StdCatEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public StdCat Value { get; set; }
    }
}
