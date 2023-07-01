using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class Speakers:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        [ForeignKey("EventDetails")]
        public int EventDetailsId { get; set; }
        public EventDetails EventDetails { get; set; }
	}
}
