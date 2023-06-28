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
		await _context.courses.AddAsync(course);
		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(Index));

	}
}
