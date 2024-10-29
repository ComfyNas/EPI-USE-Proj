using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPI_USE.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedMoreEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int employeeNumberStart = 100;

            // Insert Employees with auto-generated EmployeeNumber
            migrationBuilder.Sql($@"
            INSERT INTO Employees (EmployeeNumber, FirstName, LastName, BirthDate, Salary, Position, DepartmentID, ManagerID, HireDate, Email) 
            VALUES 
            ('EPI-{employeeNumberStart++}', 'John', 'Doe', '1985-05-15', 75000.00, 'Software Developer', 22, Null, '2021-01-15', 'john.doe@example.com'),
            ('EPI-{employeeNumberStart++}', 'Jane', 'Smith', '1990-07-20', 65000.00, 'QA Engineer', 22, Null, '2021-02-15', 'jane.smith@example.com'),
            ('EPI-{employeeNumberStart++}', 'Michael', 'Johnson', '1988-03-12', 72000.00, 'Business Analyst', 25, Null, '2021-03-01', 'michael.johnson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Emily', 'Davis', '1992-11-29', 68000.00, 'Project Manager', 21, Null, '2021-04-01', 'emily.davis@example.com'),
            ('EPI-{employeeNumberStart++}', 'David', 'Brown', '1983-01-08', 80000.00, 'System Administrator', 21, Null, '2021-05-20', 'david.brown@example.com'),
            ('EPI-{employeeNumberStart++}', 'Sarah', 'Wilson', '1995-09-15', 62000.00, 'Network Engineer', 22, Null, '2021-06-15', 'sarah.wilson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Chris', 'Garcia', '1991-12-30', 77000.00, 'Product Owner', 23, Null, '2021-07-10', 'chris.garcia@example.com'),
            ('EPI-{employeeNumberStart++}', 'Anna', 'Martinez', '1987-06-04', 69000.00, 'UX Designer', 22, Null, '2021-08-05', 'anna.martinez@example.com'),
            ('EPI-{employeeNumberStart++}', 'Robert', 'Hernandez', '1993-08-17', 74000.00, 'Data Analyst', 22, Null, '2021-09-20', 'robert.hernandez@example.com'),
            ('EPI-{employeeNumberStart++}', 'Laura', 'Lopez', '1989-10-21', 61000.00, 'Web Developer', 22, Null, '2021-10-25', 'laura.lopez@example.com'),
            ('EPI-{employeeNumberStart++}', 'Daniel', 'Gonzalez', '1994-04-09', 73000.00, 'HR Specialist', 21, Null, '2021-11-15', 'daniel.gonzalez@example.com'),
            ('EPI-{employeeNumberStart++}', 'Megan', 'Wilson', '1986-05-27', 68000.00, 'Recruiter', 21, Null, '2021-12-10', 'megan.wilson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Kevin', 'Anderson', '1990-02-14', 77000.00, 'Finance Analyst', 25, Null, '2022-01-10', 'kevin.anderson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Jessica', 'Thomas', '1984-09-03', 72000.00, 'Accountant', 25, Null, '2022-02-15', 'jessica.thomas@example.com'),
            ('EPI-{employeeNumberStart++}', 'Ryan', 'Taylor', '1982-11-18', 80000.00, 'Operations Manager', 21, Null, '2022-03-12', 'ryan.taylor@example.com'),
            ('EPI-{employeeNumberStart++}', 'Sophia', 'Martinez', '1991-01-25', 65000.00, 'Supply Chain Coordinator', 28, Null, '2022-04-20', 'sophia.martinez@example.com'),
            ('EPI-{employeeNumberStart++}', 'Zachary', 'Jackson', '1993-03-14', 75000.00, 'Sales Executive', 23, Null, '2022-05-15', 'zachary.jackson@example.com'),
            ('EPI-{employeeNumberStart++}', 'Chloe', 'White', '1990-06-11', 62000.00, 'Customer Service Representative', 27, Null, '2022-06-05', 'chloe.white@example.com'),
            ('EPI-{employeeNumberStart++}', 'Joshua', 'Harris', '1988-02-20', 74000.00, 'Marketing Coordinator', 24, Null, '2022-07-25', 'joshua.harris@example.com'),
            ('EPI-{employeeNumberStart++}', 'Ava', 'Clark', '1985-04-19', 69000.00, 'Content Creator', 24, Null, '2022-08-30', 'ava.clark@example.com');
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
