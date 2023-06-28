using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.ViewModels;

namespace EduHomeUI.Mappers
{
    public class UserReplyProfile:Profile
    {
        public UserReplyProfile()
        {
            CreateMap<UserReplyVM, UserReplies>().ReverseMap();
        }
    }
}
