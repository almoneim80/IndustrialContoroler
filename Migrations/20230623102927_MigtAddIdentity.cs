using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class MigtAddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveUser = table.Column<bool>(type: "bit", nullable: false),
                    ImageUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attachmentType",
                columns: table => new
                {
                    att_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    att_attachmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__attachme__4831C98D604648A8", x => x.att_Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    re_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    re_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    re_Date = table.Column<DateTime>(type: "date", nullable: false),
                    re_Applicant = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    re_formNo = table.Column<int>(type: "int", nullable: false),
                    re_suemNo = table.Column<int>(type: "int", nullable: false),
                    re_requestState = table.Column<int>(type: "int", nullable: false),
                    re_reference = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Request__1A4B5594E26764D9", x => x.re_Id);
                    table.UniqueConstraint("AK_Request_re_formNo", x => x.re_formNo);
                });

            migrationBuilder.CreateTable(
                name: "Temporary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cel_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel_30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TblDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    at_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    at_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    re_Id = table.Column<int>(type: "int", nullable: false),
                    att_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attachme__61F955B0B84DF688", x => x.at_Id);
                    table.ForeignKey(
                        name: "FK_AttachmentTypeAttachments",
                        column: x => x.att_Id,
                        principalTable: "attachmentType",
                        principalColumn: "att_Id");
                    table.ForeignKey(
                        name: "FK_RequestsAttachments",
                        column: x => x.re_Id,
                        principalTable: "Request",
                        principalColumn: "re_Id");
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    fa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fa_Number = table.Column<int>(type: "int", nullable: false),
                    re_formNo = table.Column<int>(type: "int", nullable: true),
                    fa_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_activityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_mainActivity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_shareCapital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_startProduction = table.Column<DateTime>(type: "date", nullable: false),
                    fa_totalArea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Ownership = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_workPeriods = table.Column<int>(type: "int", nullable: false),
                    fa_legalEntity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_OwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Mode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_webSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_faxNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_phoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_mobileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_Governorate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Directorate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_regionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Facility__BD0780CCBCC58253", x => x.fa_Id);
                    table.ForeignKey(
                        name: "FK_FacilityRequests",
                        column: x => x.re_formNo,
                        principalTable: "Request",
                        principalColumn: "re_formNo");
                });

            migrationBuilder.CreateTable(
                name: "requestTraffic",
                columns: table => new
                {
                    rt_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rt_startDate = table.Column<DateTime>(type: "date", nullable: false),
                    rt_endDate = table.Column<DateTime>(type: "date", nullable: false),
                    re_Id = table.Column<int>(type: "int", nullable: false),
                    us_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__requestT__EF871B05A6AC9F69", x => x.rt_Id);
                    table.ForeignKey(
                        name: "FK_RequestsRequestTraffic",
                        column: x => x.re_Id,
                        principalTable: "Request",
                        principalColumn: "re_Id");
                });

            migrationBuilder.CreateTable(
                name: "agentsPoint",
                columns: table => new
                {
                    ap_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ap_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ap_tradeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ap_phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ap_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ap_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ap_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__agentsPo__C40F0A854A571820", x => x.ap_Id);
                    table.ForeignKey(
                        name: "FK_FacilityAgentsPoints",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    bu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bu_Ownership = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bu_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bu_Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bu_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bu_Length = table.Column<int>(type: "int", nullable: false),
                    bu_Width = table.Column<int>(type: "int", nullable: false),
                    bu_High = table.Column<int>(type: "int", nullable: false),
                    bu_Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bu_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Building__A53BF20F1FDEA98B", x => x.bu_Id);
                    table.ForeignKey(
                        name: "FK_FacilityBuildings",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "castData",
                columns: table => new
                {
                    cd_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cd_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cd_Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cd_phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    cd_idCardNumber = table.Column<int>(type: "int", nullable: false),
                    cd_cardPlaceIssu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cd_cardIssuDate = table.Column<DateTime>(type: "date", nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__castData__D552B11E20D67763", x => x.cd_Id);
                    table.ForeignKey(
                        name: "FK_FacilityCastData",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "helpMaterial",
                columns: table => new
                {
                    hm_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hm_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hm_measruingUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hm_amountUsed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hm_percentInPro = table.Column<int>(type: "int", nullable: false),
                    hm_Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hm_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__helpMate__842BCD5BBE7C0D47", x => x.hm_Id);
                    table.ForeignKey(
                        name: "FK_FacilityHelpMaterials",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    ma_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_number = table.Column<int>(type: "int", nullable: false),
                    ma_Uses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ma_countryManufacture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_measruingUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ma_Ability = table.Column<int>(type: "int", nullable: false),
                    ma_Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_sourceAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Machine__0FE6627F9DD47CE6", x => x.ma_Id);
                    table.ForeignKey(
                        name: "FK_FacilityMachines",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "proCapacity",
                columns: table => new
                {
                    pc_productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pc_productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pc_yearQuantity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pc_measruingUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pc_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__proCapac__A38A36234161F13B", x => x.pc_productId);
                    table.ForeignKey(
                        name: "FK_FacilityProductionCapacity",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "relevantDoc",
                columns: table => new
                {
                    rd_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rd_docName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    rd_stakeholderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    re_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    re_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__relevant__D3D102FA6D3F5895", x => x.rd_Id);
                    table.ForeignKey(
                        name: "FK_FacilityRelevantDocuments",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "rowMaterial",
                columns: table => new
                {
                    rm_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rm_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rm_measruingUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rm_amountUsed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rm_percentInPro = table.Column<int>(type: "int", nullable: false),
                    rm_Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rm_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rowMater__62C24217C2AA7444", x => x.rm_Id);
                    table.ForeignKey(
                        name: "FK_FacilityRowMaterials",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "SafetySecurity",
                columns: table => new
                {
                    ss_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ss_fireSystem = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_emergencyExit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_occSafety = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_safetyDashboard = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_Ventilation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_Lighting = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ss_firstAidKit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SafetySe__A444DACAACCB338D", x => x.ss_Id);
                    table.ForeignKey(
                        name: "FK_FacilitySafetySecurity",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "secondaryAct",
                columns: table => new
                {
                    sa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sa_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FacilityFaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__secondar__FE003E7225435974", x => x.sa_Id);
                    table.ForeignKey(
                        name: "FK_FacilitySecondaryAct",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                    table.ForeignKey(
                        name: "FK_secondaryAct_Facility_FacilityFaId",
                        column: x => x.FacilityFaId,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "siteReason",
                columns: table => new
                {
                    sr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sr_Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FacilityFaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__siteReas__5C9F948102D1C6EC", x => x.sr_Id);
                    table.ForeignKey(
                        name: "FK_FacilitySiteReasons",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                    table.ForeignKey(
                        name: "FK_siteReason_Facility_FacilityFaId",
                        column: x => x.FacilityFaId,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    tr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tr_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tr_plateNumber = table.Column<int>(type: "int", nullable: false),
                    tr_Load = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tr_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transpor__ABD6A7503771012A", x => x.tr_Id);
                    table.ForeignKey(
                        name: "FK_FacilityTransportation",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "visitsTraffic",
                columns: table => new
                {
                    vt_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vt_visitDate = table.Column<DateTime>(type: "date", nullable: false),
                    vt_visitPurpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    re_formNo = table.Column<int>(type: "int", nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    fa_dataState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__visitsTr__9458D67B52050576", x => x.vt_Id);
                    table.ForeignKey(
                        name: "FK_FacilityVisitsTraffic",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    wo_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wo_Total = table.Column<int>(type: "int", nullable: false),
                    wo_maleNumber = table.Column<int>(type: "int", nullable: false),
                    wo_femaleNumber = table.Column<int>(type: "int", nullable: false),
                    wo_eduQualifying = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    wo_specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    wo_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('لاتوجد ملاحظات')"),
                    wo_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    wo_Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fa_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Worker__DD93F5F884D36C53", x => x.wo_Id);
                    table.ForeignKey(
                        name: "FK_FacilityWorkers",
                        column: x => x.fa_Id,
                        principalTable: "Facility",
                        principalColumn: "fa_Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    no_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    no_Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    no_date = table.Column<DateTime>(type: "date", nullable: false),
                    no_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    no_Sourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    requestTraffic_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__E2D318E83F3B1F73", x => x.no_Id);
                    table.ForeignKey(
                        name: "FK_requestTrafficNotifications",
                        column: x => x.requestTraffic_Id,
                        principalTable: "requestTraffic",
                        principalColumn: "rt_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_agentsPoint_fa_Id",
                table: "agentsPoint",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_att_Id",
                table: "Attachment",
                column: "att_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_re_Id",
                table: "Attachment",
                column: "re_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Building_fa_Id",
                table: "Building",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_castData_fa_Id",
                table: "castData",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Facility__8E6079845E297BBE",
                table: "Facility",
                column: "re_formNo",
                unique: true,
                filter: "[re_formNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Facility__E1CFB4A23BE9488F",
                table: "Facility",
                column: "fa_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Facility__F093DB673BE0081A",
                table: "Facility",
                column: "fa_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_helpMaterial_fa_Id",
                table: "helpMaterial",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LogCategories_CategoryId",
                table: "LogCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_fa_Id",
                table: "Machine",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_requestTraffic_Id",
                table: "Notification",
                column: "requestTraffic_Id");

            migrationBuilder.CreateIndex(
                name: "IX_proCapacity_fa_Id",
                table: "proCapacity",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_relevantDoc_fa_Id",
                table: "relevantDoc",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Request__44C63773E9ED83A5",
                table: "Request",
                column: "re_suemNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Request__8E607984A59FDB18",
                table: "Request",
                column: "re_formNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requestTraffic_re_Id",
                table: "requestTraffic",
                column: "re_Id");

            migrationBuilder.CreateIndex(
                name: "IX_rowMaterial_fa_Id",
                table: "rowMaterial",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetySecurity_fa_Id",
                table: "SafetySecurity",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryAct_fa_Id",
                table: "secondaryAct",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryAct_FacilityFaId",
                table: "secondaryAct",
                column: "FacilityFaId");

            migrationBuilder.CreateIndex(
                name: "IX_siteReason_fa_Id",
                table: "siteReason",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_siteReason_FacilityFaId",
                table: "siteReason",
                column: "FacilityFaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_fa_Id",
                table: "Transportation",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_visitsTraffic_fa_Id",
                table: "visitsTraffic",
                column: "fa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_fa_Id",
                table: "Worker",
                column: "fa_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agentsPoint");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "castData");

            migrationBuilder.DropTable(
                name: "helpMaterial");

            migrationBuilder.DropTable(
                name: "LogCategories");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "proCapacity");

            migrationBuilder.DropTable(
                name: "relevantDoc");

            migrationBuilder.DropTable(
                name: "rowMaterial");

            migrationBuilder.DropTable(
                name: "SafetySecurity");

            migrationBuilder.DropTable(
                name: "secondaryAct");

            migrationBuilder.DropTable(
                name: "siteReason");

            migrationBuilder.DropTable(
                name: "Temporary");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "visitsTraffic");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "attachmentType");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "requestTraffic");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
