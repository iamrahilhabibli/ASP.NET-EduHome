﻿using EduHome.Core.Entities;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels;

public class EventsViewModel
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Venue { get; set; }
    public List<Speakers> Speakers { get; set; }

}
