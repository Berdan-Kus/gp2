using gp2.DTOs.UserDTOs;
using gp2.Models;
using System.Threading.Tasks;

namespace gp2.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User?> GetUserByIdAsync(int id);

        Task DeleteUserAsync(User user);

        Task UpdateUserAsync(User user);
    }
}
