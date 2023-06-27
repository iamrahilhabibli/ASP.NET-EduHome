using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers;

public class AboutController : Controller
{
	private readonly AppDbContext _context;

    public AboutController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        AboutVM about = new AboutVM
        {
            Teachers = await _context.teachers.ToListAsync(),
            Testimonials = await _context.testimonials.ToListAsync(),
            Notices = await _context.notices.ToListAsync(),
        };
		return View(about);
	}
}
