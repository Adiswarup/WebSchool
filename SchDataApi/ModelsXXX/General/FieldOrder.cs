using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class FieldOrder
    {
        public int AutoId { get; set; }
        public string FieldName { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public int? TabOrder { get; set; }
        public double? ImagePage { get; set; }
    }
}
