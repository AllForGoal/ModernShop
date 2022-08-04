using Entity.Context;
using Entity.Core.Models;
using Repository.Interface.UserRepository;
using System.Threading.Tasks;

namespace Repository.Implementation.UserRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppEccommerceDbContext appEccommerceDbContext) :base(appEccommerceDbContext)
        {

        }

        public async  Task<Category> AddCategory(Category category)
        {
            await AddEntityAsync(category);
            return category;
        }

        public async Task<Category> GetCategoryWithParent(Category category)
        {
            return await getOneEntityAsync(e => e.Name == category.Name && e.ParentId == category.ParentId, false);
        }
    }
}
