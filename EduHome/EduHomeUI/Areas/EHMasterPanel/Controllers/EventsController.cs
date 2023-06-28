using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class EventsController : Controller
{
	private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
	{
		return View(await _context.events.ToListAsync());
	}
}
