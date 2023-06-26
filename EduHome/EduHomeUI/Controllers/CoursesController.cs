using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers;

public class CoursesController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
