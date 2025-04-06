using AutoMapper;
using gp2.Models;
using gp2.DTOs.UserDTOs;

namespace gp2.Helpers.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User,GetUserDTO>();
            CreateMap<GetUserDTO, User>();

            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<User, DeleteUserDTO>();
            CreateMap<DeleteUserDTO, User>();

            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, UpdateUserDTO>();

        }
    }
}
