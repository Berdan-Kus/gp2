using System.ComponentModel.DataAnnotations;
using gp2.Models;


namespace gp2.DTOs.UserDTOs
{
    public class CreateUserDTO
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
