using Entity.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface.UserRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> AddCategory(Category category);

        public Task<Category> GetCategoryWithParent(Category category);

        public Task<Category> GetCategory(int id);

        public Task<List<Category>> GetCategorys(int parentId);

        public Task<List<Category>> GetCategorywithDependices(int id);

        public void UpdateCategory(Category category);

        public void DeleteCategory(int id);
    }
}