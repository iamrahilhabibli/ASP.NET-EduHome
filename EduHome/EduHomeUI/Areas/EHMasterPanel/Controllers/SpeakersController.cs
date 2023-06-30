using AutoMapper;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class SpeakersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        public SpeakersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.speakers.ToListAsync());
        }
    }
}
