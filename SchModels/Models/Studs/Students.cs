using Microsoft.AspNetCore.Mvc;
using SchDataApi.Controllers.StdFees;
using SchMod.Models.Active;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models.Studs
{
    public partial class Students
    {
        public Students()
        {
            StdId = 0;
            RegNumber = 0;
            StdName = "A";
            Sex = "Boy";
            Dob = DateTime.Now;
            Religion = "";
            ParentsNamesF = "";
            OccupationF = "";
            QualificationF = "";
            ParentsNamesM = "";
            OccupationM = "";
            QualificationM = "";
            AnnualIncome = "";
            PresentClass = "";
            Address = "";
            Address1 = "";
            City = "";
            State = "";
            PostalCode = "";
            PermAddress = "";
            PermAddress1 = "";
            PermCity = "";
            PermState = "";
            PermPostalCode = "";
            StdCategory = "";
            ClassAdmittedTo = "";
            PrevSchool = "";
            StdSession = "";
            StdStatus = 0;
            BusRoute = "";
            Color_House = "";
            Notes = "";
            PermAilment = "";
            BloodGroup = "";
            Height = "";
            Weight = "";
            Teeth = "";
            VisionL = "";
            VisionR = "";
            OralHygiene = "";
            SplAilment = "";
            PermIdentification = "";
            Payable = 0;
            Dues = 0;
            PresentRollNo = 0;
            Testimonials = "";
            Hphone = "";
            Mphone = "";
            DateOfFeeApp = 0;
            DateOfAdmission = 0;
            Section = "";
            Nationality = "";
            Lgname = "";
            Lgaddress1 = "";
            Lgaddress2 = "";
            Lgphone = "";
            ConPhone = "";
            BoardNo = "";
            ModTime = DateTime.Now;
            Dormant = 0;
            LoginName = "";
            CTerminal = "";
            UniReg = 0;
            DBid = 0;
            StdGenCategory = "";
            RouteMode = "";
            Aadhar = "";
            EmailAddress = "";
            StdActLst = Enumerable.Empty<Profile_Activity>();
            StdAttLst = Enumerable.Empty<Profile_Attendance>();
            StdRecLst = Enumerable.Empty<Profile_Receipt>();
            //   //  
        }

        public static explicit operator Students(Task<IActionResult> v)
        {
            throw new NotImplementedException();
        }

        [Key]
        [ScaffoldColumn(false)]
        public int StdId { get; set; }

        [DisplayName("Registration/Admission Number")]
        public int RegNumber { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Students Name")]
        public string StdName { get; set; }

        [DisplayName("Gender")]
        public string Sex { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [DisplayName("Religion")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [DisplayName("Father's Name")]
        public string ParentsNamesF { get; set; }
        [DisplayName("Father's Occupation")]
        public string OccupationF { get; set; }
        [DisplayName("Father's Qualification")]
        public string QualificationF { get; set; }
        //[Required(ErrorMessage = "Mother's Name is required")]
        [DisplayName("Mother's Name")]
        public string ParentsNamesM { get; set; }
        [DisplayName("Mother's Occupation")]
        public string OccupationM { get; set; }
        [DisplayName("Mother's Qualification")]
        public string QualificationM { get; set; }
        [DisplayName("Annual Income")]
        public string AnnualIncome { get; set; }

        [Required(ErrorMessage = "Present Class is required")]
        [DisplayName("Class Admitted To")]
        public string PresentClass { get; set; }

        [Display(Name = "House No.")]
        [UIHint("Fill House No.")]
        public string Address { get; set; }
        [Display(Name = "Mohallah/Locality")]
        [UIHint(" Fill Mohallah/Locality ")]
        public string Address1 { get; set; }
        [Display(Name = "City/District ")]
        [UIHint("  Fill City/District ")]
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Postal Code ")]
        [UIHint("  Fill postal_code ")]
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
        public int StdStatus { get; set; }
        //public byte[] Photo { get; set; }
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
        public string Weight { get; set; }
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
        public double Payable { get; set; }
        [ScaffoldColumn(false)]
        public double Dues { get; set; }
        public int PresentRollNo { get; set; }
        [ScaffoldColumn(false)]
        public string Testimonials { get; set; }
        public string Hphone { get; set; }
        [Display(Name = "Permanent Mobile Number")]
        [UIHint("  Fill Permanent Mobile Number ")]
        public string Mphone { get; set; }
        [ScaffoldColumn(false)]
        public double DateOfFeeApp { get; set; }
        [ScaffoldColumn(false)]
        public double DateOfAdmission { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        [ScaffoldColumn(false)]
        public int UniReg { get; set; }
        [ScaffoldColumn(false)]
        public int DBid { get; set; }
        [Display(Name = "Student Category")]
        public string StdGenCategory { get; set; }
        [ScaffoldColumn(false)]
        public string AdmissionNo { get; set; }
        [ScaffoldColumn(false)]
        public string RouteMode { get; set; }
        [ScaffoldColumn(false)]
        public string BoardRollCode { get; set; }
        [Display(Name = "Aadhar Number")]
        public string Aadhar { get; set; }
        [Display(Name = "Photo")]
        //[MaxLength(150000, ErrorMessage = "Image Size Must be less than 100 kb")]
        //[MinLength(10000, ErrorMessage = "Image Size Must be larger than 10 kb")]
        public byte[] ImajePict { get; set; }
        public string ImgDataURL { get; set; }

        public IEnumerable<Profile_Activity> StdActLst { get; set; }
        public IEnumerable<Profile_Attendance> StdAttLst { get; set; }
        public IEnumerable<Profile_Receipt> StdRecLst { get; set; }


    }
    public partial class StudentsEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Students Value { get; set; }
    }
}
