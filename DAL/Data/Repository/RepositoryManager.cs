using DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IAuthRepository _authRepository;
        private IItemRepository _itemRepository;
        private IOrderRepository _orderRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAuthRepository Auth
        {
            get
            {
                if (_authRepository == null)
                    _authRepository = new AuthRepository(_repositoryContext);
                return _authRepository;
            }
        }

        public IItemRepository Items
        {
            get
            {
                if (_itemRepository == null)
                    _itemRepository = new ItemRepository(_repositoryContext);
                return _itemRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_repositoryContext);
                return _orderRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}
