using System.ComponentModel.DataAnnotations;

namespace gp2.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public String CategoryName { get; set; }
    }
}
