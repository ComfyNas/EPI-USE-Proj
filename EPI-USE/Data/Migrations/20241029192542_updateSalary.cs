using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           UPDATE Employees SET ManagerId = 50 WHERE Email = 'chloe.white@example.com';
           UPDATE Employees SET Salary = 89000 WHERE Email = 'akashi.s@example.com';
           UPDATE Employees SET Salary = 92000 WHERE Email = 'r.owski@example.com';
           UPDATE Employees SET Salary = 96000 WHERE Email = 'willieD@example.com';
            
          
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
