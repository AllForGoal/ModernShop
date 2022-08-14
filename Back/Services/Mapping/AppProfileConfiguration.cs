using AutoMapper;
using Entity.Core.Models;
using Entity.Dto;
using z_EcommerceSystem.DTO;

namespace Services.Mapping
{
    public class AppProfileConfiguration:Profile
    {
         public AppProfileConfiguration()
         {
            //CreateMap<ProductDto,Product>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateDto,Product>().ReverseMap();
            CreateMap<ProductAddDto,Product>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<StockUpdateDto,Stock>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
        }
    }
}