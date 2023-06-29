using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new()
            {
                homeSliders = await _context.homeSliders.ToListAsync(),
                notices = await _context.notices.ToListAsync(),
                events = await _context.events.ToListAsync(),
                courses = await _context.courses.ToListAsync(),
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Index2()
        {
            HomeVM homeVM = new()
            {
                homeSliders = await _context.homeSliders.ToListAsync(),
            };
            return View(homeVM);
        }
		public async Task<IActionResult> Index3()
		{
			HomeVM homeVM = new()
			{
				homeSliders = await _context.homeSliders.ToListAsync(),
			};
			return View(homeVM);
		}
		public async Task<IActionResult> Index4()
		{
			HomeVM homeVM = new()
			{
				homeSliders = await _context.homeSliders.ToListAsync(),
			};
			return View(homeVM);
		}
        public async Task<IActionResult> Index5()
        {
            HomeVM homeVM = new()
            {
                homeSliders = await _context.homeSliders.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
