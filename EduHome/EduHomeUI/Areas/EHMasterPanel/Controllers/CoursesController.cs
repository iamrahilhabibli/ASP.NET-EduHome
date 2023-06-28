using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class CoursesController : Controller
{
	private readonly AppDbContext _context;
	private readonly IMapper _mapper;
	public CoursesController(AppDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
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
	public async Task<IActionResult> Create(CoursesViewModel courses)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		Courses course = _mapper.Map<Courses>(courses);

		CourseDetails details = new CourseDetails
		{
			StartDate = courses.StartDate,
			Duration = courses.Duration,
			SkillLevel = courses.SkillLevel,
			Language = courses.Language,
			StudentCount = courses.StudentCount,
			Assesment = courses.Assesment,
			Fee = courses.Fee
		};

		course.Details = details;

		await _context.courses.AddAsync(course);
		await _context.SaveChangesAsync();

		TempData["Success"] = "Course Created Successfully";

		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int Id)
	{
		Courses course = await _context.courses.FindAsync(Id);
		if (course == null)
		{
			return NotFound();
		}

		return View(course);
	}
	[HttpPost]
	[ActionName("Delete")]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> DeletePost(int Id)
	{
		Courses course = await _context.courses.FindAsync(Id);
		if (course == null)
		{
			return NotFound();
		}

		CourseDetails details = await _context.courseDetails.FindAsync(course.Id);
		if (details != null)
		{
			_context.courseDetails.Remove(details);
		}

		_context.courses.Remove(course);
		await _context.SaveChangesAsync();
		TempData["Success"] = "Course Deleted Successfully";

		return RedirectToAction(nameof(Index));
	}


    public async Task<IActionResult> Update(int Id)
    {
        Courses course = await _context.courses.FindAsync(Id);
        if (course == null)
        {
            return NotFound();
        }

        CoursesViewModel courseViewModel = _mapper.Map<CoursesViewModel>(course);
        return View(courseViewModel);
    }

    [HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(CoursesViewModel courses)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		Courses course = _mapper.Map<Courses>(courses);
		_context.Entry(course).State = EntityState.Modified;
		await _context.SaveChangesAsync();
		TempData["Success"] = "Category Updated Successfully";
		return RedirectToAction(nameof(Index));
		}
	}
