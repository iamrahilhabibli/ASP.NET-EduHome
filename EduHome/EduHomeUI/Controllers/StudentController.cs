using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _context;

        public TestimonialsController(AppDbContext context)
        {
            _context = context;
        }

    }
}
