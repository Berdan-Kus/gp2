using gp2.DTOs.UserDTOs;
using gp2.Models;
using System.Threading.Tasks;

namespace gp2.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);

        Task<IEnumerable<User>> GetAllUsers();

    }
}
