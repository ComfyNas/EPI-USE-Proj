using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateEmpCountBM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Departments SET EmployeeCount = (SELECT COUNT(*) FROM Employees WHERE Employees.DepartmentId = Departments.DepartmentId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
