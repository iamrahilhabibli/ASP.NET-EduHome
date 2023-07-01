using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class TestimonialsController : Controller
{
    private readonly AppDbContext _context;

    public TestimonialsController(AppDbContext context)
    {
        _context = context;
    }
   public async Task<IActionResult> Index()
    {
        var testimonials = await _context.testimonials.Include(t => t.Courses).ToListAsync();
        return View(testimonials);
    }
	[HttpGet]
	public IActionResult Create()
	{
		var courses = _context.courses.ToList();

		var availableCourses = courses.Select(c => new SelectListItem
		{
			Value = c.Id.ToString(),
			Text = c.Name
		}).ToList();

		var viewModel = new TestimonialsViewModel
		{
			AvailableCourses = availableCourses
		};

		return View(viewModel);
	}

}
