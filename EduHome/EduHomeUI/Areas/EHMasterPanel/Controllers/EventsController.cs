using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class EventsController : Controller
{
	private readonly AppDbContext _context;
	private readonly IMapper _mapper;

    public EventsController(AppDbContext context,IMapper mapper)
    {
        _context = context;
		_mapper = mapper;
    }
    public async Task<IActionResult> Index()
	{
		return View(await _context.events.ToListAsync());
	}
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> Create(EventsViewModel events)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		Events newEvent = _mapper.Map<Events>(events);
		await _context.events.AddAsync(newEvent);
		await _context.SaveChangesAsync();
		TempData["Success"] = "Event Created Successfully";

		return RedirectToAction(nameof(Index));
	}
}
