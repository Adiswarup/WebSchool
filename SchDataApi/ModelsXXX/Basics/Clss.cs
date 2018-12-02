using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchDataApi.Models.Basics
{
    public partial class Clss
    {
        [Key]
        [ScaffoldColumn(false)]
        public int AutoId { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(0)]
        public int ClsId { get; set; }
        [Required(ErrorMessage = "Class' Name is required")]
        [DisplayName("Class")]
        public string ClsName { get; set; }
        [ScaffoldColumn(false)]
        public int? TeachId { get; set; }
        public string ClassTeacher { get; set; }
        [ScaffoldColumn(false)]
        public string Room { get; set; }
        public int? StdStrength { get; set; }
        [ScaffoldColumn(false)]
        public int? ClsPerDay { get; set; }
        [ScaffoldColumn(false)]
        public int? ClsSat { get; set; }
        public int? BoardCode { get; set; }
        public double? ClssNum { get; set; }
        [ScaffoldColumn(false)]
        public string AcaSession { get; set; }
        [ScaffoldColumn(false)]
        public int? Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public double? ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int? DBid { get; set; }
    }
}
