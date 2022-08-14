using Entity.Core;
using Entity.Core.Models;
using Repository.Implementation;
using Repository.Interface.UserRepository;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUntityOfWork
    {
           IGenericRepository<Product> ProductRepository { get; }
           IGenericRepository<Stock> StockRepository { get; }
        int SaveChange();
       public  ICategoryRepository CategoryRepository { get; }
        public Task<int> SaveAsync();
    }
}