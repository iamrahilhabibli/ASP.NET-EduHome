using EduHome.Core.Interfaces;

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
    }
}
