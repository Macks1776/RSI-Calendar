using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSI_Calendar.Migrations
{
    public partial class Initial : Migration
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
                    { 1, 1, "https://google.com", "Google" },
                    { 29, 29, "https://google.com", "Google" },
                    { 28, 28, "https://google.com", "Google" },
                    { 27, 27, "https://google.com", "Google" },
                    { 26, 26, "https://google.com", "Google" },
                    { 25, 25, "https://google.com", "Google" },
                    { 24, 24, "https://google.com", "Google" },
                    { 23, 23, "https://google.com", "Google" },
                    { 22, 22, "https://google.com", "Google" },
                    { 21, 21, "https://google.com", "Google" },
                    { 20, 20, "https://google.com", "Google" },
                    { 19, 19, "https://google.com", "Google" },
                    { 18, 18, "https://google.com", "Google" },
                    { 17, 17, "https://google.com", "Google" },
                    { 16, 16, "https://google.com", "Google" },
                    { 30, 30, "https://google.com", "Google" },
                    { 14, 14, "https://google.com", "Google" },
                    { 2, 1, "https://nfl.com", "NFL" },
                    { 3, 2, "https://tomahawktake.com/2021/10/17/atlanta-braves-vs-dodgers-nlcs-game-2-lineup-odds-prediction-pick-watch/", "Game Preview" },
                    { 4, 2, "https://youtu.be/ZxZOz5C1BbE", "Game Highlights" },
                    { 15, 15, "https://google.com", "Google" },
                    { 6, 6, "https://google.com", "Google" },
                    { 7, 7, "https://google.com", "Google" },
                    { 5, 4, "https://youtu.be/zjVgQNfAEOs", "IAmTimCorey - Big Changes in .NET 5, C# 9, and Visual Studio 2019 (v16.8)" },
                    { 9, 9, "https://google.com", "Google" },
                    { 10, 10, "https://google.com", "Google" },
                    { 11, 11, "https://google.com", "Google" },
                    { 12, 12, "https://google.com", "Google" },
                    { 13, 13, "https://google.com", "Google" },
                    { 8, 8, "https://google.com", "Google" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 17, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 7", new DateTime(2021, 11, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 18, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 8", new DateTime(2021, 11, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 19, "Augusta, GA", "Tell your family and friends how thankful for them that you are!", new DateTime(2021, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Thanksgiving", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 20, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 1", new DateTime(2021, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 21, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 2", new DateTime(2021, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 28, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 9", new DateTime(2021, 12, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 23, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 4", new DateTime(2021, 12, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 24, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 5", new DateTime(2021, 12, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 25, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 6", new DateTime(2021, 12, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 26, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 7", new DateTime(2021, 12, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 27, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 8", new DateTime(2021, 12, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 16, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 6", new DateTime(2021, 11, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 22, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 3", new DateTime(2021, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 15, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 5", new DateTime(2021, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 8, "Augusta, GA", "We're having a good old fashioned cookout so feel free to bring the whole family!", new DateTime(2021, 11, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "3012 Peach Orchard Rd, Augusta, GA 30906", "Cookout", new DateTime(2021, 11, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 13, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 3", new DateTime(2021, 11, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 12, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 2", new DateTime(2021, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 11, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 1", new DateTime(2021, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 10, "Augusta, GA", "Wear your best costume!", new DateTime(2021, 11, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), "1450 Greene St #200, Augusta, GA 30901", "Costume Day!", new DateTime(2021, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 9, "Augusta, GA", "Tech Tuesday training on what's new in .NET 5.", new DateTime(2021, 11, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), "The Alan Turing room", ".NET 5: Whats New?!", new DateTime(2021, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 7, "Augusta, GA", "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!", new DateTime(2021, 11, 19, 23, 8, 0, 0, DateTimeKind.Unspecified), "755 Battery Ave SE, Atlanta, GA 30339", "NLCS Game 2", new DateTime(2021, 11, 19, 20, 8, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 6, "Augusta, GA", "Sample Description", new DateTime(2021, 11, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), "1234 Sample St, Sampleton, GA 12345", "Sample Event", new DateTime(2021, 11, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 5, "Augusta, GA", "Wear your best costume!", new DateTime(2021, 11, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), "1450 Greene St #200, Augusta, GA 30901", "Costume Day!", new DateTime(2021, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 4, "Augusta, GA", "Tech Tuesday training on what's new in .NET 5.", new DateTime(2021, 10, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), "The Alan Turing room", ".NET 5: Whats New?!", new DateTime(2021, 10, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 3, "Augusta, GA", "We're having a good old fashioned cookout so feel free to bring the whole family!", new DateTime(2021, 10, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "3012 Peach Orchard Rd, Augusta, GA 30906", "Cookout", new DateTime(2021, 10, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 2, "Augusta, GA", "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!", new DateTime(2021, 10, 19, 23, 8, 0, 0, DateTimeKind.Unspecified), "755 Battery Ave SE, Atlanta, GA 30339", "NLCS Game 2", new DateTime(2021, 10, 19, 20, 8, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 1, "Augusta, GA", "Sample Description", new DateTime(2021, 10, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), "1234 Sample St, Sampleton, GA 12345", "Sample Event", new DateTime(2021, 10, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), "Req" },
                    { 29, "Augusta, GA", "Merry Christmas Eve!", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Christmas Eve", new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 14, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 4", new DateTime(2021, 11, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 30, "Augusta, GA", "Merry Christmas Everyone!", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Christmas Day", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" }
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
