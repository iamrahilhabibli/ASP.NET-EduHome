using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class TestimonialsController : Controller
{
    private readonly AppDbContext _context;

    public TestimonialsController(AppDbContext context)
    {
        _context = context;
    }
   public async Task<IActionResult> Index()
{
    var testimonials = await _context.testimonials.Include(t => t.Courses).ToListAsync();
    return View(testimonials);
}

    public IActionResult Create()
    {
        return View();
    }
    
}
