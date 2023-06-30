using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
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
	public async Task<IActionResult> Delete(int Id)
	{
		Blogs blogs = await _context.blogs.FindAsync(Id);
		if (blogs == null)
		{
			return NotFound();
		}

		return View(blogs);
	}
	[HttpPost]
	[ActionName("Delete")]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> DeletePost(int Id)
	{
		Blogs blogs = await _context.blogs.FindAsync(Id);
		if (blogs == null)
		{
			return NotFound();
		}

		_context.blogs.Remove(blogs);
		await _context.SaveChangesAsync();
		TempData["Success"] = "Blog Deleted Successfully";

		return RedirectToAction(nameof(Index));
	}
	public async Task<IActionResult> Update(int Id)
	{
		Blogs blogs = await _context.blogs.FindAsync(Id);
		if (blogs == null)
		{
			return NotFound();
		}
		return View(blogs);
	}
}
