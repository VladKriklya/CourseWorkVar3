using System.ComponentModel.DataAnnotations;

namespace BLL.UserModels
{
    public class UserForRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
        [Required]
        public byte Role { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
