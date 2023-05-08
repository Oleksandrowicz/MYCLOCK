using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_access.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageNote = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "Date", "MessageNote" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go to dantest" },
                    { 2, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exam Task" },
                    { 3, new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sait potato" },
                    { 4, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "by car" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
