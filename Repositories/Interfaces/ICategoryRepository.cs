using gp2.DTOs.CategoryDTOs;
using gp2.Models;
using System.Threading.Tasks;


namespace gp2.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);

        Task<IEnumerable<Category>> GetAllCategories();

        Task<Category?> GetCategoryByIdAsync(int id);


        Task DeleteCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);


    }
}
