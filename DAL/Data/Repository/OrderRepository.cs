using BLL.Models;
using DAL.Data.Interfaces;

namespace DAL.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateOrder(Order order) => Create(order);
    }
}
