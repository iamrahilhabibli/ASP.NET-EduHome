using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class CoursesController : Controller
{
	private readonly AppDbContext _context;
	public CoursesController(AppDbContext context)
	{
		_context = context;
	}
	public async Task<IActionResult> Index()
	{
		return View(await _context.courses.ToListAsync());
	}
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	[AutoValidateAntiforgeryToken]
	public IActionResult Create(CoursesViewModel courses)
	{
		if (ModelState.IsValid)
		{
			var course = new Courses
			{
				Name = courses.Name,
				Description = courses.Description,
				ImagePath = courses.ImagePath
			};

			_context.courses.Add(course);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
		return View();
	}
}
