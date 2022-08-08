using AutoMapper;
using Entity.Core.Models;
using Entity.Dto.categoryDto;
using z_EcommerceSystem.DTO;

namespace Services.Mapping
{
    public class AppProfileConfiguration : Profile
    {
        public AppProfileConfiguration()
        {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<GetCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}