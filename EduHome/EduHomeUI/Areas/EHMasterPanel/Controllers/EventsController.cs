using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers;
[Area("EHMasterPanel")]
public class EventsController : Controller
{
	private readonly AppDbContext _context;
	private readonly IMapper _mapper;

	public EventsController(AppDbContext context, IMapper mapper)
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
		Events existingEvent = await _context.events.Include(e => e.EventDetails).FirstOrDefaultAsync(e => e.Id == id);
		if (existingEvent == null)
		{
			return NotFound();
		}

		EventsViewModel eventViewModel = _mapper.Map<EventsViewModel>(existingEvent);
		return View(eventViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(int id, EventsViewModel updatedEvent)
	{
		if (!ModelState.IsValid)
		{
			return View(updatedEvent);
		}

		Events existingEvent = await _context.events.Include(e => e.EventDetails).FirstOrDefaultAsync(e => e.Id == id);
		if (existingEvent == null)
		{
			return NotFound();
		}

		existingEvent.Title = updatedEvent.Title;
		existingEvent.Date = updatedEvent.Date;
		existingEvent.StartTime = updatedEvent.StartTime;
		existingEvent.EndTime = updatedEvent.EndTime;
		existingEvent.Location = updatedEvent.Location;

		if (existingEvent.EventDetails != null)
		{
			existingEvent.EventDetails.Venue = updatedEvent.Venue;
			existingEvent.EventDetails.Description = updatedEvent.Description;

			_context.Entry(existingEvent.EventDetails).State = EntityState.Modified;
		}
		else
		{
			EventDetails newDetails = new EventDetails
			{
				Venue = updatedEvent.Venue,
				Description = updatedEvent.Description
			};

			existingEvent.EventDetails = newDetails;
			_context.eventDetails.Add(newDetails);
		}

		_context.Entry(existingEvent).State = EntityState.Modified;
		await _context.SaveChangesAsync();

		TempData["Success"] = "Event Updated Successfully";

		return RedirectToAction(nameof(Index));
	}
    public SelectList GetSpeakerSelectList()
    {
        var speakers = _context.speakers.ToList();
        var speakerList = speakers.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();

        return new SelectList(speakerList, "Value", "Text");
    }

}


