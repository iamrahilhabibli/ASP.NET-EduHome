using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
