using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class UserReplies:IEntity
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [Required,MaxLength(75)]
    public string Email { get; set; }
    [Required,MaxLength(50)]
    public string Subject { get; set; }
    [Required,MaxLength(250)]
    public string Message { get; set; }
}
