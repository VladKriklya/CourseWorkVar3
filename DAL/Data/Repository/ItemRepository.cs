using BLL.Models;
using DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateItem(Item item) => Create(item);
        public void DeleteItem(Item item) => Delete(item);
        public void UpdateItem(Item item) => Update(item);

        public async Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges) =>
             await FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToListAsync();


        public async Task<Item> GetItemAsync(int id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();
    }
}
