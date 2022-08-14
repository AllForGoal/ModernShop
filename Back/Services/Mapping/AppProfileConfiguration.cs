using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;

using Entity.Core.Models;
using z_EcommerceSystem.DTO;

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
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
        }
    }
}