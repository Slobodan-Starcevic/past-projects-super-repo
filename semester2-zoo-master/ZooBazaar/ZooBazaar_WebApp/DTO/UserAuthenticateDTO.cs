using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO
{
    public class UserAuthenticateDTO
    {
        public UserAuthenticateDTO()
        {
        }

        [Required(ErrorMessage = "Username is missing")]
        [MaxLength(200, ErrorMessage = "20 characters max are allowed for the username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        [MaxLength(300, ErrorMessage = "30 characters max are allowed for the password")]
        public string Password { get; set; }
    }
}
