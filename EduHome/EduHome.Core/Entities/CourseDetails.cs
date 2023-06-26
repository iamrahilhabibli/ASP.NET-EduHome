using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities;

public class CourseDetails:IEntity
{
    public int Id { get; set; }
    public Courses Courses { get; set; }
    [ForeignKey("Courses")]
	public int CourseId { get; set; }
    public DateTime StartDate { get; set; }
    public string Duration { get; set; }
    public string SkillLevel { get; set; }
    public string Language { get; set;}
    public int StudentCount { get; set; }
    public string Assesment { get; set; }
    public decimal Fee { get; set; }
}
