﻿using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class SpeakersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
