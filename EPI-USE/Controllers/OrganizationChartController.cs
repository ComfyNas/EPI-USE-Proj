using EPI_USE.Data;
using EPI_USE.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EPI_USE.Controllers
{
    public class OrganizationChartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationChartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
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

        //[HttpGet]
        //public JsonResult GetEmpChartData()
        //{

        //        var empChartList = _context.Employees.Select(e => new EmployeeDetailsViewModel
        //        {
        //            EmployeeId = e.EmployeeId,
        //            FirstName = e.FirstName,
        //            LastName = e.LastName,
        //            Position = e.Position, 
        //            Email = e.Email,
        //            ManagerId = e.ManagerId, 

        //        }).ToList();

        //        return Json(empChartList);


        //}
    }
}
