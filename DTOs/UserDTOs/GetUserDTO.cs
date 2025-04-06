namespace gp2.DTOs.UserDTOs
{
    public class GetUserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
