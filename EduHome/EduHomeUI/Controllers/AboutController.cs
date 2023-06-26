using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers;

public class AboutController : Controller
{
	private readonly AppDbContext _context;

    public AboutController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
	{
		return View();
	}
}
