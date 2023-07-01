using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHomeUI.ViewModels
{
	public class TestimonialsViewModel
	{
		public List<SelectListItem> AvailableCourses { get; set; }
		public string SelectedCourseName { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImagePath { get; set; }
		public string Description { get; set; }
		public string Occupation { get; set; }
	}
}
