using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace z_EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUntityOfWork _untityOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUntityOfWork untityOfWork,IMapper mapper)
        {
            _untityOfWork = untityOfWork;
            _mapper = mapper;
        }


        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(List<ProductDto>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpGet("GetAll")]
        //get all products 
        public async Task<IActionResult> GetAll()
        {
            var result = await _untityOfWork.ProductRepository.getEntityAsync(false);
            
            if (result != null)
            {
                List<ProductDto> products = _mapper.Map<List<ProductDto>>(result);
                return Ok(products);
            }
            else return StatusCode(400,"internal server error");
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpGet("Get/{Id}")]
        //get all products 
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _untityOfWork.ProductRepository.getEntityAsyncById(Id);

            if (result != null)
            {
                ProductDto product = _mapper.Map<ProductDto>(result);
                return Ok(product);
            }
            else return StatusCode(400, "internal server error");
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _untityOfWork.ProductRepository.updateEntity(product);
                _untityOfWork.SaveChange();
                return Ok(true);
            }
            catch (Exception e)
            {
                return StatusCode(401, e.Message);
            }
        }
    }
}
