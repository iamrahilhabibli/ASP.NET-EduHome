using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class HomeSlider:IEntity
{
    public int Id { get; set; }
    [Required,MaxLength(30)]
    public string Title { get; set; }
    [Required,MaxLength(250)]
    public string Description { get; set; }
    [Required]
    public string ImagePath { get; set; }
}
