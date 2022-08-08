using Entity.Dto.categoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Services.IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using z_EcommerceSystem.DTO;

namespace z_EcommerceSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            var result = await _categoryService.CreateCategory(categoryDTO);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParentsCategory()
        {
            var result = await _categoryService.getParentcategory();
            if (result == null)
            {
                return NotFound("Not Have Parent category ");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllChildCategory(int id)
        {
            var result = await _categoryService.getCategorysByParent(id);
            if (result == null)
            {
                return NotFound("Not Have SubCategory ");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetails(int id)
        {
            var result = await _categoryService.getCategory(id);
            if (result == null)
            {
                return NotFound("Not Have SubCategory ");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("UpdateCategory object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            _categoryService.UpdateCategory(id, categoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}