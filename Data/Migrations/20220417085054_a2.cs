using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "User",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS",
                column: "Firstname",
                value: "NGuyen Van A");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS1",
                column: "Firstname",
                value: "NGuyen Van B");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS2",
                column: "Firstname",
                value: "NGuyen Van C");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS",
                column: "Fullname",
                value: "NGuyen Van A");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS1",
                column: "Fullname",
                value: "NGuyen Van B");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UId",
                keyValue: "AVASASSAS2",
                column: "Fullname",
                value: "NGuyen Van C");
        }
    }
}
