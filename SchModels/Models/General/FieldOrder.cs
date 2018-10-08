using System;
using System.Collections.Generic;

namespace SchMod.Models.General
{
    public partial class FieldOrder
    {
        public int AutoId { get; set; }
        public string FieldName { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public int TabOrder { get; set; }
        public double ImagePage { get; set; }
    }
    public partial class FieldOrderEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public FieldOrder Value { get; set; }
    }
}
