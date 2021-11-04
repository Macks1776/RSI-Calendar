using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSI_Calendar.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "ID", "EventID", "Link", "Title" },
                values: new object[,]
                {
                    { 6, 6, "https://google.com", "Google" },
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
                    { 29, 29, "https://google.com", "Google" },
                    { 18, 18, "https://google.com", "Google" },
                    { 16, 16, "https://google.com", "Google" },
                    { 15, 15, "https://google.com", "Google" },
                    { 14, 14, "https://google.com", "Google" },
                    { 13, 13, "https://google.com", "Google" },
                    { 12, 12, "https://google.com", "Google" },
                    { 11, 11, "https://google.com", "Google" },
                    { 10, 10, "https://google.com", "Google" },
                    { 9, 9, "https://google.com", "Google" },
                    { 8, 8, "https://google.com", "Google" },
                    { 7, 7, "https://google.com", "Google" },
                    { 17, 17, "https://google.com", "Google" },
                    { 30, 30, "https://google.com", "Google" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 7, "Augusta, GA", "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!", new DateTime(2021, 11, 19, 23, 8, 0, 0, DateTimeKind.Unspecified), "755 Battery Ave SE, Atlanta, GA 30339", "NLCS Game 2", new DateTime(2021, 11, 19, 20, 8, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 29, "Augusta, GA", "Merry Christmas Eve!", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Christmas Eve", new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 28, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 9", new DateTime(2021, 12, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 27, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 8", new DateTime(2021, 12, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 26, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 7", new DateTime(2021, 12, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 25, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 6", new DateTime(2021, 12, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 24, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 5", new DateTime(2021, 12, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 23, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 4", new DateTime(2021, 12, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 22, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 3", new DateTime(2021, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 21, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 2", new DateTime(2021, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 20, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 12, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 1", new DateTime(2021, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 30, "Augusta, GA", "Merry Christmas Everyone!", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Christmas Day", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 19, "Augusta, GA", "Tell your family and friends how thankful for them that you are!", new DateTime(2021, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "Thanksgiving", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 17, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 7", new DateTime(2021, 11, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 16, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 6", new DateTime(2021, 11, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 15, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 5", new DateTime(2021, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Branch", "Description", "EndDate", "Location", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { 14, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 4", new DateTime(2021, 11, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 13, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 3", new DateTime(2021, 11, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 12, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 2", new DateTime(2021, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 11, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 1", new DateTime(2021, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 10, "Augusta, GA", "Wear your best costume!", new DateTime(2021, 11, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), "1450 Greene St #200, Augusta, GA 30901", "Costume Day!", new DateTime(2021, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 9, "Augusta, GA", "Tech Tuesday training on what's new in .NET 5.", new DateTime(2021, 11, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), "The Alan Turing room", ".NET 5: Whats New?!", new DateTime(2021, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Edu" },
                    { 8, "Augusta, GA", "We're having a good old fashioned cookout so feel free to bring the whole family!", new DateTime(2021, 11, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "3012 Peach Orchard Rd, Augusta, GA 30906", "Cookout", new DateTime(2021, 11, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fam" },
                    { 18, "Augusta, GA", "Lorem ipsom dolar", new DateTime(2021, 11, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), "Second door on the right", "Sample 8", new DateTime(2021, 11, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fun" },
                    { 6, "Augusta, GA", "Sample Description", new DateTime(2021, 11, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), "1234 Sample St, Sampleton, GA 12345", "Sample Event", new DateTime(2021, 11, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), "Req" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Attachments",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 10, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
