using EduHome.Core.Entities;
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
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> Create(Blogs blog)
	{
		if(!ModelState.IsValid)
		{
			return View();
		}
		blog.Date = DateTime.Now;
		blog.CommentCount = 0;

		await _context.blogs.AddAsync(blog);
		await _context.SaveChangesAsync();

		TempData["Success"] = "Blog Created Successfully";

		return RedirectToAction(nameof(Index));

	}

}
