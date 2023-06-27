using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Users user)
    {
        if (ModelState.IsValid)
        {
            bool isAuthenticated = AuthenticateUser(user.Username, user.Password);

            if (isAuthenticated)
            {
                bool isAdmin = CheckAdminStatus(user.Username);
                if (isAdmin)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "EHMasterPanel" });
                }

                return RedirectToAction("Index", "Home");
            }
        }

        return View(user);
    }
    private bool CheckAdminStatus(string username)
    {
        bool isAdmin = _context.users.Any(u => u.Username == username && u.IsAdmin);
        return isAdmin;
    }
    private bool AuthenticateUser(string username, string password)
    {
        bool isAuthenticated = _context.users.Any(u => u.Username == username && u.Password == password);
        return isAuthenticated;
    }
}
