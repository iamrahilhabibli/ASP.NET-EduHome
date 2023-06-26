using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Events:IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; }
}
