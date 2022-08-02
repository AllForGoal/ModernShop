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
        public StockController(IUntityOfWork untityOfWork)
        {
            _untityOfWork = untityOfWork;
        }
    }
}
