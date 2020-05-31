using BLL.Models;
using BLL.RequestFeatures;
using BLL.RequestParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IItemRepository
    {
        void CreateItem(Item item);
        void DeleteItem(Item item);
        Task<Item> GetItemAsync(int id, bool trackChanges);
        Task<PagedList<Item>> GetAllItemsAsync(ItemParameters itemParameters, bool trackChanges);


    }
}
