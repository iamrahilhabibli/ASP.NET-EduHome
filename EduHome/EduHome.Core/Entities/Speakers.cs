using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities
{
    public class Speakers:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
    }
}
