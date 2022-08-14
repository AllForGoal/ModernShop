

using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Dto;
using Services.Respond;

namespace Services.IContract
{
    public interface  IproductService
    {
         ServiceResponded< ProductDto> AddProduct(ProductAddDto productAddDto) ;
         Task<ServiceResponded<ProductDto>>AddProductAsync(ProductAddDto productAddDto) ;
         ServiceResponded<List<ProductDto>>GetAll();
         Task<ServiceResponded<List<ProductDto>>> GetAllAsync();
         ServiceResponded<ProductDto> Get(int Id);
         Task<ServiceResponded<ProductDto>> GetAsync(int Id);
         ServiceResponded<int> Update(ProductUpdateDto productDto);
    }
}