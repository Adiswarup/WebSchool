using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Communication
{
    public partial class LetterTemplates
    {
        public int AutoId { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string LetterTemplate { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
