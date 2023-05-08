using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_access.Migrations
{
    public partial class SeedAlarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alarms",
                columns: new[] { "ID", "Time", "Title" },
                values: new object[] { 1, new DateTime(2023, 5, 8, 17, 10, 0, 0, DateTimeKind.Unspecified), "Example alarm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alarms",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
