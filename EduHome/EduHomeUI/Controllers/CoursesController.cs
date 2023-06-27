using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers;

public class CoursesController : Controller
{
	private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
		_context = context;	
    }
    public async Task<IActionResult> Index()
	{
		CourseVM courseVM = new()
		{
			Courses = await _context.courses.ToListAsync(),
		};
		return View(courseVM);
	}
	public async Task<IActionResult> Details()
	{
		CourseVM courseVM = new()
		{
			CourseDetails = await _context.courseDetails.ToListAsync(),
		};
		return View(courseVM);
	}
}
