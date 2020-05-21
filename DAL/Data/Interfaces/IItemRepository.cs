using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IItemRepository
    {
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        Task<Item> GetItemAsync(int id, bool trackChanges);
        Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges);


    }
}
