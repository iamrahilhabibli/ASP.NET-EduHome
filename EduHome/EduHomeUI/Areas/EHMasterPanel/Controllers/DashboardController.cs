using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;

public class DashboardController : Controller
{
	[Area("EHMasterPanel")]
	public IActionResult Index()
	{
		return View();
	}
}
