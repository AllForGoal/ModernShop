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

    }
}
