using Entity.Core;
using Entity.Core.Models;
using Repository.Implementation;

namespace Repository.Interface
{
    public interface IUntityOfWork
    {
           IGenericRepository<Product> ProductRepository { get; }
           IGenericRepository<Stock> genericRepository { get; }
        void SaveChange();
    }
}