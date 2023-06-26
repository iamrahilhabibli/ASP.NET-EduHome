using EduHome.Core.Entities;
using EduHome.Core.Interfaces;

public class EventDetails : IEntity
{
	public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
	public int EventId { get; set; }
	public Events Event { get; set; }
}