using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Teachers> Teachers { get; set;}
        public IEnumerable<Testimonials> Testimonials { get; set;}
        public IEnumerable<Notices> Notices { get; set;}
    }
}
