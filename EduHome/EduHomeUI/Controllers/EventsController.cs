using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EduHomeUI.ViewModels;
using EduHome.Core.Entities;

namespace EduHomeUI.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            EventsVM eventsVM = new EventsVM
            {
               events = await _context.events.ToListAsync()
            };

            return View(eventsVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var newEvent = await _context.events.FindAsync(id);

            if (newEvent == null)
            {
                return NotFound();
            }

            EventsVM eventVM = new EventsVM
            {
                events = new List<Events> { newEvent },
                eventsDetails = await _context.eventDetails.ToListAsync()
            };

            return View(eventVM);
        }
    }
}
