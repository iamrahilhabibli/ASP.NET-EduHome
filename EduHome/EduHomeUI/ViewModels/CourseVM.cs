using EduHome.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EduHomeUI.ViewModels;

public class CourseVM
{
	[BindNever]
	public IEnumerable<Courses> Courses { get; set; }
	[BindNever]
	public IEnumerable<CourseDetails> CourseDetails { get; set;}
	[BindNever]
	public UserReplies userReplies { get; set; }
}
