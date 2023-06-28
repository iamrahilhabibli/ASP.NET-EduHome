using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers;

public class UserRepliesController : Controller
{
    private readonly AppDbContext _context;
	private readonly IMapper _mapper;

    public UserRepliesController(AppDbContext context,IMapper mapper)
    {
        _context = context;
		_mapper = mapper;
    }
    public IActionResult Index()
    {
        List<UserReplies> objCategoryList = _context.userReplies.ToList();
        return View(objCategoryList);
  
    }
    [HttpPost]
    public IActionResult Create(UserReplyVM reply)
    {
        UserReplies userReplies = _mapper.Map<UserReplies>(reply);

        if (ModelState.IsValid)
        {
            _context.userReplies.Add(userReplies);
            _context.SaveChanges();
            TempData["Success"] = "Reply Sent Successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(reply);
    }
}
