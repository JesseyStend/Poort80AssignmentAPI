using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poort80Assignment.Migrations
{
    public partial class DepartmentSimpleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees");

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 1, 1, "Jessey Stend" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 2, 1, "Dennis Jongbloed" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 3, 2, "Sary t'Lam" });

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees");

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 1, 1, "Jessey Stend" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 2, 1, "Dennis Jongbloed" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[] { 3, 2, "Sary t'Lam" });

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
