using System.ComponentModel.DataAnnotations;

namespace gp2.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        
        [Required]
        public String CategoryName { get; set; }
    }
}
