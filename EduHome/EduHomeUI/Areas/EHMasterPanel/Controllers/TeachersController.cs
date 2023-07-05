using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
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

        public async Task<IActionResult> Update(int id)
        {
            Teachers teacher = await _context.teachers.Include(t => t.TeacherDetails).FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            TeachersViewModel teacherViewModel = _mapper.Map<TeachersViewModel>(teacher);
            return View(teacherViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, TeachersViewModel updatedTeacher)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedTeacher);
            }

            Teachers teacher = await _context.teachers.Include(t => t.TeacherDetails).FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            teacher.Name = updatedTeacher.Name;
            teacher.Position = updatedTeacher.Position;
            teacher.ImagePath = updatedTeacher.ImagePath;

            if (teacher.TeacherDetails != null)
            {
                teacher.TeacherDetails.Description = updatedTeacher.Description;
                teacher.TeacherDetails.Degree = updatedTeacher.Degree;
                teacher.TeacherDetails.ExperienceYears = updatedTeacher.ExperienceYears;
                teacher.TeacherDetails.Hobbies = updatedTeacher.Hobbies;
                teacher.TeacherDetails.Faculty = updatedTeacher.Faculty;
                teacher.TeacherDetails.PhoneNumber = updatedTeacher.PhoneNumber;
                teacher.TeacherDetails.Email = updatedTeacher.Email;
                teacher.TeacherDetails.SkypeAddress = updatedTeacher.SkypeAddress;
                teacher.TeacherDetails.LanguageSkills = updatedTeacher.LanguageSkills;
                teacher.TeacherDetails.TeamLeaderSkills = updatedTeacher.TeamLeaderSkills;
                teacher.TeacherDetails.DevelopmentSkills = updatedTeacher.DevelopmentSkills;
                teacher.TeacherDetails.Design = updatedTeacher.Design;
                teacher.TeacherDetails.Innovation = updatedTeacher.Innovation;
                teacher.TeacherDetails.Communication = updatedTeacher.Communication;

                _context.Entry(teacher.TeacherDetails).State = EntityState.Modified;
            }
            else
            {
                TeacherDetails newDetails = new TeacherDetails
                {
                    Description = updatedTeacher.Description,
                    Degree = updatedTeacher.Degree,
                    ExperienceYears = updatedTeacher.ExperienceYears,
                    Hobbies = updatedTeacher.Hobbies,
                    Faculty = updatedTeacher.Faculty,
                    PhoneNumber = updatedTeacher.PhoneNumber,
                    Email = updatedTeacher.Email,
                    SkypeAddress = updatedTeacher.SkypeAddress,
                    LanguageSkills = updatedTeacher.LanguageSkills,
                    TeamLeaderSkills = updatedTeacher.TeamLeaderSkills,
                    DevelopmentSkills = updatedTeacher.DevelopmentSkills,
                    Design = updatedTeacher.Design,
                    Innovation = updatedTeacher.Innovation,
                    Communication = updatedTeacher.Communication
                };

                teacher.TeacherDetails = newDetails;
                _context.teachersDetails.Add(newDetails);
            }

            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["Success"] = "Teacher Updated Successfully";

            return RedirectToAction(nameof(Index));
        }

    }
}
