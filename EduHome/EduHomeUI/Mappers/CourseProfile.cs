﻿using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Migrations;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
using System.Reflection.Metadata;

namespace EduHomeUI.Mappers
{
    public class CoursesProfile:Profile
	{
		public CoursesProfile()
		{
			CreateMap<CoursesViewModel, Courses>().ReverseMap();
		}
	}
}
