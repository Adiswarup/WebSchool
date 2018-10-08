using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
{
    public partial class CharecterCertificate
    {
        public int AutoId { get; set; }
        public int TcId { get; set; }
        public int Sn { get; set; }
        public int AdmissionNo { get; set; }
        public string Nationality { get; set; }
        public string LastExam { get; set; }
        public string Foiled { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
        public string Subject5 { get; set; }
        public string Subject6 { get; set; }
        public string Subject7 { get; set; }
        public string Qualified { get; set; }
        public string PromotedClass { get; set; }
        public string DuesPaid { get; set; }
        public string Concession { get; set; }
        public int Workingday { get; set; }
        public int Present { get; set; }
        public string NccGg { get; set; }
        public string CurricularActivities { get; set; }
        public string Conduct { get; set; }
        public double DoApplication { get; set; }
        public double DoIssue { get; set; }
        public string ReasonOfTc { get; set; }
        public string Remarks { get; set; }
        public string ScSt { get; set; }
        public int UniReg { get; set; }
        public byte[] TcFile { get; set; }
        public string RollCode { get; set; }
        public string RollNo { get; set; }
        public string PassingYear { get; set; }
        public string CompSub { get; set; }
        public string Division { get; set; }
        public string Character { get; set; }
        public string Promotion { get; set; }
        public double LeftOn { get; set; }
        public string AcaSession { get; set; }

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
    public partial class CharecterCertificateEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public CharecterCertificate Value { get; set; }
    }
}
