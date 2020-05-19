using BLL.Models;
using DAL.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Data.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

      /*  public IEnumerable<Item> GetAllCompanies(bool trackChanges) =>
          FindAll(trackChanges)
         .OrderBy(c => c.Name)
         .ToList();*/

    }
}
