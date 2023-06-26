using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Notices:IEntity
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public string Description { get; set; }
    public bool isLeft { get; set; }
    public string? Title { get; set; }
}
