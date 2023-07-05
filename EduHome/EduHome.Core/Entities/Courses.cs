using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities
{
	public class Courses : BaseEntity
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public CourseDetails Details { get; set; }
    }
}
