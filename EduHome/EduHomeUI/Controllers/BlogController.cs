﻿using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
