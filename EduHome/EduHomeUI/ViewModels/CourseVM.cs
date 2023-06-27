using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels;

public class CourseVM
{
	public IEnumerable<Courses> Courses { get; set; }
	public IEnumerable<CourseDetails> CourseDetails { get; set;}
    public UserReplies userReplies { get; set; }
}
