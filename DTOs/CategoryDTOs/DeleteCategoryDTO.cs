using System.ComponentModel.DataAnnotations;

namespace gp2.DTOs.CategoryDTOs
{
    public class DeleteCategoryDTO
    {

        [Required]
        public int CategoryId { get; set; }
    }
}
