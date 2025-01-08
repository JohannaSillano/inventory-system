using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InventorySystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult LoginPage()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPage(string email, string password)
        {
            // Use ToLower() for case-insensitive email comparison
            var user = _context.Employees
                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                // Password validation (In production, consider hashing passwords for security)
                if (user.Password == password)  // In a real scenario, use hashed password comparison
                {
                    // Check if the user is an admin (case-insensitive role comparison)
                    if (user.Role.ToLower() == "admin")
                    {
                        // Set session values for the logged-in user
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");

                        // Redirect to the Dashboard
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        // If user is not an admin, show an error message
                        ViewBag.ErrorMessage = "You do not have admin access.";
                        return View("LoginPage");
                    }
                }
                else
                {
                    // If the password is incorrect
                    ViewBag.ErrorMessage = "Invalid email or password.";
                    return View("LoginPage");
                }
            }

            // If the user is not found in the database
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View("LoginPage");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            // Clear session data on logout
            HttpContext.Session.Clear();

            // Redirect to login page
            return RedirectToAction("LoginPage", "Login");
        }
    }
}
