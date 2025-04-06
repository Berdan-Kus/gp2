using gp2.Data;
using gp2.DTOs.UserDTOs;
using gp2.Models;
using gp2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gp2.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly FinanceDbContext _context;

        public CategoryRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(u => u.CategoryId == id);
        }


        public async Task DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

    }
}
