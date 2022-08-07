using Entity.Core;
using Entity.Context;
using Repository.Interface;
using Entity.Core.Models;
using Repository.Interface.UserRepository;
using Repository.Implementation.UserRepository;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UntityOfWork : IUntityOfWork
    {
        private readonly AppEccommerceDbContext _context;
        private ICategoryRepository _categoryRepository;

        public UntityOfWork(AppEccommerceDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}