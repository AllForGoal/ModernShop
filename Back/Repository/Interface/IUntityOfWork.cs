using Entity.Core;
using Entity.Core.Models;
using Repository.Implementation;
using Repository.Interface.UserRepository;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUntityOfWork
    {
       public  ICategoryRepository CategoryRepository { get; }
        public Task SaveAsync();
    }
}