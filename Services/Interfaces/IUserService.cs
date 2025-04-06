using gp2.DTOs.UserDTOs;
using gp2.Models;
using Microsoft.AspNetCore.Mvc;
using gp2.Services.Services;
using gp2.DTOs.UserDTOs;

namespace gp2.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDTO createUserDTO);

        Task<IEnumerable<GetUserDTO>> GetAllUsers();

    }
}
