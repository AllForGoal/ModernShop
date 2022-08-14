using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Services.IContract;
using Services.Respond;
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
        private readonly IproductService _productService;

        public ProductController(IUntityOfWork untityOfWork,IMapper mapper,IproductService productService)
        {
            _untityOfWork = untityOfWork;
            _mapper = mapper;
            _productService=productService;
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
          return Ok(await  _productService.GetAllAsync());
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
            return Ok(await  _productService.GetAsync(Id));
        }
        
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpPut("Update")]
        public IActionResult Update(ProductUpdateDto productDto)
        {
          return Ok(  _productService.Update(productDto));
        }
         [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(ServiceResponded<ProductDto>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpPost("AddProduct")]
        public  ServiceResponded<ProductDto> AddProduct(ProductAddDto productDto)
        {
            return(_productService.AddProduct(productDto));
        }
    }
}
