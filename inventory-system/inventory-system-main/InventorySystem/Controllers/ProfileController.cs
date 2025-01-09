using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ApplicationDbContext context, ILogger<ProfileController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Display the profile page
// Display the profile page for all employees
public IActionResult ProfilePage()
{
        // Fetch all employee profiles
    var profiles = _context.EmployeeProfiles.ToList();
    return View(profiles); // Pass the list of profiles to the view
}


    public IActionResult EditProfile()
    {
        // Retrieve the logged-in user's ID from session (as string) and convert to int
        var userIdString = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
        {
            // If the session doesn't contain a valid UserId, redirect to login page
            return RedirectToAction("LoginPage", "Login");
        }

        var profile = _context.EmployeeProfiles.FirstOrDefault(p => p.Id == userId);
        var user = _context.Employees.FirstOrDefault(u => u.Id == userId);

        if (profile != null)
        {
            // Pass the role of the user to the view as well
            ViewBag.UserRole = user?.Role; // Store the role in ViewBag
        }

        return View(profile);
    }

    // Update profile
    [HttpPost]
    public IActionResult UpdateProfile(EmployeeProfile model)
    {
        if (!ModelState.IsValid)
        {
            return View("EditProfile", model);
        }

        // Retrieve the logged-in user's ID from session (as string) and convert to int
        var userIdString = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
        {
            // If the session doesn't contain a valid UserId, redirect to login page
            return RedirectToAction("LoginPage", "Login");
        }

        var profile = _context.EmployeeProfiles.FirstOrDefault(p => p.Id == userId);
        var user = _context.Employees.FirstOrDefault(u => u.Id == userId);

        if (profile != null && user != null)
        {
            // Update profile information
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.PhoneNumber = model.PhoneNumber;
            profile.Address = model.Address;
            profile.Email = model.Email;

            // Update user name, email, and role if changed
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            _context.SaveChanges();
            TempData["SuccessMessage"] = "Profile updated successfully!";
        }

        return RedirectToAction("ProfilePage");
    }

    // Display the EditPasswordPage
    public IActionResult ChangePasswordPage()
    {
        return View();
    }

    // Change or Update the password
    [HttpPost]
    public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
    {
        // Retrieve the logged-in user's ID from session (as string) and convert to int
        var userIdString = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
        {
            return RedirectToAction("LoginPage", "Login");
        }

        var user = _context.Employees.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("ChangePasswordPage");
        }

        // Check if the current password matches the user's password (this is without hashing)
        if (user.Password != currentPassword)
        {
            TempData["ErrorMessage"] = "Current password is incorrect.";
            return RedirectToAction("ChangePasswordPage");
        }

        // Check if the new password and confirm password match
        if (newPassword != confirmPassword)
        {
            TempData["ErrorMessage"] = "New password and confirm password do not match.";
            return RedirectToAction("ChangePasswordPage");
        }

        // Update the password without hashing it in the Users table
        user.Password = newPassword;

        _context.SaveChanges();

        TempData["SuccessMessage"] = "Password changed successfully!";
        return RedirectToAction("ProfilePage");
    }
}
