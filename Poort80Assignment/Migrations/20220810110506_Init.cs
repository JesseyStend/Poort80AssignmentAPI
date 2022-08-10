using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poort80Assignment.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Development department", "Development" });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Inplan department", "Inplan" });

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
                values: new object[] { 3, 1, "Sary t'Lam" });

            migrationBuilder.CreateIndex(
                name: "IX_employees_DepartmentId",
                table: "employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
