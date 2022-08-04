using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;

namespace Services.Mapping
{
    public class AppProfileConfiguration:Profile
    {
         public AppProfileConfiguration()
         {
            //CreateMap<ProductDto,Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductUpdateDto,Product>();
            CreateMap<Stock, StockDto>();
            CreateMap<StockUpdateDto,Stock>();
        }
    }
}