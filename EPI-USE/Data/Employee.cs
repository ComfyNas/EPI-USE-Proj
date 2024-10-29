namespace EPI_USE.Data
{
 
        public partial class Employee
        {
            public int EmployeeId { get; set; }

            public string? EmployeeNumber { get; set; }

            public string FirstName { get; set; } = null!;

            public string LastName { get; set; } = null!;

            public DateOnly BirthDate { get; set; }

            public decimal Salary { get; set; }

            public string Position { get; set; } = null!;

            public int DepartmentId { get; set; }

            public int? ManagerId { get; set; }

            public DateOnly HireDate { get; set; }

            public string Email { get; set; } = null!;

            public virtual Department Department { get; set; } = null!;
            public Employee? Manager { get; set; }

            public virtual ICollection<Department> Departments { get; set; } = new List<Department>();


        }
    }

