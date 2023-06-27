using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Courses:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public CourseDetails Details { get; set; }
    public Testimonials testimonials { get; set; }
}
