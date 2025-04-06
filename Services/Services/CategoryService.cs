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
using gp2.Repositories.Repositories;
using gp2.Repositories;
using gp2.DTOs.CategoryDTOs;

namespace gp2.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);


            return await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<IEnumerable<GetCategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<GetCategoryDTO>>(categories);
        }


        public async Task<GetCategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null;
            }

            return _mapper.Map<GetCategoryDTO>(category);
        }


        public async Task<bool> DeleteCategoryAsync(DeleteCategoryDTO deleteCategoryDTO)
        {
            // Kullanıcıyı veritabanında kontrol et
            var category = await _categoryRepository.GetCategoryByIdAsync(deleteCategoryDTO.CategoryId);
            if (category == null)
            {
                return false;
            }

            await _categoryRepository.DeleteCategoryAsync(category);
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(updateCategoryDTO.CategoryId);
            if (existingCategory == null)
            {
                return false;
            }

            _mapper.Map(updateCategoryDTO, existingCategory);

            await _categoryRepository.UpdateCategoryAsync(existingCategory);
            return true;
        }

    }
}
