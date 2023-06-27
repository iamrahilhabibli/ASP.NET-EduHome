using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class Users:IEntity
{
    public int Id { get; set; }
    [Required,MaxLength(30)]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).*$",
       ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one symbol.")]
    [MaxLength(30)]
    public string Password { get; set; }
}
