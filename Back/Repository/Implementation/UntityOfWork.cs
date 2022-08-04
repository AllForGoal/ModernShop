using Entity.Core;
using Entity.Context;
using Repository.Interface;
using Entity.Core.Models;

namespace Repository.Implementation
{
    public class UntityOfWork : IUntityOfWork
    {
        private readonly AppEccommerceDbContext _dbContext;
        IGenericRepository<Product> _ProductRepository;
        IGenericRepository<Stock> _StockRepository;


        public UntityOfWork(AppEccommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<Product> ProductRepository {
            get
            {
                if (_ProductRepository == null)
                {
                    return new GenericRepository<Product>(_dbContext);
                }
                return _ProductRepository;
            }
        }
        public IGenericRepository<Stock> StockRepository
        {
            get
            {
                if (_ProductRepository == null)
                {
                    return new GenericRepository<Stock>(_dbContext);
                }
                return _StockRepository;
            }
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}