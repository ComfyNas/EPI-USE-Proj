using EPI_USE.Data;
using EPI_USE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EPI_USE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var employeeCounts = _context.Employees
                            .GroupBy(e => e.ManagerId == null)
                            .Select(g => new
                            {
                                HasManager = !g.Key,  // true if employees have a manager, false if they don’t
                                Count = g.Count()
                            })
                            .ToList();

            var employeesWithManagerCount = employeeCounts.FirstOrDefault(e => e.HasManager)?.Count ?? 0;
            var employeesWithoutManagerCount = employeeCounts.FirstOrDefault(e => !e.HasManager)?.Count ?? 0;

            ViewBag.employeesWithManagerCount = employeesWithManagerCount;
            ViewBag.employeesWithoutManagerCount = employeesWithoutManagerCount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
