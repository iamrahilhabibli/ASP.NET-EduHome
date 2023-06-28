using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
