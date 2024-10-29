using EPI_USE.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EPI_USE.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = null!;
    public int? ManagerId { get; set; }
    public int? EmployeeCount { get; set; } // Make nullable
        public string ManagerEmail {  get; set; }=string.Empty;
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual Employee? Manager { get; set; }
    public string? ManagerName { get; set; }
        public List<DepartmentViewModel> Children { get; set; } = new List<DepartmentViewModel>();
    }
}
