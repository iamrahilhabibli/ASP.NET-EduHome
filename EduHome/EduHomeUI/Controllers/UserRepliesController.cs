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
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(viewModel.userReplies.Email))
            {
                _context.userReplies.Add(viewModel.userReplies);
                _context.SaveChanges();
                TempData["Success"] = "Category Created Successfully";

                // Redirect to Courses/Details action with the category ID
                return RedirectToAction("Details", "Courses");
            }
            else
            {
                ModelState.AddModelError("userReplies.Email", "The Email field is required.");
            }
        }

        return RedirectToAction(nameof(Index));
    }



}
