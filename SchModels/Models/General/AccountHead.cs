using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.General
{
    public partial class AccountHead
    {
        [Key]
        public int AccId { get; set; }
        public string AccName { get; set; }
        public string Type { get; set; }
        public string Balance { get; set; }
    }
    public partial class AccountHeadEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public AccountHead Value { get; set; }
    }
}
