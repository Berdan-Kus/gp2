using AutoMapper;
using gp2.Models;
using gp2.DTOs.CategoryDTOs;
using gp2.DTOs.UserDTOs;

namespace gp2.Helpers.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {

            CreateMap<Category, GetCategoryDTO>();
            CreateMap<GetCategoryDTO, Category>();

            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();

            CreateMap<Category, DeleteCategoryDTO>();
            CreateMap<DeleteCategoryDTO, Category>();
            
            CreateMap<Category, UpdateCategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>();
            


        }
    }
}
