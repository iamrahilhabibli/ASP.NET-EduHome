using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
      
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
