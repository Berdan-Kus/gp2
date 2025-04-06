using gp2.Models;
using Microsoft.AspNetCore.Mvc;
using gp2.Services.Services;
using gp2.DTOs.CategoryDTOs;


namespace gp2.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<Category> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);

        Task<IEnumerable<GetCategoryDTO>> GetAllCategories();

        Task<GetCategoryDTO?> GetCategoryByIdAsync(int id);

        Task<bool> DeleteCategoryAsync(DeleteCategoryDTO deleteCategoryDTO);

        Task<bool> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
    }
}
