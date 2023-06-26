using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Students:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }

}
