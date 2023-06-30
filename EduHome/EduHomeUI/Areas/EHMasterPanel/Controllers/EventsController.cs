using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class EventsController : Controller
{
	private readonly AppDbContext _context;
	private readonly IMapper _mapper;

    public EventsController(AppDbContext context,IMapper mapper)
    {
        _context = context;
		_mapper = mapper;
    }
    public async Task<IActionResult> Index()
	{
		return View(await _context.events.ToListAsync());
	}
	public IActionResult Create()
	{
		return View();
	}

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(EventsViewModel events)
    {
        if (!ModelState.IsValid)
        {
            return View(events);
        }

        Events newEvent = _mapper.Map<Events>(events);

		EventDetails details = new EventDetails
		{
			Venue = events.Venue,
			Description = events.Description,
		};

		newEvent.EventDetails = details;

        await _context.events.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Event Created Successfully";

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int Id)
	{
		Events newEvent = await _context.events.FindAsync(Id);
		if (newEvent == null)
		{
			return NotFound();
		}

		return View(newEvent);
	}
	[HttpPost]
	[ActionName("Delete")]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> DeletePost(int Id)
	{
		Events newEvent = await _context.events.FindAsync(Id);
		if (newEvent == null)
		{
			return NotFound();
		}
		_context.events.Remove(newEvent);
		await _context.SaveChangesAsync();
		TempData["Success"] = "Event Deleted Successfully";
		return RedirectToAction(nameof(Index));
	}

    public async Task<IActionResult> Update(int id)
    {
        Events newEvent = await _context.events.FindAsync(id);
        if (newEvent == null)
        {
            return NotFound();
        }

        EventsViewModel eventViewModel = _mapper.Map<EventsViewModel>(newEvent);
        return View(eventViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, EventsViewModel events)
    {
        if (!ModelState.IsValid)
        {
            return View(events);
        }

        Events newEvent = await _context.events.Include(e => e.EventDetails).FirstOrDefaultAsync(e => e.Id == id);
        if (newEvent == null)
        {
            return NotFound();
        }

        newEvent.Title = events.Title;
        newEvent.Date = events.Date;
        newEvent.StartTime = events.StartTime;
        newEvent.EndTime = events.EndTime;
        newEvent.Location = events.Location;

        if (newEvent.EventDetails != null)
        {
            newEvent.EventDetails.Venue = events.Venue;
            newEvent.EventDetails.Description = events.Description;

            _context.Entry(newEvent.EventDetails).State = EntityState.Modified;
        }
        else
        {
            EventDetails newDetails = new EventDetails
            {
                Venue = events.Venue,
                Description = events.Description
            };
            newEvent.EventDetails = newDetails;
            _context.EventDetails.Add(newDetails);
        }

        _context.Entry(newEvent).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        TempData["Success"] = "Event Updated Successfully";

        return RedirectToAction(nameof(Index));
    }

}


