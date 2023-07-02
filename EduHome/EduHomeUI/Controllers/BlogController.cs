using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
