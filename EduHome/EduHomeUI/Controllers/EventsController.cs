using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
