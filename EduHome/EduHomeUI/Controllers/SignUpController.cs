using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class SignUpController : Controller
    {
        private readonly AppDbContext _context;

        public SignUpController(AppDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users user)
        {
       
            if (ModelState.IsValid)
            {
                _context.users.Add(user);
                _context.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
