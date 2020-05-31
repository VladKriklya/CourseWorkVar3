using BLL.Models;
using BLL.RequestFeatures;
using BLL.RequestParameters;
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

        public async Task<PagedList<Item>> GetAllItemsAsync(ItemParameters itemParameters,bool trackChanges)
        {
            var items = await FindByCondition(e => e.AvailableItems != 0, trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();

            return PagedList<Item>
                .ToPagedList(items, itemParameters.PageNumber, itemParameters.PageSize);   
        }
             
        public async Task<Item> GetItemAsync(int id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();
    }
}
