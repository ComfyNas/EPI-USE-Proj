using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            int employeeNumberStart = 100;
            migrationBuilder.Sql($@"
            INSERT INTO Employees (EmployeeNumber, FirstName, LastName, BirthDate, Salary, Position, DepartmentID, ManagerID, HireDate, Email) 
            VALUES 

            ('EPI-{employeeNumberStart++}', 'Alice', 'Johnson', '1985-04-12', 60000.00, 'HR Manager', 21, NULL, '2010-01-15', 'alice.johnson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Bob', 'Smith', '1990-06-23', 75000.00, 'IT Specialist', 22, NULL ,'2015-03-20', 'bob.smith@example.com'),
            ('EPI-{employeeNumberStart++}', 'Charlie', 'Brown', '1992-08-05', 55000.00, 'Sales Executive', 23, NULL, '2018-07-10', 'charlie.brown@example.com'),
            ('EPI-{employeeNumberStart++}', 'Diana', 'Ross', '1988-11-15', 70000.00, 'Marketing Manager', 24, NULL, '2017-05-12', 'diana.ross@example.com'),
            ('EPI-{employeeNumberStart++}', 'Edward', 'Norton', '1982-02-28', 90000.00, 'Finance Director', 25, NULL, '2012-09-30', 'edward.norton@example.com'),
            ('EPI-{employeeNumberStart++}', 'Fiona', 'Green', '1995-09-10', 48000.00, 'Support Agent', 27, NULL, '2019-01-05', 'fiona.green@example.com'),
            ('EPI-{employeeNumberStart++}', 'George', 'Lucas', '1975-12-20', 85000.00, 'R&D Manager', 26, NULL, '2013-06-15', 'george.lucas@example.com'),
            ('EPI-{employeeNumberStart++}', 'Hannah', 'Montana', '1991-05-01', 52000.00, 'Logistics Coordinator', 28, NULL, '2020-02-25', 'hannah.montana@example.com'),
            ('EPI-{employeeNumberStart++}', 'Ian', 'Curtis', '1980-10-09', 95000.00, 'Legal Advisor', 29, NULL, '2008-11-11', 'ian.curtis@example.com'),
            ('EPI-{employeeNumberStart++}', 'Judy', 'Garland', '1983-03-15', 72000.00, 'Admin Assistant', 30, NULL, '2016-04-30', 'judy.garland@example.com');
        ");

            // Update Employee Counts
            migrationBuilder.Sql("UPDATE Departments SET EmployeeCount = (SELECT COUNT(*) FROM Employees WHERE Employees.DepartmentID = Departments.DepartmentID);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
