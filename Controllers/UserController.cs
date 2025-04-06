using AutoMapper;
using gp2.Data;
using gp2.DTOs.UserDTOs;
using gp2.Models;
using gp2.Services.Interfaces;
using gp2.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gp2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync([FromBody] CreateUserDTO createUserDTO)
        {
            return await _userService.CreateUserAsync(createUserDTO);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDTO deleteUserDTO)
        {
            var result = await _userService.DeleteUserAsync(deleteUserDTO);

            if (!result)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok("Kullanıcı başarıyla silindi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            var result = await _userService.UpdateUserAsync(updateUserDTO);

            if (!result)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok("Kullanıcı bilgileri güncellendi.");
        }




    }
}
