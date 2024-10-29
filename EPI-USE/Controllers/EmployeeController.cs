using EPI_USE.Data;
using EPI_USE.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EPI_USE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string searchQuery, string sortOrder)
        {
            // Start with the base query
            var employees = _context.Employees.Include(e => e.Manager).AsQueryable();

            // Search functionality (adjust this according to your fields)
            if (!string.IsNullOrEmpty(searchQuery))
            {
                employees = employees.Where(e => e.FirstName.Contains(searchQuery) ||
                                                  e.LastName.Contains(searchQuery) ||
                                                  e.Position.Contains(searchQuery) ||
                                                  (e.Manager.FirstName + " " + e.Manager.LastName).Contains(searchQuery));
            }

            // Sorting logic
            employees = sortOrder switch
            {
                "name_desc" => employees.OrderByDescending(e => e.LastName),
                "firstName" => employees.OrderBy(e => e.FirstName),
                "firstName_desc" => employees.OrderByDescending(e => e.FirstName),
                "position" => employees.OrderBy(e => e.Position),
                "position_desc" => employees.OrderByDescending(e => e.Position),
                _ => employees.OrderBy(e => e.LastName), // Default sorting by last name
            };

            // Project to ViewModel and execute the query
            var employeeList = await employees.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Position = e.Position,
                ManagerName = e.Manager != null ? e.Manager.FirstName + " " + e.Manager.LastName : "N/A"
            }).ToListAsync();

            return View(employeeList);
        }

        public IActionResult Create()
        {
            var model = new EmployeeViewModel
            {
                Departments = _context.Departments.Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                }).ToList()
            };

            return View(model);
        }

        // POST: Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

                var newEmployeeNumber = GenerateEmployeeNumber();
                var department = await _context.Departments
                    .Include(d => d.Manager)
                    .FirstOrDefaultAsync(d => d.DepartmentId == model.DepartmentId);

                if (department == null)
                {
                    // Handle case where the department is not found
                    ModelState.AddModelError("", "Department not found.");
                    return View(model);
                }
                var employee = new Employee
                {
                    EmployeeNumber = newEmployeeNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    DepartmentId = department.DepartmentId,
                    ManagerId = department.ManagerId,
                    HireDate = DateOnly.FromDateTime(DateTime.Now),
                    Email=model.Email,
                    
                };

               await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

                department.EmployeeCount++; // Increment the employee count
                await _context.SaveChangesAsync(); // Save changes to the database

                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction(nameof(Index));
            }

            model.Departments = _context.Departments.Select(d => new SelectListItem
            {
                Value = d.DepartmentId.ToString(),
                Text = d.DepartmentName
            }).ToList();

            return View(model);
        }

        private string GenerateEmployeeNumber()
        {
            // Fetch the current maximum employee number from the database
            var lastEmployeeNumber = _context.Employees
                .OrderByDescending(e => e.EmployeeNumber)
                .Select(e => e.EmployeeNumber)
                .FirstOrDefault();

            if (lastEmployeeNumber == null)
            {
                // If no employees exist, start from EPI-100
                return "EPI-100";
            }

            // Parse the current employee number to get the numeric part
            var currentNumber = int.Parse(lastEmployeeNumber.Split('-')[1]);

            // Increment the number and format the new employee number
            var newEmployeeNumber = $"EPI-{currentNumber + 1}";
            return newEmployeeNumber;
        }


        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department) // Include Department
                .Include(e => e.Manager) // Include Manager
                .Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeDetailsViewModel
                {                  
                    EmployeeNumber = e.EmployeeNumber,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    BirthDate = e.BirthDate,
                    Salary = e.Salary,
                    Position = e.Position,                   
                    DepartmentName = e.Department != null ? e.Department.DepartmentName : "N/A", // Safely access Department name                 
                    ManagerName = e.Manager != null ? e.Manager.FirstName + " " + e.Manager.LastName : "N/A", // Safely access Manager's name
                    HireDate = e.HireDate,
                    Email = e.Email
                })
                .FirstOrDefaultAsync(); // Make sure to use FirstOrDefaultAsync

            if (employee == null)
            {
                return NotFound(); // Return 404 if employee is not found
            }

            return View(employee); // Return the employee view model
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Manager)
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                DepartmentId = employee.DepartmentId,
                ManagerId = employee.ManagerId,
                Email = employee.Email,
                HireDate = employee.HireDate,
                ManagerName = employee.Manager != null ? employee.Manager.FirstName + " " + employee.Manager.LastName : "N/A",
                Departments = await _context.Departments.Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                }).ToListAsync()
            };

            return View(model);
        }


        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
        {
            if (id != model.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }

                // Update employee fields
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Position = model.Position;
                employee.Email = model.Email;
                employee.HireDate = model.HireDate;

                // Fetch the selected department and update ManagerId
                var department = await _context.Departments
                    .Include(d => d.Manager)
                    .FirstOrDefaultAsync(d => d.DepartmentId == model.DepartmentId);

                if (department == null)
                {
                    ModelState.AddModelError("", "Department not found.");
                    model.Departments = await _context.Departments.Select(d => new SelectListItem
                    {
                        Value = d.DepartmentId.ToString(),
                        Text = d.DepartmentName
                    }).ToListAsync();
                    return View(model);
                }

                employee.DepartmentId = department.DepartmentId;
                employee.ManagerId = department.ManagerId;

                try
                {
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            model.Departments = await _context.Departments.Select(d => new SelectListItem
            {
                Value = d.DepartmentId.ToString(),
                Text = d.DepartmentName
            }).ToListAsync();

            return View(model);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public IActionResult Delete(string email)
        {

            var model = new EmployeeDeleteViewModel
            {
                Email = email // Pre-fill the email if provided
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "Email cannot be null or empty.");
                return View(model);
            }

            var employee = await _context.Employees
                .Where(e => e.Email == model.Email)
                .Select(e => new EmployeeViewModel
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Position = e.Position
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                ModelState.AddModelError("", "Employee not found.");
                return View(model);
            }

            // Set the found employee details in the view model for confirmation
            model.Employee = employee;

            return View(model); // Redisplay view with employee details for confirmation
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Email cannot be null or empty.";
                return RedirectToAction(nameof(Delete));
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null)
            {
                TempData["ErrorMessage"] = "Employee not found.";
                return RedirectToAction(nameof(Delete));
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }


        // GET: Employee/Delete?email=someone@example.com
        //public async Task<IActionResult> Delete(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        return BadRequest("Email cannot be null or empty.");
        //    }

        //    var employee = await _context.Employees
        //        .FirstOrDefaultAsync(e => e.Email == email);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new EmployeeDetailsViewModel
        //    {
        //        EmployeeId = employee.EmployeeId,
        //        EmployeeNumber = employee.EmployeeNumber,
        //        FirstName = employee.FirstName,
        //        LastName = employee.LastName,
        //        Position = employee.Position,
        //        Email = employee.Email,
        //        DepartmentName = employee.Department?.DepartmentName,
        //        ManagerName = employee.Manager?.FirstName + " " + employee.Manager?.LastName
        //    };

        //    return View(model);
        //}

        //// POST: Employee/DeleteConfirmed
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        return BadRequest("Email cannot be null or empty.");
        //    }

        //    var employee = await _context.Employees
        //        .FirstOrDefaultAsync(e => e.Email == email);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    TempData["SuccessMessage"] = "Employee deleted successfully!";
        //    return RedirectToAction(nameof(Index));
        //}


        // GET: Employees

    }
}
