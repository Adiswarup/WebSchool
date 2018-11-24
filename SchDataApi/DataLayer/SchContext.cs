using Microsoft.EntityFrameworkCore;
using SchMod.Models.Active;
using SchMod.Models.Basics;
using SchMod.Models.Communication;
using SchMod.Models.Convey;
using SchMod.Models.Exams;
using SchMod.Models.General;
using SchMod.Models.Marx;
using SchMod.Models.StdFees;
using SchMod.Models.Studs;
using SchMod.ViewModels.StdFees;

namespace SchDataApi.DataLayer
{
    public partial class SchContext : DbContext
    {
        public virtual DbSet<AcaSession> AcaSession { get; set; }
        public virtual DbSet<AccountHead> AccountHead { get; set; }
        public virtual DbSet<ActInRc> ActInRc { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityGrades> ActivityGrades { get; set; }
        public virtual DbSet<ActivityGroup> ActivityGroup { get; set; }
        public virtual DbSet<Appoints> Appoints { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AwareNames> AwareNames { get; set; }
        public virtual DbSet<Awareness> Awareness { get; set; }
        //public virtual DbSet<CashDenom> CashDenom { get; set; }
        public virtual DbSet<CharecterCertificate> CharecterCertificate { get; set; }
        //public virtual DbSet<ChqDrafts> ChqDrafts { get; set; }
        public virtual DbSet<Circuit> Circuit { get; set; }
        public virtual DbSet<Clss> Clss { get; set; }
        public virtual DbSet<ConSmss> ConSmss { get; set; }
        public virtual DbSet<ConfigExam> ConfigExam { get; set; }
        public virtual DbSet<Conveyance> Conveyance { get; set; }
        public virtual DbSet<DynaFee> DynaFee { get; set; }
        public virtual DbSet<ExamSub> ExamSub { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Fcaption> Fcaption { get; set; }
        public virtual DbSet<FeeDuesSmsdates> FeeDuesSmsdates { get; set; }
        public virtual DbSet<FieldOrder> FieldOrder { get; set; }
        public virtual DbSet<Holidays> Holidays { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<LateConFee> LateConFee { get; set; }
        public virtual DbSet<LeaveDefinition> LeaveDefinition { get; set; }
        public virtual DbSet<LetterTemplates> LetterTemplates { get; set; }
        public virtual DbSet<LoginDetails> LoginDetails { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Misc> Misc { get; set; }
        public virtual DbSet<PermissionT> PermissionT { get; set; }
        public virtual DbSet<PosTrn> PosTrn { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptDetails> ReceiptDetails { get; set; }
        public virtual DbSet<ReportCard> ReportCard { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<SchLeaveDetails> SchLeaveDetails { get; set; }
        public virtual DbSet<Smsemails> Smsemails { get; set; }
        public virtual DbSet<StdCat> StdCat { get; set; }
        public virtual DbSet<StdFeeCat> StdFeeCat { get; set; }
        public virtual DbSet<StdFee> StdFee { get; set; }
        public virtual DbSet<StdHouse> StdHouse { get; set; }
        public virtual DbSet<StdSub> StdSub { get; set; }
        public virtual DbSet<Stops> Stops { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<SubjectSubs> SubjectSubs { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<SubjectsRel> SubjectsRel { get; set; }
        public virtual DbSet<TcData> TcData { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TrMgDel> TrMgDel { get; set; }
        public virtual DbSet<TrStdClassCat> TrStdClassCat { get; set; }
        public virtual DbSet<TransActivity> TransActivity { get; set; }
        public virtual DbSet<VehicleDescription> VehicleDescription { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }
        public virtual DbSet<VonRt> VonRt { get; set; }
        //public virtual DbSet<WaiverCaption> WaiverCaption { get; set; }
        public virtual DbSet<FeeForm> FeeForm { get; set; }
        public virtual DbSet<FeeSumm> FeeSumm { get; set; }

        public SchContext(DbContextOptions<SchContext> options)
            : base(options)
        {
        }

        // Unable to generate entity type for table 'dbo.Routine'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.sysdiagrams'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Data Source=192.168.10.5\\SQLEX17;Initial Catalog=dbSchool_Web;Persist Security Info=True;User ID=sa;password = harsh@00");
            optionsBuilder.UseSqlServer(@"Data Source=.\SQL17;Initial Catalog=dbSchool_Web;Persist Security Info=True;User ID=sa;password = harsh@00");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcaSession>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_AcaSession");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.Ssdid)
                    .HasColumnName("SSDID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountHead>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("AccId");

                entity.Property(e => e.AccName).HasMaxLength(50);

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<ActInRc>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_ActInRC");

                entity.ToTable("ActInRC");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ActGrId).HasColumnName("ActGrID");

                entity.Property(e => e.ActGrRcid)
                    .HasColumnName("ActGrRCID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.SlRc).HasColumnName("SlRC");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Activity");

                entity.HasIndex(e => new { e.Dormant, e.ActivityId })
                    .HasName("ActivityID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ActGroupId).HasColumnName("ActGroupID");

                entity.Property(e => e.ActivityGroup).HasMaxLength(255);

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ActivityID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActivityName).HasMaxLength(255);

                entity.Property(e => e.ActivityRemarks).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.SendEmail).HasColumnName("SendEMail");

                entity.Property(e => e.SendSms).HasColumnName("SendSMS");
            });

            modelBuilder.Entity<ActivityGrades>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_ActivityGrades");

                entity.HasIndex(e => new { e.Dormant, e.ActSession, e.ActClss, e.ActGroupId, e.UniReg })
                    .HasName("RegNum");

                entity.HasIndex(e => new { e.ActExamName, e.StdActMarks, e.StdActGrades, e.ActSession, e.DesIndicators, e.ActClss, e.Dormant, e.UniReg, e.ActGroupId, e.DBid })
                    .HasName("_dta_index_ActivityGrades_7_1577772678__K5_K13_K17_K10_K21_6_7_8_9_11");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ActClss).HasMaxLength(255);

                entity.Property(e => e.ActExamName).HasMaxLength(255);

                entity.Property(e => e.ActGroupId).HasColumnName("ActGroupID");

                entity.Property(e => e.ActSession).HasMaxLength(255);

                entity.Property(e => e.ActivityGrName).HasMaxLength(255);

                entity.Property(e => e.ActivityGradeId)
                    .HasColumnName("ActivityGradeID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.CdesIndicators).HasColumnName("CDesIndicators");

                entity.Property(e => e.CstdActGrades).HasColumnName("CStdActGrades");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.StdActGrades).HasMaxLength(255);

            });

            modelBuilder.Entity<ActivityGroup>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("AutoID");

                entity.HasIndex(e => e.ActGroupId)
                    .HasName("ActGroupID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ActGroupId)
                    .HasColumnName("ActGroupID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActGroupMotive).HasMaxLength(255);

                entity.Property(e => e.ActGroupName).HasMaxLength(255);

                entity.Property(e => e.ActGroupReportCard).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasColumnType("nchar(255)");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.IsReflectedInReportCard).HasColumnName("IsReflectedInReportCArd");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Appoints>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Appoints");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AppPriorty).HasColumnType("nchar(10)");

                entity.Property(e => e.AppStatus).HasColumnType("nchar(10)");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Attendance");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AcaSession).HasMaxLength(50);

                entity.Property(e => e.AttId)
                    .HasColumnName("AttID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);
            });

            modelBuilder.Entity<AwareNames>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_AwareNames");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AwareName).HasMaxLength(255);

                entity.Property(e => e.AwareNameId)
                    .HasColumnName("AwareNameID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AwareNameMotive).HasMaxLength(255);

                entity.Property(e => e.AwareNameReportCard).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.IsReflectedInReportCard).HasColumnName("IsReflectedInReportCArd");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Awareness>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Awareness");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AwareId)
                    .HasColumnName("AwareID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AwareNameId).HasColumnName("AwareNameID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);
            });

            //modelBuilder.Entity<CashDenom>(entity =>
            //{
            //    entity.HasKey(e => e.AutoId)
            //        .HasName("PK__CashDenom__75586032");

            //    entity.HasIndex(e => new { e.AutoId, e.CdenoId })
            //        .HasName("_dta_index_CashDenom_7_1952726009__K2_1");

            //    entity.HasIndex(e => new { e.AutoId, e.AcaSession, e.ReceiptNo, e.DBid })
            //        .HasName("_dta_index_CashDenom_7_1952726009__K4_K13_1_14");

            //    entity.Property(e => e.AutoId).HasColumnName("AutoID");

            //    entity.Property(e => e.CTerminal)
            //        .HasColumnName("cTerminal")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CdenoId)
            //        .HasColumnName("CDenoID")
            //        .HasDefaultValueSql("0");

            //    entity.Property(e => e.DBid)
            //        .HasColumnName("dBID")
            //        .HasDefaultValueSql("0");

            //    entity.Property(e => e.LoginName).HasMaxLength(255);
            //});

            modelBuilder.Entity<CharecterCertificate>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_CharecterCertificate");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Concession).HasMaxLength(255);

                entity.Property(e => e.Conduct).HasMaxLength(255);

                entity.Property(e => e.CurricularActivities).HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.DuesPaid).HasMaxLength(255);

                entity.Property(e => e.Foiled).HasMaxLength(255);

                entity.Property(e => e.LastExam).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(255);

                entity.Property(e => e.NccGg).HasMaxLength(255);

                entity.Property(e => e.Qualified).HasMaxLength(255);

                entity.Property(e => e.ReasonOfTc).HasColumnName("ReasonOfTC");

                entity.Property(e => e.ScSt).HasColumnName("ScST");

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.Subject1).HasMaxLength(255);

                entity.Property(e => e.Subject2).HasMaxLength(255);

                entity.Property(e => e.Subject3).HasMaxLength(255);

                entity.Property(e => e.Subject4).HasMaxLength(255);

                entity.Property(e => e.Subject5).HasMaxLength(255);

                entity.Property(e => e.Subject6).HasMaxLength(255);

                entity.Property(e => e.Subject7).HasMaxLength(255);

                entity.Property(e => e.TcFile).HasColumnType("image");

                entity.Property(e => e.TcId)
                    .HasColumnName("TcID")
                    .HasDefaultValueSql("0");
            });

            //modelBuilder.Entity<ChqDrafts>(entity =>
            //{
            //    entity.HasKey(e => e.AutoId)
            //        .HasName("PK__ChqDrafts__6521F869");

            //    entity.HasIndex(e => new { e.IssuedBy, e.Dormant, e.DBid })
            //        .HasName("_dta_index_ChqDrafts_7_1680725040__K14_K17_6");

            //    entity.HasIndex(e => new { e.AutoId, e.AcaSession, e.ReceiptNo, e.DBid })
            //        .HasName("_dta_index_ChqDrafts_7_1680725040__K4_K17_1_18");

            //    entity.Property(e => e.AutoId).HasColumnName("AutoID");

            //    entity.Property(e => e.CTerminal)
            //        .HasColumnName("cTerminal")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ChequeId)
            //        .HasColumnName("ChequeID")
            //        .HasDefaultValueSql("0");

            //    entity.Property(e => e.DBid)
            //        .HasColumnName("dBID")
            //        .HasDefaultValueSql("0");

            //    entity.Property(e => e.DepositedIn).HasColumnName("DepositedIN");

            //    entity.Property(e => e.LoginName).HasMaxLength(255);
            //});

            modelBuilder.Entity<Circuit>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaCircuit_PK");

                entity.HasIndex(e => e.CircuitId)
                    .HasName("CircuitID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.CircuitId)
                    .HasColumnName("CircuitID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CircuitName).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.Stoppage).HasMaxLength(255);
            });

            modelBuilder.Entity<Clss>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Clss");

                entity.HasIndex(e => new { e.AcaSession, e.ClsName })
                    .HasName("Cls");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AcaSession).HasMaxLength(50);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.ClassTeacher).HasMaxLength(255);

                entity.Property(e => e.ClsId).HasDefaultValueSql("0");

                entity.Property(e => e.ClsName).HasMaxLength(255);

                entity.Property(e => e.ClsPerDay)
                    .HasColumnName("Cls_Per_Day")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ClsSat)
                    .HasColumnName("Cls_Sat")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.Room).HasMaxLength(255);

                entity.Property(e => e.StdStrength).HasDefaultValueSql("0");

                entity.Property(e => e.TeachId).HasColumnName("TeachID");
            });

            modelBuilder.Entity<ConSmss>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__ConSMSs__2CDD9F46");

                entity.ToTable("ConSMSs");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.CsmsdateFduesId)
                    .HasColumnName("CSMSDateFDuesID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.StdCategory).HasMaxLength(255);
            });

            modelBuilder.Entity<ConfigExam>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaConfigExam_PK");

                entity.HasIndex(e => e.ConExamId)
                    .HasName("ConExamID");

                entity.HasIndex(e => new { e.Clss, e.ExamFor, e.ExamFrom, e.Subj, e.MarksPc, e.Dormant, e.DBid, e.Ssession })
                    .HasName("_dta_index_ConfigExam_7_1115151018__K11_K14_K3_4_5_6_7_8");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(255);

                entity.Property(e => e.ConExamId)
                    .HasColumnName("ConExamID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.ExamFor).HasMaxLength(255);

                entity.Property(e => e.ExamFrom).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.MarksPc).HasColumnName("MarksPC");

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.Ssession)
                    .HasColumnName("SSession")
                    .HasMaxLength(255);

                entity.Property(e => e.Subj).HasMaxLength(255);
            });

            modelBuilder.Entity<Conveyance>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("AutoID");

                entity.HasIndex(e => e.ConId)
                    .HasName("ConID");

                entity.HasIndex(e => e.RegNum)
                    .HasName("StdId");

                entity.HasIndex(e => e.RouteId)
                    .HasName("RouteID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.ConId)
                    .HasColumnName("ConID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DateFrom).HasDefaultValueSql("0");

                entity.Property(e => e.DateTo).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.RegNum).HasDefaultValueSql("0");

                entity.Property(e => e.RouteId)
                    .HasColumnName("RouteID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StopId)
                    .HasColumnName("StopID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<DynaFee>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_DynaFee");

                entity.HasIndex(e => e.ClsFeeId)
                    .HasName("ClsFeeId");

                entity.HasIndex(e => new { e.ForMonth, e.FeeCaption, e.Dormant, e.DBid, e.ForClass, e.SessionName })
                    .HasName("_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_5_7");

                entity.HasIndex(e => new { e.AutoId, e.FeeCaption, e.StdCategory, e.Dormant, e.DBid, e.ForClass, e.SessionName, e.ForMonth })
                    .HasName("_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K5_1_7_10");

                entity.HasIndex(e => new { e.FeeCaption, e.Dormant, e.DBid, e.ForClass, e.ForMonth, e.StdCategory, e.AutoId, e.FeeNo })
                    .HasName("_dta_index_DynaFee_7_1225771424__K12_K17_K9_K5_K10_K1_K3_7");

                entity.HasIndex(e => new { e.StdCategory, e.AutoId, e.FeeNo, e.Caption, e.Amount, e.Dormant, e.DBid, e.ForClass, e.SessionName, e.ForMonth })
                    .HasName("_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K5_1_3_4_6_10");

                entity.HasIndex(e => new { e.StdCategory, e.FeeNo, e.Caption, e.Amount, e.FeeCaption, e.Dormant, e.DBid, e.ForClass, e.SessionName, e.AutoId, e.ForMonth })
                    .HasName("_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K1_K5_3_4_6_7_10");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.Amount).HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Caption).HasMaxLength(255);

                entity.Property(e => e.ClsFeeId).HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.FeeNo).HasDefaultValueSql("0");

                entity.Property(e => e.ForClass).HasMaxLength(50);

                entity.Property(e => e.ForMonth).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.PayByDate).HasDefaultValueSql("0");

                entity.Property(e => e.SessionName).HasMaxLength(255);

                entity.Property(e => e.StdCategory).HasMaxLength(255);
            });

            modelBuilder.Entity<ExamSub>(entity =>
            {
                entity.HasKey(e => e.ExamSubAutoId)
                    .HasName("PK_ExamSub");

                entity.HasIndex(e => new { e.Dormant, e.DBid, e.ExamName })
                    .HasName("_dta_index_ExamSub_7_365244356__K29_K34_K3");

                entity.HasIndex(e => new { e.Ssession, e.Clss, e.Dormant, e.DBid })
                    .HasName("_dta_index_ExamSub_c_7_365244356__K5_K4_K29_K34");

                entity.HasIndex(e => new { e.Ssession, e.Clss, e.ExamName, e.SubName })
                    .HasName("ExamSelect");

                entity.Property(e => e.ExamSubAutoId).HasColumnName("ExamSubAutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DoevalutionFrom).HasColumnName("DOEvalutionFrom");

                entity.Property(e => e.DoevalutionTo).HasColumnName("DOEvalutionTo");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.ExamName).HasMaxLength(50);

                entity.Property(e => e.ExamSubId)
                    .HasColumnName("ExamSubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fmassign)
                    .HasColumnName("FMAssign")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fmoral)
                    .HasColumnName("FMOral")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fmpract)
                    .HasColumnName("FMPract")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fmtheory)
                    .HasColumnName("FMTheory")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FullMarks).HasDefaultValueSql("0");

                entity.Property(e => e.IsAssign).HasDefaultValueSql("0");

                entity.Property(e => e.IsElective).HasDefaultValueSql("0");

                entity.Property(e => e.IsOral).HasDefaultValueSql("0");

                entity.Property(e => e.IsPract).HasDefaultValueSql("0");

                entity.Property(e => e.IsTheory).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.PassMarks).HasDefaultValueSql("0");

                entity.Property(e => e.Pmassign)
                    .HasColumnName("PMAssign")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pmoral)
                    .HasColumnName("PMOral")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pmpract)
                    .HasColumnName("PMPract")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pmtheory)
                    .HasColumnName("PMTheory")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ssession).HasMaxLength(255);

                entity.Property(e => e.SubExamMarksDirty).HasDefaultValueSql("0");

                entity.Property(e => e.SubExamMarksLocked).HasDefaultValueSql("0");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubName).HasMaxLength(50);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId)
                    .HasName("aaaaaExpenses_PK");

                entity.HasIndex(e => e.DateSubmitted)
                    .HasName("DateSubmitted");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeID");

                entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

                entity.Property(e => e.AdvanceAmount).HasColumnType("money");

                entity.Property(e => e.AmountSpent).HasColumnType("money");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DatePurchased).HasColumnType("datetime");

                entity.Property(e => e.DateSubmitted).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExpenseType).HasMaxLength(50);

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PurposeofExpense).HasMaxLength(255);

                entity.Property(e => e.UpsizeTs)
                    .HasColumnName("upsize_ts")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Fcaption>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_FCaption");

                entity.ToTable("FCaption");

                entity.HasIndex(e => e.FeeNameId)
                    .HasName("FeeNameId");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FeeCaption).HasMaxLength(50);

                entity.Property(e => e.FeeDuration).HasMaxLength(255);

                entity.Property(e => e.FeeNameId).HasDefaultValueSql("0");

                entity.Property(e => e.FeeType).HasMaxLength(50);

                entity.Property(e => e.LoginName).HasMaxLength(50);
            });

            modelBuilder.Entity<FeeDuesSmsdates>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__FeeDuesSMSDates__3FF073BA");

                entity.ToTable("FeeDuesSMSDates");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fdsdid)
                    .HasColumnName("FDSDId")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.StdCategory).HasMaxLength(255);
            });

            modelBuilder.Entity<FieldOrder>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__FieldOrder__00CA12DE");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");
            });

            modelBuilder.Entity<Holidays>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Holidays");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AcaSession).HasMaxLength(50);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Hdate).HasColumnName("HDate");

                entity.Property(e => e.Hid)
                    .HasColumnName("HID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Htype).HasColumnName("HType");

                entity.Property(e => e.LoginName).HasMaxLength(50);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Images");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ImageId)
                    .HasColumnName("ImageID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);
            });

            modelBuilder.Entity<LateConFee>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_LateConFee");

                entity.HasIndex(e => new { e.Amount, e.ForClass, e.SessionName, e.ForMonth, e.StdCategory, e.DBid, e.Dormant, e.LateDate })
                    .HasName("_dta_index_LateConFee_7_1931153925__K10_K3_K8_K15_K12_K4_5_6");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.Clfid)
                    .HasColumnName("CLFId")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.StdCategory).HasMaxLength(255);
            });

            modelBuilder.Entity<LeaveDefinition>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("AutoID");

                entity.HasIndex(e => e.LeaveTypeId)
                    .HasName("LeaveTypeID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.CanbeCarriedOn).HasDefaultValueSql("0");

                entity.Property(e => e.CarryoverLimit).HasDefaultValueSql("0");

                entity.Property(e => e.DateStamp).HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.IsPaidLeave).HasDefaultValueSql("0");

                entity.Property(e => e.IsSchLeave).HasDefaultValueSql("0");

                entity.Property(e => e.LeaveType).HasMaxLength(255);

                entity.Property(e => e.LeaveTypeId)
                    .HasColumnName("LeaveTypeID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.UpsizeTs)
                    .HasColumnName("upsize_ts")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<LetterTemplates>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_LetterTemplates");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LetterTemplate).HasColumnType("ntext");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.TemplateId)
                    .HasColumnName("TemplateID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TemplateName).HasMaxLength(255);
            });

            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_LoginDetails");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(255);

                entity.Property(e => e.HintAnswer).HasMaxLength(255);

                entity.Property(e => e.HintQuestion).HasMaxLength(255);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.LoginNameCh).HasMaxLength(50);

                entity.Property(e => e.LoginPassword).HasMaxLength(255);

                entity.Property(e => e.SpecialDetail).HasMaxLength(255);
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasKey(e => e.MkAutoID)
                    .HasName("PK_Marks");

                entity.HasIndex(e => new { e.MSession, e.MClss, e.ExamName, e.SubName, e.Dormant })
                    .HasName("MKSInd");

                entity.HasIndex(e => new { e.MSession, e.MClss, e.ExamName, e.SubName, e.UniReg, e.Dormant, e.dBID })
                    .HasName("_dta_index_Marks_c_7_2126630619__K15_K3_K5_K4_K22_K18_K24");

                entity.Property(e => e.MkAutoID).HasColumnName("MkAutoID");

                entity.Property(e => e.AsgnMarks).HasDefaultValueSql("0");

                entity.Property(e => e.cTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.dBID)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExamName).HasMaxLength(50);

                entity.Property(e => e.FMarks).HasColumnName("FMarks");

                entity.Property(e => e.Grades).HasMaxLength(255);

                entity.Property(e => e.GradesVal).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.MClss)
                    .HasColumnName("MClss")
                    .HasMaxLength(50);

                entity.Property(e => e.MkID)
                    .HasColumnName("MkID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MSession)
                    .HasColumnName("MSession")
                    .HasMaxLength(255);

                entity.Property(e => e.OrMarks).HasDefaultValueSql("0");

                entity.Property(e => e.PracMarks).HasDefaultValueSql("0");

                //entity.Property(e => e.RecMode).HasDefaultValueSql("0");

                entity.Property(e => e.RegNum).HasDefaultValueSql("0");

                entity.Property(e => e.ScaleUpGrade).HasMaxLength(255);

                entity.Property(e => e.StdGrades).HasMaxLength(50);

                entity.Property(e => e.SubName).HasMaxLength(50);

                entity.Property(e => e.ThMarks).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Misc>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Misc");

                entity.HasIndex(e => e.MiscId)
                    .HasName("MiscID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AcaSession).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Curriculum).HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(255);

                entity.Property(e => e.Emedium)
                    .HasColumnName("EMedium")
                    .HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.MiscId)
                    .HasColumnName("MiscID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PcpName).HasMaxLength(255);

                entity.Property(e => e.PcpPhone).HasMaxLength(255);

                entity.Property(e => e.RecMode).HasDefaultValueSql("0");

                entity.Property(e => e.SchAddress).HasMaxLength(255);

                entity.Property(e => e.SchMotto).HasMaxLength(255);

                entity.Property(e => e.SchName).HasMaxLength(255);

                entity.Property(e => e.SchPhone).HasMaxLength(255);

                entity.Property(e => e.SessionStartDate).HasDefaultValueSql("0");

                entity.Property(e => e.WebSite).HasMaxLength(255);
            });

            modelBuilder.Entity<PermissionT>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__PermissionT__7A1D154F");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PermId)
                    .HasColumnName("PermID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PosTrn>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_PosTrn");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.PosTrnId)
                    .HasColumnName("PosTrnID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Receipt_1");

                entity.HasIndex(e => e.AmountPaid)
                    .HasName("AmountPAid");

                entity.HasIndex(e => e.PaidAt)
                    .HasName("_dta_index_Receipt_7_199671759__K22");

                entity.HasIndex(e => e.RecId)
                    .HasName("RecID");

                entity.HasIndex(e => e.ReceiptNo)
                    .HasName("ReceiptNo");

                entity.HasIndex(e => new { e.AcaSession, e.ReceiptNo })
                    .HasName("_dta_index_Receipt_7_199671759__K3_26");

                entity.HasIndex(e => new { e.Dormant, e.LoginName })
                    .HasName("_dta_index_Receipt_7_199671759__K17_K18");

                entity.HasIndex(e => new { e.AcaSession, e.ReceiptDate, e.Dormant, e.ReceiptNo })
                    .HasName("_dta_index_Receipt_7_199671759__K5_K17_K3_26");

                entity.HasIndex(e => new { e.AcaSession, e.UniReg, e.ReceiptNo, e.ForPeriod, e.Dormant, e.DBid })
                    .HasName("_dta_index_Receipt_7_199671759__K6_K3_K8_K17_K21_26");

                entity.HasIndex(e => new { e.AmountPaid, e.PaidAt, e.FeeHeading, e.AcaSession, e.ReceiptDate, e.AmountPayable, e.UniReg, e.ReceiptNo, e.Dormant, e.IsDuesClearance, e.ForPeriod, e.DBid })
                    .HasName("_dta_index_Receipt_7_199671759__K6_K3_K17_K11_K8_K21_5_9_10_22_24_26");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AmountPaid).HasDefaultValueSql("0");

                entity.Property(e => e.AmountPayable).HasDefaultValueSql("0");

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.ChqDated).HasMaxLength(50);

                entity.Property(e => e.ChqNumber).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ForPeriod).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.PaidAt).HasColumnType("nchar(50)");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.RecId)
                    .HasColumnName("RecID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReceiptDate).HasDefaultValueSql("0");

                entity.Property(e => e.ReceiptNo).HasDefaultValueSql("0");

                entity.Property(e => e.RegNo).HasDefaultValueSql("0");

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.SName).HasColumnName("sName");
            });

            modelBuilder.Entity<ReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_ReceiptDetails");

                entity.HasIndex(e => e.AmountPaid)
                    .HasName("AmountPaid");

                entity.HasIndex(e => e.RecId)
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K2");

                entity.HasIndex(e => e.RegNo)
                    .HasName("StdID");

                entity.HasIndex(e => new { e.Dormant, e.ReceiptNo, e.FeenWahead })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K11_K3_K8");

                entity.HasIndex(e => new { e.AutoId, e.Dormant, e.AcaSession, e.DBid, e.ReceiptNo })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K17_K3_1_11_18");

                entity.HasIndex(e => new { e.AcaSession, e.DBid, e.ReceiptNo, e.Dormant, e.ForPeriod, e.FeenWahead })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K17_K3_K11_K7_K8_18");

                entity.HasIndex(e => new { e.AcaSession, e.FeenWahead, e.ReceiptNo, e.ForPeriod, e.Dormant, e.DBid })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K8_K3_K7_K11_K17_18");

                entity.HasIndex(e => new { e.AcaSession, e.ForPeriod, e.FeenWahead, e.ReceiptNo, e.Dormant, e.DBid })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K7_K8_K3_K11_K17_18");

                entity.HasIndex(e => new { e.AcaSession, e.FeenWahead, e.ReceiptNo, e.ForPeriod, e.DBid, e.Dormant, e.UniReg })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K8_K3_K7_K17_K11_K16_18");

                entity.HasIndex(e => new { e.AcaSession, e.FeenWahead, e.UniReg, e.ReceiptNo, e.ForPeriod, e.Dormant, e.DBid })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K8_K16_K3_K7_K11_K17_18");

                entity.HasIndex(e => new { e.AcaSession, e.UniReg, e.ReceiptNo, e.ForPeriod, e.DBid, e.Dormant, e.FeenWahead })
                    .HasName("_dta_index_ReceiptDetails_7_343672272__K16_K3_K7_K17_K11_K8_18");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.BillNo).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FeenWahead)
                    .HasColumnName("FEEnWAHead")
                    .HasMaxLength(255);

                entity.Property(e => e.ForPeriod).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.RecId)
                    .HasColumnName("RecID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RemarkDetails).HasMaxLength(255);
            });

            modelBuilder.Entity<ReportCard>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_ReportCard");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.RcClass).HasMaxLength(255);

                entity.Property(e => e.RcExam).HasMaxLength(255);

                entity.Property(e => e.RcId).HasDefaultValueSql("0");

                entity.Property(e => e.RcSession).HasMaxLength(255);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Roles__5C8CB268");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Routes");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.RouteId)
                    .HasColumnName("RouteID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RouteNo).HasColumnType("nchar(10)");

                entity.Property(e => e.StopTimeFro).HasMaxLength(50);

                entity.Property(e => e.StopTimeTo).HasMaxLength(50);

                entity.Property(e => e.StopsId).HasColumnName("StopsID");
            });

            modelBuilder.Entity<SchLeaveDetails>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("AutoId");

                entity.HasIndex(e => e.BranchId)
                    .HasName("EmpID");

                entity.HasIndex(e => e.SchLeaveId)
                    .HasName("CompLeaveID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.BranchId)
                    .HasColumnName("BranchID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DateStamp).HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.SchLeaveDate).HasDefaultValueSql("0");

                entity.Property(e => e.SchLeaveId)
                    .HasColumnName("SchLeaveID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SchLeaveType).HasMaxLength(255);
            });

            modelBuilder.Entity<Smsemails>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__SMSemails__4F32B74A");

                entity.ToTable("SMSemails");

                entity.HasIndex(e => new { e.AutoId, e.SmsemailId })
                    .HasName("_dta_index_SMSemails_7_1312723729__K2_1");

                entity.HasIndex(e => new { e.AutoId, e.Dormant, e.Status, e.CheckDate })
                    .HasName("_dta_index_SMSemails_7_1312723729__K19_K8_K15_1");

                entity.HasIndex(e => new { e.Subject, e.Email, e.SendorRecieved, e.CheckDate, e.FeeCaption, e.SessionName, e.SmsemailId, e.RegNum, e.UniReg, e.Text, e.TFile, e.DBid, e.Status, e.Dormant, e.SmsorEmail, e.MobNo, e.ModTime })
                    .HasName("_dta_index_SMSemails_7_1312723729__K8_K19_K13_K10_K20_2_4_5_6_7_9_11_12_14_15_16_17");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Fdsdid)
                    .HasColumnName("FDSDId")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.MobNo).HasMaxLength(50);

                entity.Property(e => e.SessionName).HasMaxLength(50);

                entity.Property(e => e.SmsemailId)
                    .HasColumnName("SMSEmailID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SmsorEmail).HasColumnName("SMSorEmail");

                entity.Property(e => e.TFile).HasColumnName("tFile");
            });

            modelBuilder.Entity<StdCat>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_stdCat");

                entity.ToTable("stdCat");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.StdCatId)
                    .HasColumnName("StdCatID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StdCategory).HasMaxLength(255);
            });

            modelBuilder.Entity<StdFee>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_StdFee");

                entity.HasIndex(e => e.StdFeeId)
                    .HasName("ClsFeeId");

                entity.HasIndex(e => new { e.AutoId, e.Dormant, e.ForMonth, e.UniReg, e.Caption })
                    .HasName("_dta_index_StdFee_7_727673640__K7_K5_K12_K4_1");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.Amount).HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Caption).HasMaxLength(50);

                entity.Property(e => e.ChequeId)
                    .HasColumnName("ChequeID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ForMonth).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.RegNo).HasDefaultValueSql("0");

                entity.Property(e => e.StdFeeId)
                    .HasColumnName("stdFeeId")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<StdHouse>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_StdHouse");

                entity.HasIndex(e => e.StdHouseId)
                    .HasName("StdCatID")
                    .IsUnique();

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.StHouse)
                    .HasColumnName("StdHouse")
                    .HasMaxLength(255);

                entity.Property(e => e.StdHouseId)
                    .HasColumnName("StdHouseID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<StdSub>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("StdSubAutoID");

                entity.HasIndex(e => e.RollNum)
                    .HasName("RollNum");

                entity.HasIndex(e => e.StdId)
                    .HasName("StdID");

                entity.HasIndex(e => e.StdSubId)
                    .HasName("StdSubID");

                entity.HasIndex(e => e.SubId)
                    .HasName("SubID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss)
                    .HasColumnName("clss")
                    .HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.RollNum).HasDefaultValueSql("0");

                entity.Property(e => e.SessionA).HasMaxLength(255);

                entity.Property(e => e.StdId)
                    .HasColumnName("StdID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StdName).HasMaxLength(255);

                entity.Property(e => e.StdSubId)
                    .HasColumnName("StdSubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubName).HasMaxLength(50);
            });

            modelBuilder.Entity<Stops>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Stops");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.circuit).HasMaxLength(255);

                entity.Property(e => e.drptext).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.monthlyFare).HasDefaultValueSql("0");

                entity.Property(e => e.stopId)
                    .HasColumnName("StopID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.stops1)
                    .HasColumnName("Stops")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StdId)
                    .HasName("PK_Students");

                entity.HasIndex(e => new { e.Dormant, e.BloodGroup })
                    .HasName("_dta_index_Students_7_873770170__K64_K38");

                entity.HasIndex(e => new { e.Dormant, e.OccupationF })
                    .HasName("_dta_index_Students_7_873770170__K64_K10");

                entity.HasIndex(e => new { e.Dormant, e.OccupationM })
                    .HasName("_dta_index_Students_7_873770170__K64_K13");

                entity.HasIndex(e => new { e.Dormant, e.PrevSchool })
                    .HasName("_dta_index_Students_7_873770170__K64_K29");

                entity.HasIndex(e => new { e.Dormant, e.QualificationF })
                    .HasName("_dta_index_Students_7_873770170__K64_K11");

                entity.HasIndex(e => new { e.Dormant, e.QualificationM })
                    .HasName("_dta_index_Students_7_873770170__K64_K14");

                entity.HasIndex(e => new { e.Dormant, e.Religion })
                    .HasName("_dta_index_Students_7_873770170__K64_K8");

                entity.HasIndex(e => new { e.StdGenCategory, e.Dormant })
                    .HasName("_dta_index_Students_7_873770170__K64_69");

                entity.HasIndex(e => new { e.RegNumber, e.Dormant, e.StdStatus })
                    .HasName("_dta_index_Students_7_873770170__K64_K31_2");

                entity.HasIndex(e => new { e.RouteMode, e.Dormant, e.DBid })
                    .HasName("_dta_index_Students_7_873770170__K64_K68_71");

                entity.HasIndex(e => new { e.Dormant, e.UniReg, e.StdStatus, e.DBid })
                    .HasName("_dta_index_Students_c_7_873770170__K64_K67_K31_K68");

                entity.HasIndex(e => new { e.RegNumber, e.StdSession, e.Dormant, e.StdStatus })
                    .HasName("_dta_index_Students_7_873770170__K30_K64_K31_2");

                entity.HasIndex(e => new { e.Dormant, e.StdSession, e.PresentClass, e.UniReg, e.StdStatus })
                    .HasName("IndRegNum");

                entity.HasIndex(e => new { e.PresentClass, e.Dormant, e.RegNumber, e.StdStatus, e.DBid })
                    .HasName("_dta_index_Students_7_873770170__K64_K2_K31_K68_16");

                entity.HasIndex(e => new { e.RegNumber, e.Dormant, e.StdSession, e.Sex, e.StdStatus })
                    .HasName("_dta_index_Students_7_873770170__K64_K30_K6_K31_2");

                entity.HasIndex(e => new { e.RegNumber, e.Dormant, e.UniReg, e.DBid, e.ModTime })
                    .HasName("_dta_index_Students_7_873770170__K64_K67_K68_K63_2");

                entity.HasIndex(e => new { e.UniReg, e.RegNumber, e.Dormant, e.StdSession, e.DBid })
                    .HasName("_dta_index_Students_7_873770170__K2_K64_K30_K68_67");
                entity.Property(e => e.StdId).HasColumnName("StdID");

                entity.Property(e => e.Aadhar)
                    .HasColumnName("AAdhar")
                    .HasMaxLength(12);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Address1).HasMaxLength(255);

                entity.Property(e => e.AdmissionNo).HasColumnName("AdmissionNO");

                entity.Property(e => e.BloodGroup).HasMaxLength(50);

                entity.Property(e => e.BusRoute).HasMaxLength(50);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.ClassAdmittedTo).HasMaxLength(50);

                entity.Property(e => e.Color_House)
                    .HasColumnName("Color_House")
                    .HasMaxLength(50);

                entity.Property(e => e.ConPhone).HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DateOfAdmission).HasDefaultValueSql("-1");

                entity.Property(e => e.DateOfFeeApp).HasDefaultValueSql("-1");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);
                entity.Property(e => e.Height).HasMaxLength(50);

                entity.Property(e => e.Hphone)
                    .HasColumnName("HPhone")
                    .HasMaxLength(50);

                entity.Property(e => e.Lgaddress1).HasColumnName("LGAddress1");

                entity.Property(e => e.Lgaddress2).HasColumnName("LGAddress2");

                entity.Property(e => e.Lgname).HasColumnName("LGName");

                entity.Property(e => e.Lgphone)
                    .HasColumnName("LGPhone")
                    .HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(255);
                entity.Property(e => e.Mphone)
                    .HasColumnName("MPhone")
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OccupationF).HasMaxLength(255);

                entity.Property(e => e.OccupationM).HasMaxLength(255);

                entity.Property(e => e.ParentsNamesF).HasMaxLength(255);

                entity.Property(e => e.ParentsNamesM).HasMaxLength(255);

                entity.Property(e => e.PermAddress).HasMaxLength(255);

                entity.Property(e => e.PermAddress1).HasMaxLength(255);

                entity.Property(e => e.PermAilment).HasMaxLength(50);

                entity.Property(e => e.PermCity).HasMaxLength(255);

                entity.Property(e => e.PermPostalCode).HasMaxLength(20);

                entity.Property(e => e.PermState).HasMaxLength(20);

                //entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.PresentClass).HasMaxLength(255);

                entity.Property(e => e.PrevSchool).HasMaxLength(255);

                entity.Property(e => e.QualificationF).HasMaxLength(50);

                entity.Property(e => e.QualificationM).HasMaxLength(50);

                entity.Property(e => e.Religion).HasMaxLength(255);

                entity.Property(e => e.Section).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.StdCategory).HasMaxLength(255);

                entity.Property(e => e.StdSession).HasMaxLength(255);

                entity.Property(e => e.Testimonials).HasMaxLength(255);
            });

            modelBuilder.Entity<SubjectSubs>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_SubjectSubs");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.SubId).HasColumnName("SubID");

                entity.Property(e => e.SubName).HasMaxLength(255);

                entity.Property(e => e.SubjectSubId)
                    .HasColumnName("SubjectSubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Teacher).HasMaxLength(255);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubAutoId)
                    .HasName("SubAutoId");

                entity.HasIndex(e => e.SubId)
                    .HasName("SubID");

                entity.HasIndex(e => new { e.SubName, e.Clss, e.AcaSession, e.IsElective, e.Dormant, e.DBid })
                    .HasName("_dta_index_Subjects_7_128719511__K30_K35_3_5_16_26");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.ClsWeek).HasColumnName("Cls_Week");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.FullMarks).HasDefaultValueSql("0");

                entity.Property(e => e.IsAssign).HasDefaultValueSql("0");

                entity.Property(e => e.IsElective).HasDefaultValueSql("0");

                entity.Property(e => e.IsPract).HasDefaultValueSql("0");

                entity.Property(e => e.IsTheory).HasDefaultValueSql("0");

                entity.Property(e => e.LabWeek).HasColumnName("Lab_Week");

                entity.Property(e => e.NLaboratory)
                    .HasColumnName("nLaboratory")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NLesson)
                    .HasColumnName("nLesson")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NTutorials)
                    .HasColumnName("nTutorials")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PrefPeriod).HasColumnName("Pref_Period");

                entity.Property(e => e.ClassTeacher).HasColumnName("Teacher");

                entity.Property(e => e.RoomLab).HasColumnName("Room_Lab");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubSn).HasDefaultValueSql("0");

                entity.Property(e => e.TeachId).HasColumnName("TeachID");

                entity.Property(e => e.TutWeek).HasColumnName("Tut_Week");
            });

            modelBuilder.Entity<SubjectsRel>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_SubjectsRel_1");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Clss).HasMaxLength(50);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubName).HasMaxLength(50);

                entity.Property(e => e.SubRelId)
                    .HasColumnName("SubRelID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TcData>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_TcData");

                entity.HasIndex(e => new { e.DoIssue, e.Dormant, e.UniReg })
                    .HasName("_dta_index_TcData_7_765245781__K29_K34_25");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.Concession).HasMaxLength(255);

                entity.Property(e => e.Conduct).HasMaxLength(255);

                entity.Property(e => e.CurricularActivities).HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.DuesPaid).HasMaxLength(255);

                entity.Property(e => e.Foiled).HasMaxLength(255);

                entity.Property(e => e.LastExam).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(255);

                entity.Property(e => e.NccGg).HasMaxLength(255);

                entity.Property(e => e.Qualified).HasMaxLength(255);

                entity.Property(e => e.ReasonOfTc).HasColumnName("ReasonOfTC");

                entity.Property(e => e.ScSt).HasColumnName("ScST");

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.Subject1).HasMaxLength(255);

                entity.Property(e => e.Subject2).HasMaxLength(255);

                entity.Property(e => e.Subject3).HasMaxLength(255);

                entity.Property(e => e.Subject4).HasMaxLength(255);

                entity.Property(e => e.Subject5).HasMaxLength(255);

                entity.Property(e => e.Subject6).HasMaxLength(255);

                entity.Property(e => e.Subject7).HasMaxLength(255);

                entity.Property(e => e.TcFile).HasColumnType("image");

                entity.Property(e => e.TcId)
                    .HasColumnName("TcID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaTeachers_PK");

                entity.HasIndex(e => e.teachId)
                    .HasName("TeachID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.cTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.dBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");


                entity.Property(e => e.loginName).HasMaxLength(50);

                entity.Property(e => e.tName)
                    .HasColumnName("tName")
                    .HasMaxLength(50);

                entity.Property(e => e.tTelephone)
                    .HasColumnName("tTelephone")
                    .HasMaxLength(50);

                entity.Property(e => e.teachId)
                    .HasColumnName("TeachID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_Template");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.TemplateId)
                    .HasColumnName("TemplateID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TrMgDel>(entity =>
            {
                entity.HasKey(e => e.MkTrId)
                    .HasName("PK_TrMG");

                entity.ToTable("TrMG_Del");

                entity.Property(e => e.MkTrId)
                    .HasColumnName("MkTrID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AsgnMarks).HasDefaultValueSql("0");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.ExamName).HasMaxLength(50);

                entity.Property(e => e.Grades).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Mclss)
                    .HasColumnName("MClss")
                    .HasMaxLength(50);

                entity.Property(e => e.MkId)
                    .HasColumnName("MkID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Msession)
                    .HasColumnName("MSession")
                    .HasMaxLength(255);

                entity.Property(e => e.OrMarks).HasDefaultValueSql("0");

                entity.Property(e => e.PracMarks).HasDefaultValueSql("0");

                entity.Property(e => e.RegNum).HasDefaultValueSql("0");

                entity.Property(e => e.StdGrades).HasMaxLength(50);

                entity.Property(e => e.SubName).HasMaxLength(50);

                entity.Property(e => e.ThMarks).HasDefaultValueSql("0");

                entity.Property(e => e.TrMg)
                    .HasColumnName("TrMG")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<TrStdClassCat>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_TrStdClassCat");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AcaSessionFrom).HasMaxLength(255);

                entity.Property(e => e.AcaSessionTo).HasMaxLength(255);

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.ClsPromFrom)
                    .HasColumnName("clsPromFrom")
                    .HasMaxLength(255);

                entity.Property(e => e.ClsPromTo)
                    .HasColumnName("clsPromTo")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.StdCatFrom)
                    .HasColumnName("stdCatFrom")
                    .HasMaxLength(255);

                entity.Property(e => e.StdCatTo)
                    .HasColumnName("stdCatTo")
                    .HasMaxLength(255);

                entity.Property(e => e.StdName).HasMaxLength(255);

                entity.Property(e => e.TrStdId)
                    .HasColumnName("TrStdID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TransActivity>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaTransActivity_PK");

                entity.HasIndex(e => e.TransActId)
                    .HasName("TransActID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.Score).HasDefaultValueSql("5");

                entity.Property(e => e.TeachId).HasColumnName("TeachID");

                entity.Property(e => e.TransActId)
                    .HasColumnName("TransActID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Activity).HasMaxLength(255);

                entity.Property(e => e.TransActObserver).HasMaxLength(255);

                entity.Property(e => e.TransActRemarks).HasMaxLength(255);
            });

            modelBuilder.Entity<VehicleDescription>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_VehicleDescription");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal).HasColumnName("cTerminal");

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VDriver).HasColumnName("vDriver");

                entity.Property(e => e.VNumber).HasColumnName("vNumber");

                entity.Property(e => e.VehicleId)
                    .HasColumnName("VehicleID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_VehicleType");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.VehicleTypeId).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<VonRt>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_VonRt");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CTerminal)
                    .HasColumnName("cTerminal")
                    .HasMaxLength(255);

                entity.Property(e => e.DBid)
                    .HasColumnName("dBID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dormant).HasDefaultValueSql("0");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.ModTime).HasDefaultValueSql("0");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.VonRtId)
                    .HasColumnName("VonRtID")
                    .HasDefaultValueSql("0");
            });

            //modelBuilder.Entity<WaiverCaption>(entity =>
            //{
            //    entity.HasKey(e => e.AutoId)
            //        .HasName("PK_WaiverCaption");

            //    entity.HasIndex(e => e.FeeNameId)
            //        .HasName("FeeNameId");

            //    entity.Property(e => e.AutoId).HasColumnName("AutoID");

            //    entity.Property(e => e.CTerminal)
            //        .HasColumnName("cTerminal")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DBid)
            //        .HasColumnName("dBID")
            //        .HasDefaultValueSql("0");

            //    entity.Property(e => e.DefAmount).HasDefaultValueSql("0");

            //    entity.Property(e => e.FeeCaption).HasMaxLength(50);

            //    entity.Property(e => e.FeeNameId).HasDefaultValueSql("0");

            //    entity.Property(e => e.IsDisc).HasDefaultValueSql("0");

            //    entity.Property(e => e.LoginName).HasMaxLength(50);
            //});
        }

        public DbSet<SchMod.Models.Studs.SearchStd> SearchStd { get; set; }

        public DbSet<SchMod.Models.Marx.SelectMarks> SelectMarks { get; set; }

        public DbSet<SchMod.Models.General.DashMod> DashMod { get; set; }
    }
}