using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IRepositoryManager
    {
        IAuthRepository Auth { get; }
        IItemRepository Items { get;}
        IOrderRepository Orders { get; }
        Task SaveAsync();

    }
}
