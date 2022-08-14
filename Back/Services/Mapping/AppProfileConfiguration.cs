using AutoMapper;
using Entity.Core.Models;
using z_EcommerceSystem.DTO;

namespace Services.Mapping
{
    public class AppProfileConfiguration:Profile
    {
         public AppProfileConfiguration()
         {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
        }
    }
}