using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SchMod.StClass;

namespace SchMod.Models.Active
{
    public partial class ActivityGroup
    {
        public ActivityGroup()
        {
            AutoId = 0;
            ActGroupId = 0;

            DBid = mdBId;
            LoginName = mLoginName;
            Dormant = 0;
            ModTime = DateTime.Now;
            CTerminal = mCTerminal;
        }
        public int AutoId { get; set; }
        [Key]
        [DefaultValue(0)]
        public int ActGroupId { get; set; }
        [DisplayName("Activity Group Name")]
        public string ActGroupName { get; set; }
        [DisplayName("Is Shown In ReportCard")]
        public Boolean IsReflectedInReportCard { get; set; }
        [DisplayName("Activity Name Group ReportCard")]
        public string ActGroupReportCard { get; set; }
        [DisplayName("Activity Group Motive")]
        public string ActGroupMotive { get; set; }
        [DisplayName("Activity Code")]
        public string ActCode { get; set; }
        [DisplayName("Grade Type")]
        public string GradeType { get; set; }
        [DisplayName("Class")]
        public string Clss { get; set; }
        [DisplayName("Activity Serial No.")]
        public int ActSn { get; set; }
        [DisplayName("Activity Class")]
        public string ActClss { get; set; }
        [DisplayName("Activity Session")]
        public string ActSession { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
    }
    public partial class ActivityGroupEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public ActivityGroup Value { get; set; }
    }

}
