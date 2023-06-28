using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;

public class EventsController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
