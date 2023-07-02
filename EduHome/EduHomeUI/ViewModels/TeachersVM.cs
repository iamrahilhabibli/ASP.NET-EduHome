using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels;

public class TeachersVM
{
	public IEnumerable<Teachers> Teachers { get; set;}
	public IEnumerable<TeacherDetails> TeachersDetails { get; set;}
}
