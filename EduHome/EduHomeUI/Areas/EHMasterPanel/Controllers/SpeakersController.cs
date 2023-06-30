using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class SpeakersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SpeakersController(AppDbContext context,IMapper mapper)
        {
            _context = context;
			_mapper  = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.speakers.ToListAsync());
        }
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create(SpeakersViewModel speakers)
		{
			if (!ModelState.IsValid)
			{
				return View(speakers);
			}

			Speakers speaker = _mapper.Map<Speakers>(speakers);


			await _context.speakers.AddAsync(speaker);
			await _context.SaveChangesAsync();

			TempData["Success"] = "Speaker Created Successfully";

			return RedirectToAction(nameof(Index));
		}
	}
}
