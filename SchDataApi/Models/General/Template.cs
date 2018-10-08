using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class Template
    {
        public int AutoId { get; set; }
        public int? TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateValue { get; set; }
        public double? TempModTime { get; set; }
        public int? Dormant { get; set; }
        public string CTerminal { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public int? DBid { get; set; }
    }
}
