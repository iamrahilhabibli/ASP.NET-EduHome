using AutoMapper;
using EduHome.DataAccess.Migrations;
using EduHomeUI.ViewModels;
using System.Reflection.Metadata;

namespace EduHomeUI.Mappers
{
	public class CoursesProfile:Profile
	{
		public CoursesProfile()
		{
			CreateMap<CoursesViewModel, CoursesAdded>().ReverseMap();
		}
	}
}
