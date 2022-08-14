using Entity.Core.Models;
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
        public ProductController(IUntityOfWork untityOfWork)
        {
            _untityOfWork = untityOfWork;
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("GetAll")]
        //get all products 
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _untityOfWork.ProductRepository.getEntityAsync(false);
                return Ok(result);
            }
            catch (Exception)
            {
             return StatusCode(500, "server error");
            }
        }



    }
}
