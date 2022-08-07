using Entity.Context;
using Entity.Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.UserRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation.UserRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppEccommerceDbContext _context;

        public CategoryRepository(AppEccommerceDbContext appEccommerceDbContext) : base(appEccommerceDbContext)
        {
            _context = appEccommerceDbContext;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await AddEntityAsync(category);
            return category;
        }

        public async Task<Category> GetCategoryWithParent(Category category)
        {
            return await getOneEntityAsync(e => e.Name == category.Name && e.ParentId == category.ParentId, false);
        }

        public async Task<Category> GetCategory(int id)
        {
            return await getEntityAsyncById(id);
        }

        public async Task<List<Category>> GetCategorys(int parentId)
        {
            if (parentId == 0)
            {
                return await getEntityAsync(e => e.ParentId == null, false);
            }
            return await getEntityAsync(e => e.ParentId == parentId, false);
        }

        public async Task<List<Category>> GetCategorywithDependices(int id)
        {
            return await _context.categories.Where(e => e.Id == id).Include("Parent").ToListAsync();
        }

        public void UpdateCategory(Category category)
        {
            updateEntity(category);
        }

        public async void DeleteCategory(int id)
        {
            var category = await getEntityAsyncById(id);
            if (category != null)
            {
                _context.Remove<Category>(category);
            }
        }
    }
}