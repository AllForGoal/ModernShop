using AutoMapper;
using Entity.Core.Models;
using Entity.Dto.categoryDto;
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

        public async Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            if (categoryDTO.Name != string.Empty)
            {
                var category = _Mapper.Map<Category>(categoryDTO);
                var cat = await _untityOfWork.CategoryRepository.GetCategoryWithParent(category);
                if (cat == null)
                {
                    var data = await _untityOfWork.CategoryRepository.AddCategory(category);
                    await _untityOfWork.SaveAsync();
                    var result = _Mapper.Map<CreateCategoryDTO>(data);
                    return result;
                }
            }
            return null;
        }

        public async void DeleteCategory(int categoryoId)
        {
            if (categoryoId != 0)
            {
                _untityOfWork.CategoryRepository.DeleteCategory(categoryoId);
                await _untityOfWork.SaveAsync();
            }
        }

        public async Task<GetCategoryDTO> getCategory(int categoryoId)
        {
            if (categoryoId != 0)
            {
                var category = await _untityOfWork.CategoryRepository.GetCategory(categoryoId);
                if (category != null)
                {
                    var catDto = _Mapper.Map<GetCategoryDTO>(category);
                    return catDto;
                }
            }
            return null;
        }

        //get child and parent categories
        public async Task<List<GetCategoryDTO>> getCategorysByParent(int categoryoId)
        {
            var catigories = await _untityOfWork.CategoryRepository.GetCategorys(categoryoId);
            var catDto = _Mapper.Map<List<GetCategoryDTO>>(catigories);
            return catDto;
        }

        public async Task<List<GetCategoryDTO>> getParentcategory()
        {
            var catigories = await _untityOfWork.CategoryRepository.GetCategorys(0);
            var catDto = _Mapper.Map<List<GetCategoryDTO>>(catigories);
            return catDto;
        }

        public async void UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            if (categoryDto != null)
            {
                var category = await _untityOfWork.CategoryRepository.GetCategory(id);
                var cat = _Mapper.Map(categoryDto, category);
                _untityOfWork.CategoryRepository.UpdateCategory(cat);
                await _untityOfWork.SaveAsync();
            }
        }
    }
}