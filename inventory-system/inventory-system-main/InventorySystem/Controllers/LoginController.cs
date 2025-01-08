using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

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
            // Retrieve the user based on email and password
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}"); // Concatenating FirstName and LastName
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.ErrorMessage = "Invalid email or password";
            return View("LoginPage");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "Login");
        }
    }
}
