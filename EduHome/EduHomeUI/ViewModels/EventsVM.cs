using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels
{
    public class EventsVM
    {
        public IEnumerable<Events> events { get; set; }
        public IEnumerable<EventDetails> eventsDetails { get; set; }
    }
}
