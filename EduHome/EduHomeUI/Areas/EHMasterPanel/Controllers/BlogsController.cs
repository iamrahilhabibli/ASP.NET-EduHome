using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class BlogsController : Controller
{
	private readonly AppDbContext _context;
    public BlogsController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
	{
		return View(await _context.blogs.ToListAsync());
	}
}
