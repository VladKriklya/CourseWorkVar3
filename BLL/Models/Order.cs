using BLL.UserModels;
using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserForListId { get; set; }
        public UserForList User { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
