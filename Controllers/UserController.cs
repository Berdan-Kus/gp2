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


       


    }
}
