using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addEmployeeManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           UPDATE Employees SET ManagerId =32  WHERE Email = 'fiona.green@example.com';
           UPDATE Employees SET ManagerId =19  WHERE Email = 'judy.garland@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'john.doe@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'jane.smith@example.com';
           UPDATE Employees SET ManagerId =8  WHERE Email = 'michael.johnson@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'sarah.wilson@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'anna.martinez@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'robert.hernandez@example.com';
           UPDATE Employees SET ManagerId =5  WHERE Email = 'laura.lopez@example.com';
           UPDATE Employees SET ManagerId =4  WHERE Email = 'daniel.gonzalez@example.com';
           UPDATE Employees SET ManagerId =4  WHERE Email = 'megan.wilson@example.com';
           UPDATE Employees SET ManagerId =8  WHERE Email = 'kevin.anderson@example.com';
           UPDATE Employees SET ManagerId =8  WHERE Email = 'jessica.thomas@example.com';
           UPDATE Employees SET ManagerId =11  WHERE Email = 'sophia.martinez@example.com';
           UPDATE Employees SET ManagerId =7  WHERE Email = 'joshua.harris@example.com';
           UPDATE Employees SET ManagerId =7  WHERE Email = 'ava.clark@example.com';
           UPDATE Employees SET ManagerId =32  WHERE Email = 'fiona.green@example.com';
                 
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
