using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSI_Calendar.Migrations
{
    public partial class SeedDiversity : Migration
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
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Attachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveFamNotis = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveEduNotis = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveFunNotis = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
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

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "ID", "EventID", "Link", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 90, 29, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 89, 28, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 88, 27, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 87, 26, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 86, 25, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 85, 24, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 84, 23, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 83, 22, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 82, 21, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 81, 20, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 80, 19, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 79, 18, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 78, 17, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 77, 16, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 76, 15, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 75, 14, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 74, 13, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 73, 12, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 72, 11, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 71, 10, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 70, 9, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 69, 8, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 68, 7, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 67, 6, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 66, 5, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 65, 4, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 64, 3, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 91, 30, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 63, 2, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 93, 32, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 95, 34, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 122, 61, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 121, 60, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 120, 59, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 119, 58, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 118, 57, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 117, 56, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 116, 55, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 115, 54, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 114, 53, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 113, 52, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" }
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "ID", "EventID", "Link", "Title" },
                values: new object[,]
                {
                    { 112, 51, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 111, 50, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 110, 49, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 109, 48, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 108, 47, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 107, 46, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 106, 45, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 105, 44, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 104, 43, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 103, 42, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 102, 41, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 101, 40, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 100, 39, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 99, 38, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 98, 37, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 97, 36, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 96, 35, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 94, 33, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 62, 1, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 92, 31, "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree", "Augusta Technical College - Computer Programming, Associate of Applied Science Degree" },
                    { 60, 60, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 28, 28, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 27, 27, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 26, 26, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 25, 25, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 24, 24, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 23, 23, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 22, 22, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 21, 21, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 20, 20, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 19, 19, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 18, 18, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 16, 16, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 15, 15, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 14, 14, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 13, 13, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 12, 12, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 11, 11, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 10, 10, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 9, 9, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 8, 8, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 7, 7, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" }
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "ID", "EventID", "Link", "Title" },
                values: new object[,]
                {
                    { 6, 6, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 5, 5, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 4, 4, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 3, 3, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 2, 2, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 61, 61, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 29, 29, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 30, 30, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 17, 17, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 58, 58, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 59, 59, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 31, 31, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 57, 57, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 56, 56, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 55, 55, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 54, 54, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 53, 53, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 52, 52, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 51, 51, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 49, 49, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 48, 48, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 47, 47, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 46, 46, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 45, 45, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 50, 50, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 33, 33, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 32, 32, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 44, 44, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 34, 34, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 35, 35, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 36, 36, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 38, 38, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 37, 37, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 40, 40, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 41, 41, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 42, 42, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 43, 43, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" },
                    { 39, 39, "https://www.ruralsourcing.com/what-we-do/", "RSI - What We Do" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 40, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Lecture - Improving your communication skills as a developer", new DateTime(2021, 12, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 43, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Food Drive", new DateTime(2021, 12, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 42, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 12, 21, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Meetup at the Baseball Game", new DateTime(2021, 12, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 41, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "The Basics of SAP Data Services by Sam Gassem", new DateTime(2021, 12, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 39, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Toy Drive", new DateTime(2021, 12, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 33, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Code Review", new DateTime(2021, 12, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 37, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Sprint Planning", new DateTime(2021, 12, 7, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 36, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Lecture - Ways to Improve Code Reviews", new DateTime(2021, 12, 6, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 35, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Cookout", new DateTime(2021, 12, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 34, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 4, 21, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Trivia Night", new DateTime(2021, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 44, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Lecture - .NET 5: Whats New?!", new DateTime(2021, 12, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 38, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Costume Day!", new DateTime(2021, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 45, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Sprint Retrospective", new DateTime(2021, 12, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 59, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Food Drive", new DateTime(2021, 12, 27, 9, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 47, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Picnic in the Park", new DateTime(2021, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 48, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 17, 16, 30, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Lecture - Whats new in Visual Studio 2021?", new DateTime(2021, 12, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 49, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Backlog Refinement", new DateTime(2021, 12, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 50, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 20, 21, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Paint Night", new DateTime(2021, 12, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 51, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Snowball Fight and Cookout", new DateTime(2021, 12, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 52, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Lecture - Backlog Refinement", new DateTime(2021, 12, 22, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 53, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Code Review", new DateTime(2021, 12, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 54, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Christmas Eve with Santa!", new DateTime(2021, 12, 24, 14, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 55, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Toy Drive", new DateTime(2021, 12, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 56, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 27, 16, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Lecture - Ways to Improve Code Reviews", new DateTime(2021, 12, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 57, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 27, 8, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Sprint Planning", new DateTime(2021, 12, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 58, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 28, 21, 30, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Movie Night", new DateTime(2021, 12, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 32, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Lecture - Backlog Refinement", new DateTime(2021, 12, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 46, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 16, 21, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Game Night", new DateTime(2021, 12, 16, 19, 30, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 31, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Picnic in the Park", new DateTime(2021, 12, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 1, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "The Basics of SAP Data Services by Sam Gassem", new DateTime(2021, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 29, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Backlog Refinement", new DateTime(2021, 11, 29, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 60, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Lecture - Improving your communication skills as a developer", new DateTime(2021, 12, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 2, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 2, 21, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Movie Night", new DateTime(2021, 11, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 3, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Cookout", new DateTime(2021, 11, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 4, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Lecture - .NET 5: Whats New?!", new DateTime(2021, 11, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 5, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Sprint Retrospective", new DateTime(2021, 11, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 6, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 6, 21, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Trivia Night", new DateTime(2021, 11, 6, 19, 30, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 7, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 12, 23, 59, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Toy Drive", new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 8, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 8, 16, 30, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Lecture - Whats new in Visual Studio 2021?", new DateTime(2021, 11, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 9, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Backlog Refinement", new DateTime(2021, 11, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 10, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Costume Day!", new DateTime(2021, 11, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 11, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Veterans Day Cookout", new DateTime(2021, 11, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 12, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Lecture - Backlog Refinement", new DateTime(2021, 11, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 13, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Code Review", new DateTime(2021, 11, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 30, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Movie Night", new DateTime(2021, 11, 30, 18, 30, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 14, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Meetup at the Baseball Game", new DateTime(2021, 11, 14, 18, 30, 0, 0, DateTimeKind.Unspecified), "Fun" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 16, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 16, 16, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Lecture - Ways to Improve Code Reviews", new DateTime(2021, 11, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 17, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 17, 8, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Sprint Planning", new DateTime(2021, 11, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 18, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 18, 21, 30, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Game Night", new DateTime(2021, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 19, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Cookout", new DateTime(2021, 11, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 20, "Albuquerque, NM", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Lecture - Improving your communication skills as a developer", new DateTime(2021, 11, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 21, "FortWayne, IN", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "The Basics of SAP Data Services by Sam Gassem", new DateTime(2021, 11, 22, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 22, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 22, 14, 30, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Paint Night", new DateTime(2021, 11, 22, 13, 30, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 23, "Jonesboro, AR", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Toy Drive", new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 24, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), "7476 Hancock Ave", "Lecture - .NET 5: Whats New?!", new DateTime(2021, 11, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 25, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 24, 8, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Sprint Retrospective", new DateTime(2021, 11, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 26, "Mobile, AL", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 26, 18, 30, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "Company Softball Game", new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 27, "Oklahoma City, OK", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), "1776 Freedom Street", "Food Drive", new DateTime(2021, 11, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 28, "Augusta, GA", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), "3570 Crispus Attucks Way", "Lecture - Whats new in Visual Studio 2021?", new DateTime(2021, 11, 29, 11, 30, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 15, "Madison, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 11, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207", "Picnic in the Park", new DateTime(2021, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 61, "Milwaukee, WI", "This event will be a lot of fun! Make sure you come ready to enjoy yourself. Bring your own good attitude and be ready to learn and teach! We look forward to seeing you out there!", new DateTime(2021, 12, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), "1863 Gettysburg, PA", "The Basics of SAP Data Services by Sam Gassem", new DateTime(2021, 12, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), "Req" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
