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
    public class StockController : ControllerBase
    {
        private readonly IUntityOfWork _untityOfWork;
        private readonly IMapper _mapper;
        public StockController(IUntityOfWork untityOfWork,IMapper mapper)
        {
            _untityOfWork = untityOfWork;
            _mapper = mapper;
        }
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(List<StockDto>))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpGet("GetAll/{id}")]
        public async Task<IActionResult> GetAll(int id) //product id
        {
            try
            {
                var result = await _untityOfWork.StockRepository.getEntityAsync(s => s.ProductId == id, false);
                List<StockDto> stocks = _mapper.Map<List<StockDto>>(result);
                return Ok(stocks);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StockDto))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _untityOfWork.StockRepository.getEntityAsyncById(id);

                    StockDto stock = _mapper.Map<StockDto>(result);
                    return Ok(stock);
            }
            catch (Exception e)
            {
                            return StatusCode(500, e.Message);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(StockUpdateDto stockDto)
        {
            try
            {
                Stock stock = _mapper.Map<Stock>(stockDto);
                _untityOfWork.StockRepository.updateEntity(stock);
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
