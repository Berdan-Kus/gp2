using AutoMapper;
using gp2.Data;
using gp2.DTOs.CategoryDTOs;
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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategoryAsync([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            return await _categoryService.CreateCategoryAsync(createCategoryDTO);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryDTO deleteCategoryDTO)
        {
            var result = await _categoryService.DeleteCategoryAsync(deleteCategoryDTO);

            if (!result)
                return NotFound("Kategori bulunamadı.");

            return Ok("Kategori başarıyla silindi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDTO);

            if (!result)
                return NotFound("Kategori bulunamadı.");

            return Ok("Kategori bilgileri güncellendi.");
        }

    }
}
