using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class TeachersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeachersController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
			return View(await _context.teachers.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create(TeachersViewModel newTeacher)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			Teachers newT = _mapper.Map<Teachers>(newTeacher);

			TeacherDetails details = new TeacherDetails
			{
				Description = newTeacher.Description,
				Degree = newTeacher.Degree,
				ExperienceYears = newTeacher.ExperienceYears,
				Hobbies = newTeacher.Hobbies,
				Faculty = newTeacher.Faculty,
				PhoneNumber = newTeacher.PhoneNumber,
				Email = newTeacher.Email,
				SkypeAddress= newTeacher.SkypeAddress,
				LanguageSkills = newTeacher.LanguageSkills,
				TeamLeaderSkills = newTeacher.TeamLeaderSkills,
				DevelopmentSkills = newTeacher.DevelopmentSkills,
				Design = newTeacher.Design,
				Innovation = newTeacher.Innovation,
				Communication = newTeacher.Communication,
			};

			newT.TeacherDetails = details;

			await _context.teachers.AddAsync(newT);
			await _context.SaveChangesAsync();

			TempData["Success"] = "Teacher Created Successfully";

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int Id)
		{
			Teachers teacher = await _context.teachers.FindAsync(Id);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}
		[HttpPost]
		[ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeletePost(int Id)
		{
			Teachers teacher = await _context.teachers.FindAsync(Id);
			if (teacher == null)
			{
				return NotFound();
			}

			TeacherDetails details = await _context.teachersDetails.FindAsync(teacher.Id);
			if (details != null)
			{
				_context.teachersDetails.Remove(details);
			}

			_context.teachers.Remove(teacher);
			await _context.SaveChangesAsync();
			TempData["Success"] = "Teacher Deleted Successfully";

			return RedirectToAction(nameof(Index));
		}
	}
}
