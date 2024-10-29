using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPI_USE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OptionGroup> OptionGroups { get; set; }
        public DbSet<Option> Options { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
       .HasOne(e => e.Department)
       .WithMany(d => d.Employees)
       .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
    .HasOne(e => e.Manager)
    .WithMany()
    .HasForeignKey(e => e.ManagerId)
    .OnDelete(DeleteBehavior.Restrict);
       
        //// Seed Departments
        //modelBuilder.Entity<Department>().HasData(
        //    new Department { DepartmentId = 1, DepartmentName = "Human Resources" },
        //    new Department { DepartmentId = 2, DepartmentName = "Information Technology" },
        //    new Department { DepartmentId = 3, DepartmentName = "Sales" },
        //    new Department { DepartmentId = 4, DepartmentName = "Marketing" },
        //    new Department { DepartmentId = 5, DepartmentName = "Finance" },
        //    new Department { DepartmentId = 6, DepartmentName = "Research and Development" },
        //    new Department { DepartmentId = 7, DepartmentName = "Customer Support" },
        //    new Department { DepartmentId = 8, DepartmentName = "Logistics" },
        //    new Department { DepartmentId = 9, DepartmentName = "Legal" },
        //    new Department { DepartmentId = 10, DepartmentName = "Administration" }
        //);

        //// Seed Employees
        //modelBuilder.Entity<Employee>().HasData(
        //    new Employee { EmployeeId = 1, FirstName = "Alice", LastName = "Johnson", BirthDate = new DateOnly(1985, 4, 12), Salary = 60000.00m, Position = "HR Manager", DepartmentId = 1, ManagerId = null, HireDate = new DateOnly(2010, 1, 15), Email = "alice.johnson@example.com" },
        //    new Employee { EmployeeId = 2, FirstName = "Bob", LastName = "Smith", BirthDate = new DateOnly(1990, 6, 23), Salary = 75000.00m, Position = "IT Specialist", DepartmentId = 2, ManagerId = 1, HireDate = new DateOnly(2015, 3, 20), Email = "bob.smith@example.com" },
        //    new Employee { EmployeeId = 3, FirstName = "Charlie", LastName = "Brown", BirthDate = new DateOnly(1992, 8, 5), Salary = 55000.00m, Position = "Sales Executive", DepartmentId = 3, ManagerId = 1, HireDate = new DateOnly(2018, 7, 10), Email = "charlie.brown@example.com" },
        //    new Employee { EmployeeId = 4, FirstName = "Diana", LastName = "Ross", BirthDate = new DateOnly(1988, 11, 15), Salary = 70000.00m, Position = "Marketing Manager", DepartmentId = 4, ManagerId = 2, HireDate = new DateOnly(2017, 5, 12), Email = "diana.ross@example.com" },
        //    new Employee { EmployeeId = 5, FirstName = "Edward", LastName = "Norton", BirthDate = new DateOnly(1982, 2, 28), Salary = 90000.00m, Position = "Finance Director", DepartmentId = 5, ManagerId = null, HireDate = new DateOnly(2012, 9, 30), Email = "edward.norton@example.com" },
        //    new Employee { EmployeeId = 6, FirstName = "Fiona", LastName = "Green", BirthDate = new DateOnly(1995, 9, 10), Salary = 48000.00m, Position = "Support Agent", DepartmentId = 7, ManagerId = 1, HireDate = new DateOnly(2019, 1, 5), Email = "fiona.green@example.com" },
        //    new Employee { EmployeeId = 7, FirstName = "George", LastName = "Lucas", BirthDate = new DateOnly(1975, 12, 20), Salary = 85000.00m, Position = "R&D Manager", DepartmentId = 6, ManagerId = 5, HireDate = new DateOnly(2013, 6, 15), Email = "george.lucas@example.com" },
        //    new Employee { EmployeeId = 8, FirstName = "Hannah", LastName = "Montana", BirthDate = new DateOnly(1991, 5, 1), Salary = 52000.00m, Position = "Logistics Coordinator", DepartmentId = 8, ManagerId = 1, HireDate = new DateOnly(2020, 2, 25), Email = "hannah.montana@example.com" },
        //    new Employee { EmployeeId = 9, FirstName = "Ian", LastName = "Curtis", BirthDate = new DateOnly(1980, 10, 9), Salary = 95000.00m, Position = "Legal Advisor", DepartmentId = 9, ManagerId = null, HireDate = new DateOnly(2008, 11, 11), Email = "ian.curtis@example.com" },
        //    new Employee { EmployeeId = 10, FirstName = "Judy", LastName = "Garland", BirthDate = new DateOnly(1983, 3, 15), Salary = 72000.00m, Position = "Admin Assistant", DepartmentId = 10, ManagerId = 9, HireDate = new DateOnly(2016, 4, 30), Email = "judy.garland@example.com" },
        //     new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1985, 5, 15), Salary = 75000.00m, Position = "Software Developer", DepartmentId = 1, ManagerId = 102, HireDate = new DateOnly(2021, 1, 15), Email = "john.doe@example.com" });
        //new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith", BirthDate = new DateOnly(1990, 7, 20), Salary = 65000.00m, Position = "QA Engineer", DepartmentId = 1, ManagerId = 102, HireDate = new DateOnly(2021, 2, 15), Email = "jane.smith@example.com" },
        //new Employee { EmployeeId = 3, FirstName = "Michael", LastName = "Johnson", BirthDate = new DateOnly(1988, 3, 12), Salary = 72000.00m, Position = "Business Analyst", DepartmentId = 2, ManagerId = 103, HireDate = new DateOnly(2021, 3, 1), Email = "michael.johnson@example.com" },
        //new Employee { EmployeeId = 4, FirstName = "Emily", LastName = "Davis", BirthDate = new DateOnly(1992, 11, 29), Salary = 68000.00m, Position = "Project Manager", DepartmentId = 2, ManagerId = 103, HireDate = new DateOnly(2021, 4, 1), Email = "emily.davis@example.com" },
        //new Employee { EmployeeId = 5, FirstName = "David", LastName = "Brown", BirthDate = new DateOnly(1983, 1, 8), Salary = 80000.00m, Position = "System Administrator", DepartmentId = 3, ManagerId = 104, HireDate = new DateOnly(2021, 5, 20), Email = "david.brown@example.com" },
        //new Employee { EmployeeId = 6, FirstName = "Sarah", LastName = "Wilson", BirthDate = new DateOnly(1995, 9, 15), Salary = 62000.00m, Position = "Network Engineer", DepartmentId = 3, ManagerId = 104, HireDate = new DateOnly(2021, 6, 15), Email = "sarah.wilson@example.com" },
        //new Employee { EmployeeId = 7, FirstName = "Chris", LastName = "Garcia", BirthDate = new DateOnly(1991, 12, 30), Salary = 77000.00m, Position = "Product Owner", DepartmentId = 4, ManagerId = 105, HireDate = new DateOnly(2021, 7, 10), Email = "chris.garcia@example.com" },
        //new Employee { EmployeeId = 8, FirstName = "Anna", LastName = "Martinez", BirthDate = new DateOnly(1987, 6, 4), Salary = 69000.00m, Position = "UX Designer", DepartmentId = 4, ManagerId = 105, HireDate = new DateOnly(2021, 8, 5), Email = "anna.martinez@example.com" }
        //    );
    }


}
}
