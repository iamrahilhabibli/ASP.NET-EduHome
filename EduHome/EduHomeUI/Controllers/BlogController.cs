using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
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

        public async Task<IActionResult> Index()
        {
            BlogsVM blogs = new()
            {
                blogs = await _context.blogs.ToListAsync()
            };
            return View(blogs);
        }
        public async Task<IActionResult> Details(int id)
        {
            Blogs blog = await _context.blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            BlogsVM blogsVM = new BlogsVM
            {
                blogs = new List<Blogs> { blog }
            };

            return View(blogsVM);
        }

    }
}
