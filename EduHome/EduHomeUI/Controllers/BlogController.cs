using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            var blogs = _context.blogs.OrderByDescending(b => b.Date).Take(9).ToList();
            return View(blogs);
        }
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _context.blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
