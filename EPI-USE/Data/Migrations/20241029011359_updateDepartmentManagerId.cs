using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateDepartmentManagerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           UPDATE Departments SET ManagerId = 4 WHERE DepartmentName = 'Human Resources';
           UPDATE Departments SET ManagerId = 5 WHERE DepartmentName = 'Information Technology';
           UPDATE Departments SET ManagerId = 6 WHERE DepartmentName = 'Sales';
           UPDATE Departments SET ManagerId = 7 WHERE DepartmentName = 'Marketing';
           UPDATE Departments SET ManagerId = 8 WHERE DepartmentName = 'Finance';
           UPDATE Departments SET ManagerId = 10 WHERE DepartmentName = 'Research and Development';
           UPDATE Departments SET ManagerId = 32 WHERE DepartmentName = 'Customer Support';
           UPDATE Departments SET ManagerId = 11 WHERE DepartmentName = 'Logistics';
           UPDATE Departments SET ManagerId = 12 WHERE DepartmentName = 'Legal';
           UPDATE Departments SET ManagerId = 19 WHERE DepartmentName = 'Administration';
          
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
