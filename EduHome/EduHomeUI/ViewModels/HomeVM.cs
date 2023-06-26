using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels;

public class HomeVM
{
    public IEnumerable<HomeSlider> homeSliders { get; set; }
    public IEnumerable<Notices> notices { get; set; }
    public IEnumerable<Events> events { get; set; }
}
