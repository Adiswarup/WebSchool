using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchDataApi.Controllers.StdFees
{
    public class Profile_Receipt
    {
        public Profile_Receipt()
        { }
        [Key]
        public int AutoId { get; set; }
        public int RecId { get; set; }
        public string RecDate { get; set; }
        [DisplayName("Fee Name")]
        public string FeeName { get; set; }
        public string ForMonth { get; set; }
        public int ForMonthX { get; set; }
        public string Amount { get; set; }
        public string Paid { get; set; }
        public string Remarks { get; set; }

    }
}
