using EduHome.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EduHomeUI.ViewModels;

public class CourseVM
{
	public IEnumerable<Courses> Courses { get; set; }
	public IEnumerable<CourseDetails> CourseDetails { get; set;}
}
