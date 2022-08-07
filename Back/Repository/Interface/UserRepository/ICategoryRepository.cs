using Entity.Core.Models;
using System.Threading.Tasks;

namespace Repository.Interface.UserRepository
{
    public interface ICategoryRepository 
    {
        public Task<Category> AddCategory(Category category);
        public Task<Category> GetCategoryWithParent(Category category);

    }
}
