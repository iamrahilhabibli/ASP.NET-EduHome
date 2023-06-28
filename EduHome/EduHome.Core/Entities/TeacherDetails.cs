using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
	public class TeacherDetails:IEntity
	{
        public int Id { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
        public int ExperienceYears { get; set; }
        public string Hobbies { get; set; }
        public string Faculty { get; set; }
        [ForeignKey("Teachers")]
        public int TeacherId { get; set; }
        public Teachers Teacher { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SkypeAddress { get; set; }
		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int LanguageSkills { get; set; }

		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int TeamLeaderSkills { get; set; }

		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int DevelopmentSkills { get; set; }

		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int Design { get; set; }

		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int Innovation { get; set; }

		[Range(0, 100, ErrorMessage = "The value must be between 0 and 100.")]
		public int Communication { get; set; }
	}
}
