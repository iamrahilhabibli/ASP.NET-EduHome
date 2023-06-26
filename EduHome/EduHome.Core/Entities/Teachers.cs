using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Teachers:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string ImagePath { get; set; }
    public TeacherDetails TeacherDetails { get; set; }

}
