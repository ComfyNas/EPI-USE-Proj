using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBoardMemberDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Departments (DepartmentName) VALUES ('Board Member');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
