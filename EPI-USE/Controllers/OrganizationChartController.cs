using EPI_USE.Data;
using EPI_USE.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EPI_USE.Controllers
{
    public class OrganizationChartController : Controller
    {
        private readonly ApplicationDbContext _context; // Replace with your actual DbContext

        public OrganizationChartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() // This will render the OrganizationChart view
        {
            return View();
        }

        public JsonResult AjaxMethod()
        {
            List<object> chartData = new List<object>();
            string query = "SELECT * FROM Employees";
            string constr = "Server=LAPTOP-RFTR69D9\\SQLEXPRESS;Database=EPI-USE_empDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                            sdr["EmployeeId"], sdr["EmployeeNumber"], sdr["FirstName"] , sdr["LastName"], sdr["BirthDate"], sdr["Salary"],sdr["Position"], sdr["DepartmentId"],sdr["ManagerId"],sdr["HireDate"], sdr["Email"]
                            });
                        }
                    }
                    con.Close();
                }
            }

            return Json(chartData);
        }

        //[HttpPost]
        //public JsonResult GetEmpChartData()
        //{
        //    var empChartList = _context.Employees.Select(e => new EmployeeDetailsViewModel
        //    {
        //        EmployeeId = e.EmployeeId,
        //        EmployeeNumber=e.EmployeeNumber,
        //        FirstName = e.FirstName,
        //        LastName = e.LastName,
        //        Position = e.Position, // Assuming Designation maps to Position
        //        Email = e.Email,
        //        BirthDate=e.BirthDate,
        //        Salary=e.Salary,
        //        HireDate=e.HireDate,
        //        DepartmentId=e.DepartmentId,
        //        ManagerId = e.ManagerId, // Assuming ReportID is the ManagerId
        //    }).ToList();

        //    return Json(empChartList);
        //}
    }
}
