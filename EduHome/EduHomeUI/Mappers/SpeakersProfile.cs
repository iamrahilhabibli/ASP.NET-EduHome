using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.ViewModels;

namespace EduHomeUI.Mappers
{
	public class SpeakersProfile:Profile
	{
        public SpeakersProfile()
        {
            CreateMap<SpeakersViewModel, Speakers>().ReverseMap();
        }
    }
}
