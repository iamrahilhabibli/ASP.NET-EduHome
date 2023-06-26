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
        TeachersVM teachersVM = new TeachersVM
        {
            Teachers = await _context.teachers.ToListAsync()
        };
		return View(teachersVM);
	}
}
