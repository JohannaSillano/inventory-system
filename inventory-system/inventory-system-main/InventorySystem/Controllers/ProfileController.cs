using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ApplicationDbContext context, ILogger<ProfileController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Display the profile page for all employees, excluding deleted employees
    public IActionResult ProfilePage()
    {
        // Fetch only non-deleted employees
        var profiles = _context.Employees.Where(e => !e.IsDeleted).ToList();
        return View(profiles); // Pass the list of profiles to the view
    }

    // Display the form to add a new employee
    public IActionResult AddEmployee()
    {
        return View(); // Return the view for adding an employee
    }

    // Handle form submission to add a new employee
    [HttpPost]
    public IActionResult AddEmployee(Employee model)
    {
        if (!ModelState.IsValid)
        {
            return View("AddEmployee", model); // Return form with validation errors
        }

        var newEmployee = new Employee
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            Password = model.Password, // Remember to hash passwords in production
            Role = model.Role
        };

        _context.Employees.Add(newEmployee);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Employee added successfully!";
        return RedirectToAction("ProfilePage");
    }

    // Display the form to edit an existing employee
    public IActionResult EditEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null || employee.IsDeleted) // Check if employee is deleted
        {
            return NotFound(); // Return a 404 if the employee doesn't exist or is deleted
        }

        return View(employee); // Return the view with the employee data to be edited
    }

    // Handle form submission to update the employee information
    [HttpPost]
    public IActionResult EditEmployee(int id, Employee model)
    {
        if (!ModelState.IsValid)
        {
            return View("EditEmployee", model); // Return form with validation errors
        }

        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null || employee.IsDeleted) // Check if employee is deleted
        {
            return NotFound(); // Return a 404 if the employee doesn't exist or is deleted
        }

        // Update properties of the tracked entity
        employee.FirstName = model.FirstName;
        employee.LastName = model.LastName;
        employee.Email = model.Email;
        employee.PhoneNumber = model.PhoneNumber;
        employee.Address = model.Address;
        employee.Password = model.Password; // Remember to hash passwords in production
        employee.Role = model.Role;
        

        // Mark the entity as modified (only if it's not already tracked)
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Employee updated successfully!";
        return RedirectToAction("ProfilePage"); // Redirect to ProfilePage after successful update
    }

    // Handle soft deletion of an employee
    [HttpPost]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null || employee.IsDeleted)
        {
            TempData["ErrorMessage"] = "Employee not found or already deleted.";
            return RedirectToAction("ProfilePage");
        }

        // Perform soft delete by setting IsDeleted to true
        employee.IsDeleted = true;

        // Save changes
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Employee deleted successfully!";
        return RedirectToAction("ProfilePage");
    }
}
