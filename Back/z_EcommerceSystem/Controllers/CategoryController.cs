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
    {private readonly ICategoryService _categoryService;



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

      
    }
}
