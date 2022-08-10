using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poort80Assignment.Migrations
{
    public partial class AddedDepartmentToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: 1);
        }
    }
}
