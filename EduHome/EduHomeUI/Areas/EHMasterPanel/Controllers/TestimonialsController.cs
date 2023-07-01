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
			// Find the selected course from the database using the selected course name
			var selectedCourse = _context.Courses.FirstOrDefault(c => c.Name == viewModel.SelectedCourseName);

			if (selectedCourse == null)
			{
				// Handle the case where the selected course does not exist in the database
				ModelState.AddModelError("SelectedCourseName", "Invalid course selected.");
				viewModel.AvailableCourses = GetAvailableCourses();
				return View(viewModel);
			}

			// Map the view model to the entity model
			var testimonial = new Testimonials
			{
				Name = viewModel.Name,
				Surname = viewModel.Surname,
				ImagePath = viewModel.ImagePath,
				Description = viewModel.Description,
				Occupation = viewModel.Occupation,
				CourseId = selectedCourse.Id, // Assign the CourseId
				Courses = selectedCourse // Assign the Courses navigation property
			};

			// Save the testimonial to the database
			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();

			// Redirect to a success page or perform other


		}
