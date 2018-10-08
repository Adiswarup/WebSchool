using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchDataApi.Models.Studs
{
    public partial class Students
    {
        [ScaffoldColumn(false)]
        public int StdId { get; set; }
        [Required(ErrorMessage = "Registration Number is required")]
        [DisplayName("Registration/Admission Number")]
        public int? RegNumber { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Students Name")]
        public string FirstName { get; set; }
        [ScaffoldColumn(false)]
        public string MiddleName { get; set; }
        [ScaffoldColumn(false)]
        public string LastName { get; set; }
        [DisplayName("Gender")]
        public int? Sex { get; set; }
        [DisplayName("Date of Birth")]
        public double? Dob { get; set; }
        public string Religion { get; set; }
        [Required(ErrorMessage = "Father's Name is required")]
        [DisplayName("Father's Name")]
        public string ParentsNamesF { get; set; }
        [DisplayName("Father's Occupation")]
        public string OccupationF { get; set; }
        [DisplayName("Father's Qualification")]
        public string QualificationF { get; set; }
        [Required(ErrorMessage = "Mother's Name is required")]
        [DisplayName("Mother's Name")]
        public string ParentsNamesM { get; set; }
        [DisplayName("Mother's Occupation")]
        public string OccupationM { get; set; }
        [DisplayName("Mother's Qualification")]
        public string QualificationM { get; set; }
        public double? AnnualIncome { get; set; }
        [Required(ErrorMessage = "Present Class is required")]
        public string PresentClass { get; set; }
        public string Address { get; set; }
        [DisplayName("Street/Locality")]
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        [ScaffoldColumn(false)]
        public string PermAddress { get; set; }
        [ScaffoldColumn(false)]
        public string PermAddress1 { get; set; }
        [ScaffoldColumn(false)]
        public string PermCity { get; set; }
        [ScaffoldColumn(false)]
        public string PermState { get; set; }
        [ScaffoldColumn(false)]
        public string PermPostalCode { get; set; }
        public string StdCategory { get; set; }
        [ScaffoldColumn(false)]
        public string ClassAdmittedTo { get; set; }
        [ScaffoldColumn(false)]
        public string PrevSchool { get; set; }
        [ScaffoldColumn(false)]
        public string StdSession { get; set; }
         [ScaffoldColumn(false)]
       public int? StdStatus { get; set; }
        public byte[] Photo { get; set; }
        [ScaffoldColumn(false)]
        public string BusRoute { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Color/House")]
        public string Color_House { get; set; }
        public string Notes { get; set; }
        [ScaffoldColumn(false)]
        public string PermAilment { get; set; }
        [ScaffoldColumn(false)]
        public string BloodGroup { get; set; }
        [ScaffoldColumn(false)]
        public string Height { get; set; }
        public double? Weight { get; set; }
        [ScaffoldColumn(false)]
        public string Teeth { get; set; }
        [ScaffoldColumn(false)]
        public string VisionL { get; set; }
        [ScaffoldColumn(false)]
        public string VisionR { get; set; }
        [ScaffoldColumn(false)]
        public string OralHygiene { get; set; }
        [ScaffoldColumn(false)]
        public string SplAilment { get; set; }
        [ScaffoldColumn(false)]
        public string PermIdentification { get; set; }
        [ScaffoldColumn(false)]
        public double? Payable { get; set; }
        [ScaffoldColumn(false)]
        public double? Dues { get; set; }
        public int? PresentRollNo { get; set; }
        [ScaffoldColumn(false)]
        public string Testimonials { get; set; }
        public string Hphone { get; set; }
        public string Mphone { get; set; }
        [ScaffoldColumn(false)]
        public double? DateOfFeeApp { get; set; }
        [ScaffoldColumn(false)]
        public double? DateOfAdmission { get; set; }
        [ScaffoldColumn(false)]
        public string Section { get; set; }
        public string Nationality { get; set; }
        [ScaffoldColumn(false)]
        public string Lgname { get; set; }
        [ScaffoldColumn(false)]
        public string Lgaddress1 { get; set; }
        [ScaffoldColumn(false)]
        public string Lgaddress2 { get; set; }
        [ScaffoldColumn(false)]
        public string Lgphone { get; set; }
        public string ConPhone { get; set; }
        public string BoardNo { get; set; }
        [ScaffoldColumn(false)]
        public double? ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int? Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int? UniReg { get; set; }
        [ScaffoldColumn(false)]
        public int? DBid { get; set; }
        public string StdGenCategory { get; set; }
        [ScaffoldColumn(false)]
        public string AdmissionNo { get; set; }
        [ScaffoldColumn(false)]
        public string RouteMode { get; set; }
        [ScaffoldColumn(false)]
        public string BoardRollCode { get; set; }
        public string Aadhar { get; set; }
    }

}
