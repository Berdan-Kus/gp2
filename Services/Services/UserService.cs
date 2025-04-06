using AutoMapper;
using gp2.Data;
using gp2.Models;
using gp2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gp2.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Azure;
using gp2.Repositories.Interfaces;



namespace gp2.Services.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<User> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);


            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsers()  
        {
            var users = await _userRepository.GetAllUsers();  
            return _mapper.Map<IEnumerable<GetUserDTO>>(users);
        }

        public async Task<GetUserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<GetUserDTO>(user);
        }


        public async Task<bool> DeleteUserAsync(DeleteUserDTO deleteUserDTO)
        {
            // Kullanıcıyı veritabanında kontrol et
            var user = await _userRepository.GetUserByIdAsync(deleteUserDTO.UserId);
            if (user == null)
            {
                return false;
            }

            await _userRepository.DeleteUserAsync(user);
            return true;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(updateUserDTO.UserId);
            if (existingUser == null)
            {
                return false;
            }

            _mapper.Map(updateUserDTO, existingUser);

            await _userRepository.UpdateUserAsync(existingUser);
            return true;
        }



    }
}
