﻿using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;

namespace EduHomeUI.Mappers
{
    public class EventsProfile:Profile
	{
        public EventsProfile()
        {
			CreateMap<EventsViewModel, Events>().ReverseMap();
		}
    }
}
