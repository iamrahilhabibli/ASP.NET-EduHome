﻿using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.ViewModels;

namespace EduHomeUI.Mappers
{
	public class TeachersProfile:Profile
	{
        public TeachersProfile()
        {
			CreateMap<TeachersViewModel, Teachers>().ReverseMap();
		}

	}
}
