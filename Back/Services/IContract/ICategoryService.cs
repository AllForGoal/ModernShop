using Entity.Dto.categoryDto;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z_EcommerceSystem.DTO;

namespace Services.IContract
{
    public interface ICategoryService
    {
        public Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO categoryDTO);

        public Task<GetCategoryDTO> getCategory(int categoryoId);

        public Task<List<GetCategoryDTO>> getParentcategory();

        public Task<List<GetCategoryDTO>> getCategorysByParent(int categoryoId);

        public void UpdateCategory(int id, UpdateCategoryDto categoryDto);

        public void DeleteCategory(int categoryoId);
    }
}