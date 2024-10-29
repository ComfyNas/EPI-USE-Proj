using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EPI_USE.ViewModel
{
    public class EmployeeViewModel
    {
      
            public int EmployeeId { get; set; }
            
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Position { get; set; }
            public DateOnly BirthDate { get; set; }
            public decimal Salary { get; set; }
           
            public DateOnly HireDate { get; set; }
            public string? ManagerName { get; set; }
            public int? DepartmentId { get; set; }
            public string Email { get; set; }
            public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
            public int? ManagerId { get; set; }
     }
    
}

