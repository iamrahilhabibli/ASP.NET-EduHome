using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.ViewModels
{
	public class UserReplyVM
	{
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(75)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Subject { get; set; }
        [Required, MaxLength(250)]
        public string Message { get; set; }
    }
}
