using EPI_USE.Data;
using EPI_USE.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EPI_USE.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var departments = await _context.Departments
        //        .Include(d => d.Manager)
        //        .Select(d => new DepartmentViewModel
        //        {
        //            DepartmentId = d.DepartmentId,
        //            DepartmentName = d.DepartmentName,
        //            ManagerId = d.ManagerId,
        //            ManagerName = d.Manager != null ? d.Manager.FirstName + " " + d.Manager.LastName : "N/A",
        //            EmployeeCount = d.EmployeeCount ?? 0
        //        })
        //        .ToListAsync();

        //    return View(departments);
        //}
        public async Task<IActionResult> Index(string searchQuery, string sortOrder)
        {
            // Start with the base query
            var departments = _context.Departments.Include(d => d.Manager).AsQueryable();

            // Search functionality
            if (!string.IsNullOrEmpty(searchQuery))
            {
                departments = departments.Where(d => d.DepartmentName.Contains(searchQuery) ||
                                                      (d.Manager.FirstName + " " + d.Manager.LastName).Contains(searchQuery));
            }

            // Sorting logic
            departments = sortOrder switch
            {
                "name_desc" => departments.OrderByDescending(d => d.DepartmentName),
                "manager" => departments.OrderBy(d => d.Manager.LastName),
                "manager_desc" => departments.OrderByDescending(d => d.Manager.LastName),
                _ => departments.OrderBy(d => d.DepartmentName), // Default sorting by department name
            };

            // Project to ViewModel and execute the query
            var departmentList = await departments.Select(d => new DepartmentViewModel
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                ManagerId = d.ManagerId,
                ManagerName = d.Manager != null ? d.Manager.FirstName + " " + d.Manager.LastName : "N/A",
                EmployeeCount = d.EmployeeCount ?? 0
            }).ToListAsync();

            return View(departmentList);
        }



        public IActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to find the employee by their email
                var manager = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Email == model.ManagerEmail);

                if (manager == null)
                {
                    // If no employee is found with that email, return an error message
                    ModelState.AddModelError("ManagerEmail", "No employee found with this email.");
                    return View(model);
                }

                // Create a new Department with the ManagerId assigned from the employee's ID
                var department = new Department
                {
                    DepartmentName = model.DepartmentName,
                    ManagerId = manager.EmployeeId // Set ManagerId based on found employee
                };

                _context.Departments.Add(department);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Department added successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Manager)
                .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            var model = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                ManagerEmail = department.Manager?.Email,
                EmployeeCount = department.EmployeeCount
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the department to update
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    return NotFound();
                }

                // Check if the ManagerEmail exists in the Employees table
                var manager = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Email == model.ManagerEmail);

                if (manager == null)
                {
                    // If the manager does not exist, add a validation message
                    ModelState.AddModelError("ManagerEmail", "No employee found with the provided email.");
                    return View(model);
                }

                // Update department details
                department.DepartmentName = model.DepartmentName;
                department.ManagerId = manager.EmployeeId; // Set the manager's ID
                department.EmployeeCount = model.EmployeeCount ?? department.EmployeeCount;

                // Save changes
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Department updated successfully!";
                return RedirectToAction(nameof(Index));
                //if (id != model.DepartmentId)
                //{
                //    return BadRequest();
                //}

                //if (ModelState.IsValid)
                //{
                //    var department = await _context.Departments.FindAsync(id);
                //    if (department == null)
                //    {
                //        return NotFound();
                //    }

                //    // Update department fields
                //    department.DepartmentName = model.DepartmentName;

                //    // Update ManagerId based on ManagerEmail
                //    var manager = await _context.Employees
                //        .FirstOrDefaultAsync(e => e.Email == model.ManagerEmail);

                //    department.ManagerId = manager?.EmployeeId; // Set ManagerId if manager is found

                //    try
                //    {
                //        await _context.SaveChangesAsync();
                //        TempData["SuccessMessage"] = "Department updated successfully!";
                //        return RedirectToAction(nameof(Index));
                //    }
                //    catch (DbUpdateException)
                //    {
                //        ModelState.AddModelError("", "Unable to save changes. Try again.");
                //    }
                //}

            }
                return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Manager)
                .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null)
                return NotFound();

            var viewModel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                ManagerId = department.ManagerId,
                ManagerName = department.Manager != null ? department.Manager.FirstName + " " + department.Manager.LastName : "N/A",
                EmployeeCount = department.EmployeeCount ?? 0
            };

            return View(viewModel);
        }
    }
}
