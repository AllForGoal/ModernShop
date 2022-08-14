using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;
using Repository.Interface;
using Services.IContract;
using Services.Respond;

namespace Services.Services
{
    public class productService : IproductService
    {
        private readonly IUntityOfWork _untityOfWork;
        private readonly IMapper _mapper;

        public productService(IUntityOfWork untityOfWork,IMapper mapper)
        {
            _untityOfWork=untityOfWork;
            _mapper =mapper;
        }

        public ServiceResponded<ProductDto> AddProduct(ProductAddDto productAddDto)
        {
            var productDb=_mapper.Map<Product>(productAddDto);
            _untityOfWork.ProductRepository.AddEntity(productDb);
            var result=_untityOfWork.SaveChange();
            if(result<=0) return new ServiceResponded<ProductDto>(){Result=false,Message="Error When Save"};
            ProductDto productDto=_mapper.Map<ProductDto>(productDb);
            return new ServiceResponded<ProductDto>(){Result=true,Message="Success when save",Data=productDto};
        }

        public Task<ServiceResponded<ProductDto>> AddProductAsync(ProductAddDto productAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResponded<ProductDto> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponded<List<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponded<List<ProductDto>>> GetAllAsync()
        {
           var result = await _untityOfWork.ProductRepository.getEntityAsync(false);
            
            if (result != null)
            {
                List<ProductDto> products = _mapper.Map<List<ProductDto>>(result);
                return new ServiceResponded<List<ProductDto>>(){Result=true,Data=products,Message="success to get data"};
            }
            else return new ServiceResponded<List<ProductDto>>(){Result=false,Message="Data Is emptee"};
        }

        public async Task< ServiceResponded<ProductDto>> GetAsync(int Id)
        {
           var result = await _untityOfWork.ProductRepository.getEntityAsyncById(Id);

            if (result != null)
            {
                ProductDto product = _mapper.Map<ProductDto>(result);
                return new ServiceResponded<ProductDto>(){Data=product,Message="Success to get",Result=true};
            }
           return new ServiceResponded<ProductDto>(){Message="faild to get",Result=false};
        }

        public ServiceResponded<int> Update(ProductUpdateDto productDto)
        {
             try
            {
                Product product = _mapper.Map<Product>(productDto);
                _untityOfWork.ProductRepository.updateEntity(product);
                _untityOfWork.SaveChange();
                return new ServiceResponded<int>  (){Data=1,Message="success to update",Result=true};
            }
            catch (Exception e)
            {
                return new ServiceResponded<int>  (){Data=1,Message=e.Message,Result=false};
            }
        }
    }
}