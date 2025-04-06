using gp2.Data;
using gp2.DTOs.UserDTOs;
using gp2.Models;
using gp2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gp2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceDbContext _context;

        public UserRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()  
        {
            return await _context.Users.ToListAsync();
        }

        


    }
}
