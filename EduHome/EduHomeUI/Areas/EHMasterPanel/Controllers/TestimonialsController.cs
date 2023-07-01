using EduHome.Core.Entities;
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
	[HttpPost]
	public IActionResult Create(TestimonialsViewModel viewModel)
	{
		if (ModelState.IsValid)
		{

			var selectedCourse = _context.courses.FirstOrDefault(c => c.Name == viewModel.SelectedCourseName);

			if (selectedCourse == null)
			{

				ModelState.AddModelError("SelectedCourseName", "Invalid course selected.");
				viewModel.AvailableCourses = GetAvailableCourses();
				return View(viewModel);
			}
			var testimonial = new Testimonials
			{
				Name = viewModel.Name,
				Surname = viewModel.Surname,
				ImagePath = viewModel.ImagePath,
				Description = viewModel.Description,
				Occupation = viewModel.Occupation,
				CourseId = selectedCourse.Id, 
				Courses = selectedCourse 
			};

			_context.testimonials.Add(testimonial);
			_context.SaveChanges();

			TempData["Success"] = "Course Created Successfully";
			return RedirectToAction(nameof(Index));
		}
		viewModel.AvailableCourses = GetAvailableCourses();
		return View(viewModel);
	}
	private List<SelectListItem> GetAvailableCourses()
	{
		var courses = _context.courses.ToList();

		var availableCourses = courses.Select(c => new SelectListItem
		{
			Value = c.Id.ToString(),
			Text = c.Name
		}).ToList();

		return availableCourses;
	}

}
