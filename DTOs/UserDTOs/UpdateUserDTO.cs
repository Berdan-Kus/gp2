using System.ComponentModel.DataAnnotations;

namespace gp2.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {

        public int UserId { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
