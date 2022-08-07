using AutoMapper;
using Entity.Core.Models;
using Repository.Interface;
using Services.IContract;
using Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z_EcommerceSystem.DTO;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUntityOfWork _untityOfWork;
        private readonly IMapper _Mapper;

        public CategoryService(IUntityOfWork untityOfWork, IMapper mapper)
        {
            _untityOfWork = untityOfWork;
            _Mapper = mapper;
        }

        public async  Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            if(categoryDTO.Name != string.Empty) 
            {
                var category = _Mapper.Map<Category>(categoryDTO);
            var cat =await _untityOfWork.CategoryRepository.GetCategoryWithParent(category);
                if (cat == null)
                {
                    var data=  await _untityOfWork.CategoryRepository.AddCategory(category);
                    await _untityOfWork.SaveAsync();
                    var result= _Mapper.Map<CreateCategoryDTO>(data);
                    return  result;
                }

            }
                return null;
        }
    }
}
