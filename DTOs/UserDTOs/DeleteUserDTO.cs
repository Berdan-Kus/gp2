using System.ComponentModel.DataAnnotations;

namespace gp2.DTOs.UserDTOs
{
    public class DeleteUserDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
