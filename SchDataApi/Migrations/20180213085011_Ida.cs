using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchDataApi.Migrations
{
    public partial class Ida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcaSession",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SessionEndDate = table.Column<DateTime>(nullable: false),
                    SessionName = table.Column<string>(maxLength: 50, nullable: true),
                    SessionStartDate = table.Column<DateTime>(nullable: false),
                    SSDID = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcaSession", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "AccountHead",
                columns: table => new
                {
                    AccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccName = table.Column<string>(maxLength: 50, nullable: true),
                    Balance = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AccId", x => x.AccId);
                });

            migrationBuilder.CreateTable(
                name: "ActInRC",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    ActGrID = table.Column<int>(nullable: false),
                    ActGrRCID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Cls = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    SlRC = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActInRC", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActGroupID = table.Column<int>(nullable: false),
                    ActSession = table.Column<string>(nullable: true),
                    ActivityDate = table.Column<DateTime>(nullable: false),
                    ActivityGroup = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ActivityName = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityRemarks = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityValue = table.Column<double>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    SendEMail = table.Column<bool>(nullable: false),
                    SendSMS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.AutoID);
                    table.UniqueConstraint("AK_Activity_ActivityID", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGrades",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActClss = table.Column<string>(maxLength: 255, nullable: true),
                    ActExamName = table.Column<string>(maxLength: 255, nullable: true),
                    ActGroupID = table.Column<int>(nullable: false),
                    ActSession = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityGrName = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityGradeID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    CDesIndicators = table.Column<string>(nullable: true),
                    ChangeType = table.Column<int>(nullable: false),
                    CStdActGrades = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DesIndicators = table.Column<string>(nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RegNum = table.Column<int>(nullable: false),
                    StdActGrades = table.Column<string>(maxLength: 255, nullable: true),
                    StdActMarks = table.Column<double>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGrades", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGroup",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActClss = table.Column<string>(nullable: true),
                    ActCode = table.Column<string>(nullable: true),
                    ActGroupID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ActGroupMotive = table.Column<string>(maxLength: 255, nullable: true),
                    ActGroupName = table.Column<string>(maxLength: 255, nullable: true),
                    ActGroupReportCard = table.Column<string>(maxLength: 255, nullable: true),
                    ActSession = table.Column<string>(nullable: true),
                    ActSn = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(type: "nchar(255)", nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    GradeType = table.Column<string>(nullable: true),
                    IsReflectedInReportCArd = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("AutoID", x => x.AutoID);
                    table.UniqueConstraint("AK_ActivityGroup_ActGroupID", x => x.ActGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Appoints",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessType = table.Column<int>(nullable: false),
                    AppAgenda = table.Column<string>(nullable: true),
                    AppDate = table.Column<double>(nullable: false),
                    AppDuration = table.Column<string>(nullable: true),
                    AppHash = table.Column<string>(nullable: true),
                    AppID = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    AppLocation = table.Column<string>(nullable: true),
                    AppNotes = table.Column<string>(nullable: true),
                    AppPeriod = table.Column<string>(nullable: true),
                    AppPriorty = table.Column<string>(type: "nchar(10)", nullable: true),
                    AppRemind = table.Column<string>(nullable: true),
                    AppSetBy = table.Column<string>(nullable: true),
                    AppStatus = table.Column<string>(type: "nchar(10)", nullable: true),
                    AppSubject = table.Column<string>(nullable: true),
                    AppTitle = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoints", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(maxLength: 50, nullable: true),
                    AtType = table.Column<string>(nullable: true),
                    AttDate = table.Column<DateTime>(nullable: false),
                    AttID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Cause = table.Column<string>(nullable: true),
                    Clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    RegNum = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    StdName = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    clsRoll = table.Column<int>(nullable: false),
                    isAbsent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "AwareNames",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwareName = table.Column<string>(maxLength: 255, nullable: true),
                    AwareNameID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    AwareNameMotive = table.Column<string>(maxLength: 255, nullable: true),
                    AwareNameReportCard = table.Column<string>(maxLength: 255, nullable: true),
                    AwareNameSn = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsReflectedInReportCArd = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwareNames", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Awareness",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwareID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    AwareName = table.Column<string>(nullable: true),
                    AwareNameID = table.Column<int>(nullable: false),
                    AwareValue = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RegNumber = table.Column<double>(nullable: false),
                    Session = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awareness", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "CashDenom",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    CDenoID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Denomination = table.Column<string>(nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RecDate = table.Column<double>(nullable: false),
                    ReceiptNo = table.Column<int>(nullable: false),
                    Received = table.Column<double>(nullable: false),
                    Returned = table.Column<double>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CashDenom__75586032", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "CharecterCertificate",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    AdmissionNo = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Character = table.Column<string>(nullable: true),
                    CompSub = table.Column<string>(nullable: true),
                    Concession = table.Column<string>(maxLength: 255, nullable: true),
                    Conduct = table.Column<string>(maxLength: 255, nullable: true),
                    CurricularActivities = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Division = table.Column<string>(nullable: true),
                    DoApplication = table.Column<double>(nullable: false),
                    DoIssue = table.Column<double>(nullable: false),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DuesPaid = table.Column<string>(maxLength: 255, nullable: true),
                    Foiled = table.Column<string>(maxLength: 255, nullable: true),
                    LastExam = table.Column<string>(maxLength: 255, nullable: true),
                    LeftOn = table.Column<double>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(maxLength: 255, nullable: true),
                    NccGg = table.Column<string>(maxLength: 255, nullable: true),
                    PassingYear = table.Column<string>(nullable: true),
                    Present = table.Column<int>(nullable: false),
                    PromotedClass = table.Column<string>(nullable: true),
                    Promotion = table.Column<string>(nullable: true),
                    Qualified = table.Column<string>(maxLength: 255, nullable: true),
                    ReasonOfTC = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RollCode = table.Column<string>(nullable: true),
                    RollNo = table.Column<string>(nullable: true),
                    ScST = table.Column<string>(nullable: true),
                    SN = table.Column<int>(nullable: false),
                    Subject1 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject2 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject3 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject4 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject5 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject6 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject7 = table.Column<string>(maxLength: 255, nullable: true),
                    TcFile = table.Column<byte[]>(type: "image", nullable: true),
                    TcID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    UniReg = table.Column<int>(nullable: false),
                    Workingday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharecterCertificate", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ChqDrafts",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Bounced = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    ChequeID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ChequeNo = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dated = table.Column<DateTime>(nullable: false),
                    Deposited = table.Column<int>(nullable: false),
                    DepositedIN = table.Column<string>(nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RecDate = table.Column<DateTime>(nullable: false),
                    ReceiptNo = table.Column<int>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChqDrafts__6521F869", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Circuit",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    CircuitID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    CircuitName = table.Column<string>(maxLength: 255, nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    StopOrder = table.Column<int>(nullable: false),
                    Stoppage = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaCircuit_PK", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Clss",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(maxLength: 50, nullable: true),
                    BoardCode = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    ClassTeacher = table.Column<string>(maxLength: 255, nullable: true),
                    ClsId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ClsName = table.Column<string>(maxLength: 255, nullable: false),
                    Cls_Per_Day = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Cls_Sat = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ClssNum = table.Column<double>(nullable: false),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Room = table.Column<string>(maxLength: 255, nullable: true),
                    StdStrength = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    TeachID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clss", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigExam",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 255, nullable: true),
                    ConExamID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ExamFor = table.Column<string>(maxLength: 255, nullable: true),
                    ExamFrom = table.Column<string>(maxLength: 255, nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    MarksPC = table.Column<double>(nullable: false),
                    MarksType = table.Column<string>(nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    SSession = table.Column<string>(maxLength: 255, nullable: true),
                    Subj = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaConfigExam_PK", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ConSMSs",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    CSMSDateFDuesID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    DuesCheckDate = table.Column<double>(nullable: false),
                    FeeCaption = table.Column<string>(nullable: true),
                    ForClass = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SessionName = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true),
                    TextToSend = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ConSMSs__2CDD9F46", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Conveyance",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(nullable: true),
                    ConID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ConMode = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DateFrom = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    DateTo = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    Fare = table.Column<double>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Parents = table.Column<string>(nullable: true),
                    RegNum = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RollNo = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    StdName = table.Column<string>(nullable: true),
                    StopID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Stops = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AutoID", x => x.AutoID);
                    table.UniqueConstraint("AK_Conveyance_ConID", x => x.ConID);
                });

            migrationBuilder.CreateTable(
                name: "DynaFee",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Caption = table.Column<string>(maxLength: 255, nullable: true),
                    ClsFeeId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DueOn = table.Column<DateTime>(nullable: false),
                    FeeCaption = table.Column<string>(nullable: true),
                    FeeNo = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ForClass = table.Column<string>(maxLength: 50, nullable: true),
                    ForMonth = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    PayByDate = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    SessionName = table.Column<string>(maxLength: 255, nullable: true),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynaFee", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ExamSub",
                columns: table => new
                {
                    ExamSubAutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DOEvalutionFrom = table.Column<double>(nullable: false),
                    DOEvalutionTo = table.Column<double>(nullable: false),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ExamName = table.Column<string>(maxLength: 50, nullable: true),
                    ExamSubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Factor = table.Column<double>(nullable: false),
                    FMAssign = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    FMOral = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    FMPract = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    FMTheory = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    FullMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    IsAssign = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsElective = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsOral = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsPract = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsTheory = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    PassMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PMAssign = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PMOral = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PMPract = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PMTheory = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    Ssession = table.Column<string>(maxLength: 255, nullable: true),
                    SubExamMarksDirty = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubExamMarksLocked = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubName = table.Column<string>(maxLength: 50, nullable: true),
                    SubType = table.Column<int>(nullable: false),
                    UseInExamTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSub", x => x.ExamSubAutoID);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvanceAmount = table.Column<decimal>(type: "money", nullable: true),
                    AmountSpent = table.Column<decimal>(type: "money", nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    DatePurchased = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ExpenseType = table.Column<string>(maxLength: 50, nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 50, nullable: true),
                    PurposeofExpense = table.Column<string>(maxLength: 255, nullable: true),
                    upsize_ts = table.Column<byte[]>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaExpenses_PK", x => x.ExpenseID);
                });

            migrationBuilder.CreateTable(
                name: "FCaption",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FeeCaption = table.Column<string>(maxLength: 50, nullable: true),
                    FeeDuration = table.Column<string>(maxLength: 255, nullable: true),
                    FeeNameId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FeeOrder = table.Column<int>(nullable: false),
                    FeeType = table.Column<string>(maxLength: 50, nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCaption", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "FeeDuesSMSDates",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    DueCheckDate = table.Column<double>(nullable: false),
                    FDSDId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FeeCaption = table.Column<string>(nullable: true),
                    ForClass = table.Column<string>(nullable: true),
                    ForMonth = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SessionName = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true),
                    TextToSend = table.Column<string>(nullable: true),
                    TimeOfDueCheck = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FeeDuesSMSDates__3FF073BA", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "FeeForm",
                columns: table => new
                {
                    Sn = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clss = table.Column<string>(nullable: true),
                    ConPhone = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    FNames = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MNames = table.Column<string>(nullable: true),
                    RegNo = table.Column<int>(nullable: false),
                    RollNo = table.Column<int>(nullable: false),
                    StdCat = table.Column<string>(nullable: true),
                    StdName = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeForm", x => x.Sn);
                });

            migrationBuilder.CreateTable(
                name: "FeeSumm",
                columns: table => new
                {
                    FeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Caption = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    FeeCaption = table.Column<string>(nullable: true),
                    FeeNo = table.Column<int>(nullable: false),
                    ForMonth = table.Column<int>(nullable: false),
                    IsPaid = table.Column<string>(nullable: true),
                    PayDate = table.Column<DateTime>(nullable: false),
                    ReceiptNo = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Sn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeSumm", x => x.FeeId);
                });

            migrationBuilder.CreateTable(
                name: "FieldOrder",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    FormName = table.Column<string>(nullable: true),
                    ImagePage = table.Column<double>(nullable: false),
                    TabOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FieldOrder__00CA12DE", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(maxLength: 50, nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Descrptn = table.Column<string>(nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    HDate = table.Column<DateTime>(nullable: false),
                    HID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    HType = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessLevel = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    ImageID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ImageModTime = table.Column<DateTime>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "LateConFee",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    cTerminal = table.Column<string>(nullable: true),
                    CLFId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FeeCaption = table.Column<string>(nullable: true),
                    ForClass = table.Column<string>(nullable: true),
                    ForMonth = table.Column<int>(nullable: false),
                    ForPart = table.Column<int>(nullable: false),
                    LateDate = table.Column<double>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SessionName = table.Column<string>(maxLength: 50, nullable: true),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LateConFee", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveDefinition",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    CanbeCarriedOn = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CarryoverLimit = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DateStamp = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsPaidLeave = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsSchLeave = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LeaveType = table.Column<string>(maxLength: 255, nullable: true),
                    LeaveTypeID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    upsize_ts = table.Column<byte[]>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AutoID", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "LetterTemplates",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LetterTemplate = table.Column<string>(type: "ntext", nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    TemplateID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    TemplateName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterTemplates", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "LoginDetails",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    EMail = table.Column<string>(maxLength: 255, nullable: true),
                    HintAnswer = table.Column<string>(maxLength: 255, nullable: true),
                    HintQuestion = table.Column<string>(maxLength: 255, nullable: true),
                    LoginExpiry = table.Column<DateTime>(nullable: false),
                    LoginID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginLevel = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    LoginNameCh = table.Column<string>(maxLength: 50, nullable: true),
                    LoginPassword = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SpecialDetail = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MkAutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AsgnMarks = table.Column<string>(nullable: true, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    ExamName = table.Column<string>(maxLength: 50, nullable: true),
                    FMarks = table.Column<double>(nullable: false),
                    Grades = table.Column<string>(maxLength: 255, nullable: true),
                    GradesVal = table.Column<string>(nullable: true, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    MClss = table.Column<string>(maxLength: 50, nullable: true),
                    MSession = table.Column<string>(maxLength: 255, nullable: true),
                    MkID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ModTime = table.Column<DateTime>(nullable: false),
                    OrMarks = table.Column<string>(nullable: true, defaultValueSql: "0"),
                    Percentile = table.Column<double>(nullable: false),
                    PracMarks = table.Column<string>(nullable: true, defaultValueSql: "0"),
                    RecMode = table.Column<string>(nullable: true),
                    RegNum = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ScaleUpGrade = table.Column<string>(maxLength: 255, nullable: true),
                    StdGrades = table.Column<string>(maxLength: 50, nullable: true),
                    StdName = table.Column<string>(nullable: true),
                    SubName = table.Column<string>(maxLength: 50, nullable: true),
                    ThMarks = table.Column<string>(nullable: true, defaultValueSql: "0"),
                    TotalMarks = table.Column<string>(nullable: true),
                    TotalMarksCalc = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    presentRollNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MkAutoID);
                    table.UniqueConstraint("AK_Marks_MkID", x => x.MkID);
                });

            migrationBuilder.CreateTable(
                name: "Misc",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(maxLength: 255, nullable: true),
                    BoardAffiliationno = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Curriculum = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    EMail = table.Column<string>(maxLength: 255, nullable: true),
                    EMedium = table.Column<string>(maxLength: 255, nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    MiscID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ModTime = table.Column<DateTime>(nullable: false),
                    PcpName = table.Column<string>(maxLength: 255, nullable: true),
                    PcpPhone = table.Column<string>(maxLength: 255, nullable: true),
                    RecMode = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RegMode = table.Column<int>(nullable: false),
                    SchAddress = table.Column<string>(maxLength: 255, nullable: true),
                    SchMotto = table.Column<string>(maxLength: 255, nullable: true),
                    SchName = table.Column<string>(maxLength: 255, nullable: true),
                    SchPhone = table.Column<string>(maxLength: 255, nullable: true),
                    SchRegNum = table.Column<string>(nullable: true),
                    SessionStartDate = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    Version = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misc", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionT",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    PermID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Permissionss = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    TillDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PermissionT__7A1D154F", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "PosTrn",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dated = table.Column<DateTime>(nullable: false),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    PosTrnID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    PosTrnNo = table.Column<string>(nullable: true),
                    RecDate = table.Column<DateTime>(nullable: false),
                    ReceiptNo = table.Column<int>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosTrn", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    AmountPayable = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    BankName = table.Column<string>(maxLength: 50, nullable: true),
                    BillNo = table.Column<string>(maxLength: 255, nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    ChqDated = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ChqNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Clss = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DelRemarks = table.Column<string>(nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    FeeHeading = table.Column<string>(nullable: true),
                    ForPeriod = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    Gender = table.Column<string>(nullable: true),
                    IsDuesClearance = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    PaidAt = table.Column<string>(type: "nchar(50)", nullable: true),
                    PaymentMode = table.Column<string>(maxLength: 50, nullable: true),
                    RecID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ReceiptDate = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    ReceiptNo = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RegNo = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    RollNo = table.Column<int>(nullable: false),
                    sName = table.Column<string>(nullable: true),
                    StdCat = table.Column<string>(nullable: true),
                    StdName = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt_1", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ReportCard",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    RcClass = table.Column<string>(maxLength: 255, nullable: true),
                    RcExam = table.Column<string>(maxLength: 255, nullable: true),
                    RcId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RcName = table.Column<string>(nullable: true),
                    RcSession = table.Column<string>(maxLength: 255, nullable: true),
                    RcType = table.Column<string>(nullable: true),
                    RcValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCard", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DefaultLevel = table.Column<int>(nullable: false),
                    DefaultPermission = table.Column<int>(nullable: false),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RoleFnName = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RoleName = table.Column<string>(nullable: true),
                    RoleSet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__5C8CB268", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RouteDes = table.Column<string>(nullable: true),
                    RouteID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    RouteMode = table.Column<string>(nullable: true),
                    RouteName = table.Column<string>(nullable: true),
                    RouteNo = table.Column<string>(type: "nchar(10)", nullable: true),
                    StopOrder = table.Column<int>(nullable: false),
                    StopTimeFro = table.Column<string>(maxLength: 50, nullable: true),
                    StopTimeTo = table.Column<string>(maxLength: 50, nullable: true),
                    StopsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "SchLeaveDetails",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    DBid = table.Column<int>(nullable: false),
                    DateStamp = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SchLeaveDate = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    SchLeaveID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SchLeaveType = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AutoId", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "SearchStd",
                columns: table => new
                {
                    SStdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SClass = table.Column<string>(nullable: true),
                    SDOB = table.Column<DateTime>(nullable: false),
                    SGender = table.Column<int>(nullable: false),
                    SRegNumber = table.Column<int>(nullable: false),
                    SStdName = table.Column<string>(nullable: true),
                    SUniReg = table.Column<int>(nullable: false),
                    SeaStr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchStd", x => x.SStdID);
                });

            migrationBuilder.CreateTable(
                name: "SelectMarks",
                columns: table => new
                {
                    SelectMarksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DBid = table.Column<int>(nullable: false),
                    ExamName = table.Column<string>(maxLength: 50, nullable: true),
                    MClss = table.Column<string>(maxLength: 50, nullable: true),
                    Sessn = table.Column<string>(maxLength: 50, nullable: true),
                    SubName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectMarks", x => x.SelectMarksId);
                });

            migrationBuilder.CreateTable(
                name: "SMSemails",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    CheckDate = table.Column<DateTime>(nullable: false),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    FDSDId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FeeCaption = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    MobNo = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegNum = table.Column<int>(nullable: false),
                    SendorRecieved = table.Column<int>(nullable: false),
                    SessionName = table.Column<string>(maxLength: 50, nullable: true),
                    SMSEmailID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SMSorEmail = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    tFile = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SMSemails__4F32B74A", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "stdCat",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    StdCatID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stdCat", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "StdFee",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    ChequeID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FeeNo = table.Column<int>(nullable: false),
                    ForMonth = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RegNo = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    stdFeeId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdFee", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "StdHouse",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    StdHouse = table.Column<string>(maxLength: 255, nullable: true),
                    StdHouseID = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdHouse", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "StdSub",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RegNum = table.Column<int>(nullable: false),
                    RollNum = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SessionA = table.Column<string>(maxLength: 255, nullable: true),
                    StdID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    StdName = table.Column<string>(maxLength: 255, nullable: true),
                    StdSubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubName = table.Column<string>(maxLength: 50, nullable: true),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StdSubAutoID", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Circuit = table.Column<string>(maxLength: 255, nullable: true),
                    ConveyanceMode = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FareFromMonth = table.Column<DateTime>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    MonthlyFare = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    StopID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Stops = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.AutoID);
                    table.UniqueConstraint("AK_Stops_StopID", x => x.StopID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubAutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    AutoGrades = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Cls_Week = table.Column<int>(nullable: false),
                    Clss = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FeatureInReport = table.Column<int>(nullable: false),
                    FullMarks = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    GradeOrMarks = table.Column<int>(nullable: false),
                    GradeType = table.Column<string>(nullable: true),
                    IsAssign = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsElective = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsPract = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsTheory = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Lab_Week = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    nLaboratory = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    nLesson = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    nTutorials = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Pref_Period = table.Column<string>(nullable: true),
                    Pref_Teacher = table.Column<string>(nullable: true),
                    Room_Lab = table.Column<string>(nullable: true),
                    StandByTeacher = table.Column<string>(nullable: true),
                    SubCode = table.Column<string>(nullable: true),
                    SubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubName = table.Column<string>(nullable: true),
                    SubSn = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubType = table.Column<int>(nullable: false),
                    SubjectExamName = table.Column<string>(nullable: true),
                    TeachID = table.Column<int>(nullable: false),
                    Tut_Week = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SubAutoId", x => x.SubAutoId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsRel",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 50, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ExamName = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    MarksPro = table.Column<double>(nullable: false),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubName = table.Column<string>(maxLength: 50, nullable: true),
                    SubRelID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    SubSubName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsRel_1", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSubs",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Clss = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    SubID = table.Column<int>(nullable: false),
                    SubName = table.Column<string>(maxLength: 255, nullable: true),
                    SubjectSubID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Teacher = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSubs", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "TcData",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    AdmissionNo = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Character = table.Column<string>(nullable: true),
                    CompSub = table.Column<string>(nullable: true),
                    Concession = table.Column<string>(maxLength: 255, nullable: true),
                    Conduct = table.Column<string>(maxLength: 255, nullable: true),
                    CurricularActivities = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Division = table.Column<string>(nullable: true),
                    DoApplication = table.Column<double>(nullable: false),
                    DoIssue = table.Column<double>(nullable: false),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DuesPaid = table.Column<string>(maxLength: 255, nullable: true),
                    Foiled = table.Column<string>(maxLength: 255, nullable: true),
                    LastExam = table.Column<string>(maxLength: 255, nullable: true),
                    LeftOn = table.Column<double>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(maxLength: 255, nullable: true),
                    NccGg = table.Column<string>(maxLength: 255, nullable: true),
                    PassingCertificate = table.Column<string>(nullable: true),
                    PassingSubject = table.Column<string>(nullable: true),
                    PassingYear = table.Column<string>(nullable: true),
                    Present = table.Column<int>(nullable: false),
                    PromotedClass = table.Column<string>(nullable: true),
                    Promotion = table.Column<string>(nullable: true),
                    Qualified = table.Column<string>(maxLength: 255, nullable: true),
                    ReasonOfTC = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RollCode = table.Column<string>(nullable: true),
                    RollNo = table.Column<string>(nullable: true),
                    ScST = table.Column<string>(nullable: true),
                    SN = table.Column<int>(nullable: false),
                    Subject1 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject2 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject3 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject4 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject5 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject6 = table.Column<string>(maxLength: 255, nullable: true),
                    Subject7 = table.Column<string>(maxLength: 255, nullable: true),
                    TcFile = table.Column<byte[]>(type: "image", nullable: true),
                    TcID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    UniReg = table.Column<int>(nullable: false),
                    Workingday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcData", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModTime = table.Column<DateTime>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    dormant = table.Column<int>(nullable: false),
                    loginName = table.Column<string>(maxLength: 50, nullable: true),
                    tName = table.Column<string>(maxLength: 50, nullable: false),
                    tTelephone = table.Column<string>(maxLength: 50, nullable: true),
                    teachEMail = table.Column<string>(nullable: true),
                    TeachID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    teachLoginName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaTeachers_PK", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    TempModTime = table.Column<double>(nullable: false),
                    TemplateID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    TemplateName = table.Column<string>(nullable: true),
                    TemplateValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "TransActivity",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: false),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    RegNumber = table.Column<int>(nullable: false),
                    Score = table.Column<double>(nullable: false, defaultValueSql: "5"),
                    TeachID = table.Column<int>(nullable: false),
                    TransActDate = table.Column<DateTime>(nullable: false),
                    TransActID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    TransActName = table.Column<string>(maxLength: 255, nullable: true),
                    TransActObserver = table.Column<string>(maxLength: 255, nullable: true),
                    TransActRemarks = table.Column<string>(maxLength: 255, nullable: true),
                    TransActValue = table.Column<double>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaTransActivity_PK", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "TrMG_Del",
                columns: table => new
                {
                    MkTrID = table.Column<int>(nullable: false),
                    AsgnMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    Dormant = table.Column<int>(nullable: false),
                    ExamName = table.Column<string>(maxLength: 50, nullable: true),
                    Grades = table.Column<string>(maxLength: 255, nullable: true),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    MClss = table.Column<string>(maxLength: 50, nullable: true),
                    MkID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ModTime = table.Column<DateTime>(nullable: false),
                    MSession = table.Column<string>(maxLength: 255, nullable: true),
                    OrMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PracMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    RegNum = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    StdGrades = table.Column<string>(maxLength: 50, nullable: true),
                    SubName = table.Column<string>(maxLength: 50, nullable: true),
                    ThMarks = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    TotalMarks = table.Column<double>(nullable: false),
                    TotalMarksCalc = table.Column<double>(nullable: false),
                    TrMG = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrMG", x => x.MkTrID);
                });

            migrationBuilder.CreateTable(
                name: "TrStdClassCat",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSessionFrom = table.Column<string>(maxLength: 255, nullable: true),
                    AcaSessionTo = table.Column<string>(maxLength: 255, nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    clsPromFrom = table.Column<string>(maxLength: 255, nullable: true),
                    clsPromTo = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RegNumber = table.Column<int>(nullable: false),
                    stdCatFrom = table.Column<string>(maxLength: 255, nullable: true),
                    stdCatTo = table.Column<string>(maxLength: 255, nullable: true),
                    StdName = table.Column<string>(maxLength: 255, nullable: true),
                    TrStdID = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrStdClassCat", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDescription",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    Circuit = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    DriverAddress = table.Column<string>(nullable: true),
                    DriverDetails = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    vDriver = table.Column<string>(nullable: true),
                    vNumber = table.Column<string>(nullable: true),
                    VehicleDetails = table.Column<string>(nullable: true),
                    VehicleID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    VehicleName = table.Column<string>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDescription", x => x.AutoID);
                    table.UniqueConstraint("AK_VehicleDescription_VehicleID", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    VehType = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.AutoID);
                    table.UniqueConstraint("AK_VehicleType_VehicleTypeId", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VonRt",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FrDate = table.Column<DateTime>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    RouteID = table.Column<int>(nullable: false),
                    VehicleID = table.Column<int>(nullable: false),
                    VonRtID = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VonRt", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "WaiverCaption",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DefAmount = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FeeCaption = table.Column<string>(maxLength: 50, nullable: true),
                    FeeNameId = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    IsDisc = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiverCaption", x => x.AutoID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetails",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcaSession = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<double>(nullable: false),
                    BillNo = table.Column<string>(maxLength: 255, nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Dormant = table.Column<int>(nullable: false),
                    FEEnWAHead = table.Column<string>(maxLength: 255, nullable: true),
                    ForPeriod = table.Column<DateTime>(nullable: false, defaultValueSql: "0"),
                    LoginName = table.Column<string>(maxLength: 50, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    RecID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    ReceiptAutoId = table.Column<int>(nullable: true),
                    ReceiptNo = table.Column<int>(nullable: false),
                    RegNo = table.Column<int>(nullable: false),
                    RemarkDetails = table.Column<string>(maxLength: 255, nullable: true),
                    SlNo = table.Column<int>(nullable: false),
                    UniReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetails", x => x.AutoID);
                    table.ForeignKey(
                        name: "FK_ReceiptDetails_Receipt_ReceiptAutoId",
                        column: x => x.ReceiptAutoId,
                        principalTable: "Receipt",
                        principalColumn: "AutoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AAdhar = table.Column<string>(maxLength: 12, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Address1 = table.Column<string>(maxLength: 255, nullable: true),
                    AdmissionNO = table.Column<string>(nullable: true),
                    AnnualIncome = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(maxLength: 50, nullable: true),
                    BoardNo = table.Column<string>(nullable: true),
                    BoardRollCode = table.Column<string>(nullable: true),
                    BusRoute = table.Column<string>(maxLength: 50, nullable: true),
                    cTerminal = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: true),
                    ClassAdmittedTo = table.Column<string>(maxLength: 50, nullable: true),
                    Color_House = table.Column<string>(maxLength: 50, nullable: true),
                    ConPhone = table.Column<string>(maxLength: 255, nullable: true),
                    dBID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DateOfAdmission = table.Column<double>(nullable: false, defaultValueSql: "-1"),
                    DateOfFeeApp = table.Column<double>(nullable: false, defaultValueSql: "-1"),
                    DOB = table.Column<DateTime>(nullable: false),
                    Dormant = table.Column<int>(nullable: false),
                    Dues = table.Column<double>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Height = table.Column<string>(maxLength: 50, nullable: true),
                    HPhone = table.Column<string>(maxLength: 50, nullable: true),
                    LGAddress1 = table.Column<string>(nullable: true),
                    LGAddress2 = table.Column<string>(nullable: true),
                    LGName = table.Column<string>(nullable: true),
                    LGPhone = table.Column<string>(maxLength: 255, nullable: true),
                    LoginName = table.Column<string>(maxLength: 255, nullable: true),
                    ModTime = table.Column<DateTime>(nullable: false),
                    MPhone = table.Column<string>(maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 255, nullable: true),
                    OccupationF = table.Column<string>(maxLength: 255, nullable: true),
                    OccupationM = table.Column<string>(maxLength: 255, nullable: true),
                    OralHygiene = table.Column<string>(nullable: true),
                    ParentsNamesF = table.Column<string>(maxLength: 255, nullable: false),
                    ParentsNamesM = table.Column<string>(maxLength: 255, nullable: true),
                    Payable = table.Column<double>(nullable: false),
                    PermAddress = table.Column<string>(maxLength: 255, nullable: true),
                    PermAddress1 = table.Column<string>(maxLength: 255, nullable: true),
                    PermAilment = table.Column<string>(maxLength: 50, nullable: true),
                    PermCity = table.Column<string>(maxLength: 255, nullable: true),
                    PermIdentification = table.Column<string>(nullable: true),
                    PermPostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    PermState = table.Column<string>(maxLength: 20, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    PresentClass = table.Column<string>(maxLength: 255, nullable: false),
                    PresentRollNo = table.Column<int>(nullable: false),
                    PrevSchool = table.Column<string>(maxLength: 255, nullable: true),
                    QualificationF = table.Column<string>(maxLength: 50, nullable: true),
                    QualificationM = table.Column<string>(maxLength: 50, nullable: true),
                    RegNumber = table.Column<int>(nullable: false),
                    Religion = table.Column<string>(maxLength: 255, nullable: true),
                    RouteMode = table.Column<string>(nullable: true),
                    SearchStdSStdID = table.Column<int>(nullable: true),
                    Section = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    SplAilment = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 20, nullable: true),
                    StdCategory = table.Column<string>(maxLength: 255, nullable: true),
                    StdGenCategory = table.Column<string>(nullable: true),
                    StdName = table.Column<string>(maxLength: 150, nullable: false),
                    StdSession = table.Column<string>(maxLength: 255, nullable: true),
                    StdStatus = table.Column<int>(nullable: false),
                    Teeth = table.Column<string>(nullable: true),
                    Testimonials = table.Column<string>(maxLength: 255, nullable: true),
                    UniReg = table.Column<int>(nullable: false),
                    VisionL = table.Column<string>(nullable: true),
                    VisionR = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StdID);
                    table.ForeignKey(
                        name: "FK_Students_SearchStd_SearchStdSStdID",
                        column: x => x.SearchStdSStdID,
                        principalTable: "SearchStd",
                        principalColumn: "SStdID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ActivityID",
                table: "Activity",
                columns: new[] { "Dormant", "ActivityID" });

            migrationBuilder.CreateIndex(
                name: "RegNum",
                table: "ActivityGrades",
                columns: new[] { "Dormant", "ActSession", "ActClss", "ActGroupID", "UniReg" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ActivityGrades_7_1577772678__K5_K13_K17_K10_K21_6_7_8_9_11",
                table: "ActivityGrades",
                columns: new[] { "ActExamName", "StdActMarks", "StdActGrades", "ActSession", "DesIndicators", "ActClss", "Dormant", "UniReg", "ActGroupID", "dBID" });

            migrationBuilder.CreateIndex(
                name: "ActGroupID",
                table: "ActivityGroup",
                column: "ActGroupID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_CashDenom_7_1952726009__K2_1",
                table: "CashDenom",
                columns: new[] { "AutoID", "CDenoID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_CashDenom_7_1952726009__K4_K13_1_14",
                table: "CashDenom",
                columns: new[] { "AutoID", "AcaSession", "ReceiptNo", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ChqDrafts_7_1680725040__K14_K17_6",
                table: "ChqDrafts",
                columns: new[] { "IssuedBy", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ChqDrafts_7_1680725040__K4_K17_1_18",
                table: "ChqDrafts",
                columns: new[] { "AutoID", "AcaSession", "ReceiptNo", "dBID" });

            migrationBuilder.CreateIndex(
                name: "CircuitID",
                table: "Circuit",
                column: "CircuitID");

            migrationBuilder.CreateIndex(
                name: "Cls",
                table: "Clss",
                columns: new[] { "AcaSession", "ClsName" });

            migrationBuilder.CreateIndex(
                name: "ConExamID",
                table: "ConfigExam",
                column: "ConExamID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_ConfigExam_7_1115151018__K11_K14_K3_4_5_6_7_8",
                table: "ConfigExam",
                columns: new[] { "Clss", "ExamFor", "ExamFrom", "Subj", "MarksPC", "Dormant", "dBID", "SSession" });

            migrationBuilder.CreateIndex(
                name: "ConID",
                table: "Conveyance",
                column: "ConID");

            migrationBuilder.CreateIndex(
                name: "StdId",
                table: "Conveyance",
                column: "RegNum");

            migrationBuilder.CreateIndex(
                name: "RouteID",
                table: "Conveyance",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "ClsFeeId",
                table: "DynaFee",
                column: "ClsFeeId");

            migrationBuilder.CreateIndex(
                name: "_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_5_7",
                table: "DynaFee",
                columns: new[] { "ForMonth", "FeeCaption", "Dormant", "dBID", "ForClass", "SessionName" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K5_1_7_10",
                table: "DynaFee",
                columns: new[] { "AutoID", "FeeCaption", "StdCategory", "Dormant", "dBID", "ForClass", "SessionName", "ForMonth" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_DynaFee_7_1225771424__K12_K17_K9_K5_K10_K1_K3_7",
                table: "DynaFee",
                columns: new[] { "FeeCaption", "Dormant", "dBID", "ForClass", "ForMonth", "StdCategory", "AutoID", "FeeNo" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K5_1_3_4_6_10",
                table: "DynaFee",
                columns: new[] { "StdCategory", "AutoID", "FeeNo", "Caption", "Amount", "Dormant", "dBID", "ForClass", "SessionName", "ForMonth" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_DynaFee_7_1225771424__K12_K17_K9_K14_K1_K5_3_4_6_7_10",
                table: "DynaFee",
                columns: new[] { "StdCategory", "FeeNo", "Caption", "Amount", "FeeCaption", "Dormant", "dBID", "ForClass", "SessionName", "AutoID", "ForMonth" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ExamSub_7_365244356__K29_K34_K3",
                table: "ExamSub",
                columns: new[] { "Dormant", "dBID", "ExamName" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ExamSub_c_7_365244356__K5_K4_K29_K34",
                table: "ExamSub",
                columns: new[] { "Ssession", "Clss", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "ExamSelect",
                table: "ExamSub",
                columns: new[] { "Ssession", "Clss", "ExamName", "SubName" });

            migrationBuilder.CreateIndex(
                name: "DateSubmitted",
                table: "Expenses",
                column: "DateSubmitted");

            migrationBuilder.CreateIndex(
                name: "EmployeeID",
                table: "Expenses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "FeeNameId",
                table: "FCaption",
                column: "FeeNameId");

            migrationBuilder.CreateIndex(
                name: "_dta_index_LateConFee_7_1931153925__K10_K3_K8_K15_K12_K4_5_6",
                table: "LateConFee",
                columns: new[] { "Amount", "ForClass", "SessionName", "ForMonth", "StdCategory", "dBID", "Dormant", "LateDate" });

            migrationBuilder.CreateIndex(
                name: "LeaveTypeID",
                table: "LeaveDefinition",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "MKSInd",
                table: "Marks",
                columns: new[] { "MSession", "MClss", "ExamName", "SubName", "Dormant" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Marks_c_7_2126630619__K15_K3_K5_K4_K22_K18_K24",
                table: "Marks",
                columns: new[] { "MSession", "MClss", "ExamName", "SubName", "UniReg", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "MiscID",
                table: "Misc",
                column: "MiscID");

            migrationBuilder.CreateIndex(
                name: "AmountPAid",
                table: "Receipt",
                column: "AmountPaid");

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K22",
                table: "Receipt",
                column: "PaidAt");

            migrationBuilder.CreateIndex(
                name: "RecID",
                table: "Receipt",
                column: "RecID");

            migrationBuilder.CreateIndex(
                name: "ReceiptNo",
                table: "Receipt",
                column: "ReceiptNo");

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K3_26",
                table: "Receipt",
                columns: new[] { "AcaSession", "ReceiptNo" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K17_K18",
                table: "Receipt",
                columns: new[] { "Dormant", "LoginName" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K5_K17_K3_26",
                table: "Receipt",
                columns: new[] { "AcaSession", "ReceiptDate", "Dormant", "ReceiptNo" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K6_K3_K8_K17_K21_26",
                table: "Receipt",
                columns: new[] { "AcaSession", "UniReg", "ReceiptNo", "ForPeriod", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Receipt_7_199671759__K6_K3_K17_K11_K8_K21_5_9_10_22_24_26",
                table: "Receipt",
                columns: new[] { "AmountPaid", "PaidAt", "FeeHeading", "AcaSession", "ReceiptDate", "AmountPayable", "UniReg", "ReceiptNo", "Dormant", "IsDuesClearance", "ForPeriod", "dBID" });

            migrationBuilder.CreateIndex(
                name: "AmountPaid",
                table: "ReceiptDetails",
                column: "AmountPaid");

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K2",
                table: "ReceiptDetails",
                column: "RecID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_ReceiptAutoId",
                table: "ReceiptDetails",
                column: "ReceiptAutoId");

            migrationBuilder.CreateIndex(
                name: "StdID",
                table: "ReceiptDetails",
                column: "RegNo");

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K11_K3_K8",
                table: "ReceiptDetails",
                columns: new[] { "Dormant", "ReceiptNo", "FEEnWAHead" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K17_K3_1_11_18",
                table: "ReceiptDetails",
                columns: new[] { "AutoID", "Dormant", "AcaSession", "dBID", "ReceiptNo" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K17_K3_K11_K7_K8_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "dBID", "ReceiptNo", "Dormant", "ForPeriod", "FEEnWAHead" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K8_K3_K7_K11_K17_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "FEEnWAHead", "ReceiptNo", "ForPeriod", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K7_K8_K3_K11_K17_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "ForPeriod", "FEEnWAHead", "ReceiptNo", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K8_K3_K7_K17_K11_K16_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "FEEnWAHead", "ReceiptNo", "ForPeriod", "dBID", "Dormant", "UniReg" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K8_K16_K3_K7_K11_K17_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "FEEnWAHead", "UniReg", "ReceiptNo", "ForPeriod", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_ReceiptDetails_7_343672272__K16_K3_K7_K17_K11_K8_18",
                table: "ReceiptDetails",
                columns: new[] { "AcaSession", "UniReg", "ReceiptNo", "ForPeriod", "dBID", "Dormant", "FEEnWAHead" });

            migrationBuilder.CreateIndex(
                name: "EmpID",
                table: "SchLeaveDetails",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "CompLeaveID",
                table: "SchLeaveDetails",
                column: "SchLeaveID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_SMSemails_7_1312723729__K2_1",
                table: "SMSemails",
                columns: new[] { "AutoID", "SMSEmailID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_SMSemails_7_1312723729__K19_K8_K15_1",
                table: "SMSemails",
                columns: new[] { "AutoID", "Dormant", "Status", "CheckDate" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_SMSemails_7_1312723729__K8_K19_K13_K10_K20_2_4_5_6_7_9_11_12_14_15_16_17",
                table: "SMSemails",
                columns: new[] { "Subject", "email", "SendorRecieved", "CheckDate", "FeeCaption", "SessionName", "SMSEmailID", "RegNum", "UniReg", "Text", "tFile", "dBID", "Status", "Dormant", "SMSorEmail", "MobNo", "ModTime" });

            migrationBuilder.CreateIndex(
                name: "ClsFeeId",
                table: "StdFee",
                column: "stdFeeId");

            migrationBuilder.CreateIndex(
                name: "_dta_index_StdFee_7_727673640__K7_K5_K12_K4_1",
                table: "StdFee",
                columns: new[] { "AutoID", "Dormant", "ForMonth", "UniReg", "Caption" });

            migrationBuilder.CreateIndex(
                name: "StdCatID",
                table: "StdHouse",
                column: "StdHouseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RollNum",
                table: "StdSub",
                column: "RollNum");

            migrationBuilder.CreateIndex(
                name: "StdID",
                table: "StdSub",
                column: "StdID");

            migrationBuilder.CreateIndex(
                name: "StdSubID",
                table: "StdSub",
                column: "StdSubID");

            migrationBuilder.CreateIndex(
                name: "SubID",
                table: "StdSub",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SearchStdSStdID",
                table: "Students",
                column: "SearchStdSStdID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K38",
                table: "Students",
                columns: new[] { "Dormant", "BloodGroup" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K10",
                table: "Students",
                columns: new[] { "Dormant", "OccupationF" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K13",
                table: "Students",
                columns: new[] { "Dormant", "OccupationM" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K29",
                table: "Students",
                columns: new[] { "Dormant", "PrevSchool" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K11",
                table: "Students",
                columns: new[] { "Dormant", "QualificationF" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K14",
                table: "Students",
                columns: new[] { "Dormant", "QualificationM" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K8",
                table: "Students",
                columns: new[] { "Dormant", "Religion" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_69",
                table: "Students",
                columns: new[] { "StdGenCategory", "Dormant" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K31_2",
                table: "Students",
                columns: new[] { "RegNumber", "Dormant", "StdStatus" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K68_71",
                table: "Students",
                columns: new[] { "RouteMode", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_c_7_873770170__K64_K67_K31_K68",
                table: "Students",
                columns: new[] { "Dormant", "UniReg", "StdStatus", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K30_K64_K31_2",
                table: "Students",
                columns: new[] { "RegNumber", "StdSession", "Dormant", "StdStatus" });

            migrationBuilder.CreateIndex(
                name: "IndRegNum",
                table: "Students",
                columns: new[] { "Dormant", "StdSession", "PresentClass", "UniReg", "StdStatus" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K2_K31_K68_16",
                table: "Students",
                columns: new[] { "PresentClass", "Dormant", "RegNumber", "StdStatus", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K30_K6_K31_2",
                table: "Students",
                columns: new[] { "RegNumber", "Dormant", "StdSession", "Sex", "StdStatus" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K64_K67_K68_K63_2",
                table: "Students",
                columns: new[] { "RegNumber", "Dormant", "UniReg", "dBID", "ModTime" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_Students_7_873770170__K2_K64_K30_K68_67",
                table: "Students",
                columns: new[] { "UniReg", "RegNumber", "Dormant", "StdSession", "dBID" });

            migrationBuilder.CreateIndex(
                name: "SubID",
                table: "Subjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_Subjects_7_128719511__K30_K35_3_5_16_26",
                table: "Subjects",
                columns: new[] { "SubName", "Clss", "AcaSession", "IsElective", "Dormant", "dBID" });

            migrationBuilder.CreateIndex(
                name: "_dta_index_TcData_7_765245781__K29_K34_25",
                table: "TcData",
                columns: new[] { "DoIssue", "Dormant", "UniReg" });

            migrationBuilder.CreateIndex(
                name: "TeachID",
                table: "Teachers",
                column: "TeachID");

            migrationBuilder.CreateIndex(
                name: "TransActID",
                table: "TransActivity",
                column: "TransActID");

            migrationBuilder.CreateIndex(
                name: "FeeNameId",
                table: "WaiverCaption",
                column: "FeeNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcaSession");

            migrationBuilder.DropTable(
                name: "AccountHead");

            migrationBuilder.DropTable(
                name: "ActInRC");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityGrades");

            migrationBuilder.DropTable(
                name: "ActivityGroup");

            migrationBuilder.DropTable(
                name: "Appoints");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "AwareNames");

            migrationBuilder.DropTable(
                name: "Awareness");

            migrationBuilder.DropTable(
                name: "CashDenom");

            migrationBuilder.DropTable(
                name: "CharecterCertificate");

            migrationBuilder.DropTable(
                name: "ChqDrafts");

            migrationBuilder.DropTable(
                name: "Circuit");

            migrationBuilder.DropTable(
                name: "Clss");

            migrationBuilder.DropTable(
                name: "ConfigExam");

            migrationBuilder.DropTable(
                name: "ConSMSs");

            migrationBuilder.DropTable(
                name: "Conveyance");

            migrationBuilder.DropTable(
                name: "DynaFee");

            migrationBuilder.DropTable(
                name: "ExamSub");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FCaption");

            migrationBuilder.DropTable(
                name: "FeeDuesSMSDates");

            migrationBuilder.DropTable(
                name: "FeeForm");

            migrationBuilder.DropTable(
                name: "FeeSumm");

            migrationBuilder.DropTable(
                name: "FieldOrder");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LateConFee");

            migrationBuilder.DropTable(
                name: "LeaveDefinition");

            migrationBuilder.DropTable(
                name: "LetterTemplates");

            migrationBuilder.DropTable(
                name: "LoginDetails");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Misc");

            migrationBuilder.DropTable(
                name: "PermissionT");

            migrationBuilder.DropTable(
                name: "PosTrn");

            migrationBuilder.DropTable(
                name: "ReceiptDetails");

            migrationBuilder.DropTable(
                name: "ReportCard");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "SchLeaveDetails");

            migrationBuilder.DropTable(
                name: "SelectMarks");

            migrationBuilder.DropTable(
                name: "SMSemails");

            migrationBuilder.DropTable(
                name: "stdCat");

            migrationBuilder.DropTable(
                name: "StdFee");

            migrationBuilder.DropTable(
                name: "StdHouse");

            migrationBuilder.DropTable(
                name: "StdSub");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "SubjectsRel");

            migrationBuilder.DropTable(
                name: "SubjectSubs");

            migrationBuilder.DropTable(
                name: "TcData");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "TransActivity");

            migrationBuilder.DropTable(
                name: "TrMG_Del");

            migrationBuilder.DropTable(
                name: "TrStdClassCat");

            migrationBuilder.DropTable(
                name: "VehicleDescription");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "VonRt");

            migrationBuilder.DropTable(
                name: "WaiverCaption");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "SearchStd");
        }
    }
}
