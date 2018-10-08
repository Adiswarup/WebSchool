using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Convey
{
    public partial class Conveyance
    {
        public int AutoId { get; set; }
        [Key]
        public int ConId { get; set; }
        [DisplayName("Reg #")]
        public int RegNum { get; set; }
        [DisplayName("Name")]
        public string StdName { get; set; }
        [DisplayName("Class")]
        public string Clss { get; set; }
        [DisplayName("Roll #")]
        public int RollNo { get; set; }
        [DisplayName("Save")]
        public bool Commit { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        public string Parents { get; set; }
        public string Address { get; set; }
        public int UniReg { get; set; }
        public double Fare { get; set; }
        public int StopId { get; set; }
        [DisplayName("Boarding Stop")]
        public string Stops { get; set; }
        [DisplayName("Conveyance Mode")]
        public string ConMode { get; set; }
        public int RouteId { get; set; }
        [DisplayName("Date From (Boarding at this Stop)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateFrom { get; set; }
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Date is required")]
        //[RegularExpression(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$", ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateTo { get; set; }

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
    public partial class ConveyanceEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Conveyance Value { get; set; }
    }
}
