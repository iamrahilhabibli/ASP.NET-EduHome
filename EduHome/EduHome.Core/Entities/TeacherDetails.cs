using EduHome.Core.Interfaces;
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
        public int LanguageSkills { get; set; }
        public int TeamLeaderSkills { get; set; }
        public int DevelopmentSkills { get; set; }
        public int Design { get; set; }
        public int Innovation { get; set; }
        public int Communication { get; set; }
    }
}
