using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers;

public class UserRepliesController : Controller
{
    private readonly AppDbContext _context;

    public UserRepliesController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<UserReplies> objCategoryList = _context.userReplies.ToList();
        return View(objCategoryList);
  
    }
	[HttpPost]
	public IActionResult Create(CourseVM viewModel)
	{
		var userReplies = viewModel.userReplies;

		if (ModelState.IsValid)
		{
			_context.userReplies.Add(userReplies);
			_context.SaveChanges();
			TempData["Success"] = "Category Created Successfully";
			return RedirectToAction(nameof(Index));
		}

		return View(viewModel);
	}


}
