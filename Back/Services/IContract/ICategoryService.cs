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

        public Task UpdateCategory(UpdateCategoryDto categoryDto);

        public Task DeleteCategory(int categoryoId);
    }
}