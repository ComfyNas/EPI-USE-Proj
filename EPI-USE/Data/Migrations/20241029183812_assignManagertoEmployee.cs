using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class assignManagertoEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           UPDATE Employees SET ManagerId = 44 WHERE Email = 'alice.johnson@example.com';
           UPDATE Employees SET ManagerId = 45 WHERE Email = 'bob.smith@example.com';
           UPDATE Employees SET ManagerId = 46 WHERE Email = 'charlie.brown@example.com';
           UPDATE Employees SET ManagerId = 47 WHERE Email = 'diana.ross@example.com';
           UPDATE Employees SET ManagerId = 48 WHERE Email = 'edward.norton@example.com';
           UPDATE Employees SET ManagerId = 49 WHERE Email = 'george.lucas@example.com';
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'hannah.montana@example.com';
           UPDATE Employees SET ManagerId = 51 WHERE Email = 'ian.curtis@example.com';
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'emily.davis@example.com';
           UPDATE Employees SET ManagerId = 52 WHERE Email = 'david.brown@example.com';
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'chris.garcia@example.com';
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'ryan.taylor@example.com';
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'zachary.jackson@example.com';
           UPDATE Employees SET Salary = 12000 WHERE Email = 'rodney.s@example.com';
           UPDATE Employees SET Salary = 120000 WHERE Email = 'chris.L@example.com';
           UPDATE Employees SET Salary = 80000 WHERE Email = 'R.w@example.com';
           UPDATE Employees SET Salary = 85000 WHERE Email = 'John23@example.com';
           UPDATE Employees SET Salary = 5000 WHERE Email = 'strydom.z@something.com';
           UPDATE Employees SET Salary = 10000 WHERE Email = 'westWillie@example.com';
           UPDATE Employees SET Salary = 87000 WHERE Email = 'Tanya.TS@example.com';
           UPDATE Employees SET Salary = 93000 WHERE Email = 'aomine@example.com';
           UPDATE Employees SET Salary = 89000 WHERE Email = 'lori.c@example.com';
           UPDATE Employees SET Salary = 86000 WHERE Email = 'shinalui@example.com';
           UPDATE Employees SET Salary = 91000 WHERE Email = 'leonaldo@gmail.com';
           UPDATE Employees SET Salary = 90000 WHERE Email = 'lingard@example.com';
          
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
