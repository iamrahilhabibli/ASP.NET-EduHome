using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
	public class Testimonials : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImagePath { get; set; }
		public string Description { get; set; }
		public string Occupation { get; set; }

		[ForeignKey("Courses")]
		public int CourseId { get; set; }

		public Courses Courses { get; set; }
	}
}
