using System;
using System.Collections.Generic;

namespace SchDataApi.Models.StdFees
{
    public partial class AccountHead
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public string Type { get; set; }
        public string Balance { get; set; }
    }
}
