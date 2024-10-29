using Microsoft.AspNetCore.Mvc.Rendering;

namespace EPI_USE.ViewModel
{
    public class EmployeeDetailsViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; } = null!;
        public DateOnly HireDate { get; set; }
        public string? ManagerName { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
        public int? ManagerId { get; set; }
    }
}
