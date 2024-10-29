namespace EPI_USE.Data
{
    public class Department
    {
       
            public int DepartmentId { get; set; }

            public string DepartmentName { get; set; } = null!;

            public int? ManagerId { get; set; }

            public int? EmployeeCount { get; set; }

            public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

            public virtual Employee? Manager { get; set; }
        
    }
}
